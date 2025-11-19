using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Interfaces;
using C_Sharp.Models;
using Microsoft.EntityFrameworkCore;

namespace C_Sharp.Data
{
  public class AuthorRepository(DataContext context) : IAuthorRepository
  {
    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
      return await context.Authors.FindAsync(id);
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
      return await context.Authors.ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await context.SaveChangesAsync() > 0;
    }

    public void Update(Author author)
    {
      context.Entry(author).State =EntityState.Modified;
    }
  }
}