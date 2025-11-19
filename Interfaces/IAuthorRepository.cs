using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Models;

namespace C_Sharp.Interfaces
{
	public interface IAuthorRepository
	{
		void Update(Author author);
		Task<bool> SaveAllAsync();
		Task<Author?> GetAuthorByIdAsync(int id);
		Task<IEnumerable<Author>> GetAllAuthorsAsync();
	}
}