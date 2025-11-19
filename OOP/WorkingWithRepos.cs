using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Data;
using C_Sharp.Interfaces;
using C_Sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace C_Sharp.OOP
{
	public interface IAuthorLocalRepository
	{
		void Update(Author author);
		Task<bool> SaveAllAsync();
		Task<Author?> GetAuthorByIdAsync(int id);
		Task<IEnumerable<Author>> GetAllAuthorsAsync();
		void DeleteAutor(Author author);
		void NewAuthor(Author author);
		Task UpdateAuthor(Author authorUpdated);

	}

	public class AuthorLocalRepository(DataContext context) : IAuthorLocalRepository
	{
		DataContext _context => context;

		public async Task<Author?> GetAuthorByIdAsync(int id)
		{
			return await _context.Authors.FindAsync(id);
		}

		public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
		{
			return await _context.Authors.ToListAsync();
		}

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public void Update(Author author)
		{
			context.Entry(author).State = EntityState.Modified;
		}

		public void DeleteAutor(Author author)
		{
			context.Authors.Remove(author);
		}

		public void NewAuthor(Author author)
		{
			context.Authors.Add(author);
			context.SaveChanges();
		}

		public async Task UpdateAuthor(Author authorUpdated)
		{
			var authorToUpdate = await _context.Authors.FindAsync(authorUpdated.Id);
			authorToUpdate!.FirstName = authorUpdated.FirstName;
			authorToUpdate!.LastName = authorUpdated.LastName;
			await context.SaveChangesAsync();
		}
	}


	public class ExecuteRepo(IAuthorLocalRepository _authorRepo)
	{
		public int MyProperty { get; set; }
		private IAuthorLocalRepository authorRepo => _authorRepo;

		public async Task<IEnumerable<Author>> GetAllAuthors()
		{
			return await authorRepo.GetAllAuthorsAsync();
		}

		public async Task<Author?> GetAuthorById(int id)
		{
			return await authorRepo.GetAuthorByIdAsync(id);
		}

		public async Task DeleteAuthor(int id)
		{
			var author = await authorRepo.GetAuthorByIdAsync(id);
			if (author == null) throw new Exception("The author does not exist yet!");
			authorRepo.DeleteAutor(author);
			if (!await authorRepo.SaveAllAsync()) throw new Exception("Operation fail");
		}

		public void NewAuthor(Author author)
		{
			authorRepo.NewAuthor(author);
		}

		public async Task UpdateAuthor(Author authorUpdated)
		{
			await authorRepo.UpdateAuthor(authorUpdated);
		}
	}

	public static class WorkingWithRepos
	{
		public static async Task RunningRepo()
		{
			// Creating 
			IAuthorLocalRepository repo = new AuthorLocalRepository(new DataContext());

			var authorRepo = new ExecuteRepo(repo);
			var newAuthor = new Author { Id = 0, FirstName = "Vanessa Ferguson", LastName = "de Adonis" };
			authorRepo.NewAuthor(newAuthor);
			var authorUpdated = new Author { Id = 40, FirstName = "Kirby", LastName = "de Adonis" };
			await authorRepo.UpdateAuthor(authorUpdated);

			var result = await authorRepo.GetAllAuthors();
			foreach (var item in result)
			{
				Console.WriteLine($"{item.Id} - {item.FirstName}");
			}

			var result2 = await authorRepo.GetAuthorById(999);
			Console.WriteLine($"----\n{result2?.FirstName}");

			var deleteAuthor = authorRepo.DeleteAuthor(12);
		}
	}
}



 