using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : Base
	{
		public readonly ApplicationDbContext _context;
		public readonly DbSet<T> _DbSet;
		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_DbSet = _context.Set<T>();
		}
		public async Task AddAsync(T entity)
		{
			await _DbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}
		public IQueryable<T> GetQueryable()
		{
			return _DbSet.AsQueryable();
		}
		public async Task<T> GetAsyncById(int id)
		{
			return await _DbSet.FindAsync(id);
		}
		public async Task UpdateAsync(T entity)
		{
			await _context.SaveChangesAsync();
		}
		public async Task SoftDelete(T entity)
		{	
			entity.IsDeleted = true;
			entity.DeletedDateTime = DateTime.Now;
			await _context.SaveChangesAsync();
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _DbSet.ToListAsync();
		}
	}
}
