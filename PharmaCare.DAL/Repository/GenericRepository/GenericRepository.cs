using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;


namespace PharmaCare.DAL.Repository.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
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
            _DbSet.Remove(entity);
            await _context.SaveChangesAsync();
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{

            return await _DbSet.ToListAsync();
		}
        public async Task<PagedResult<T>> GetPagedAsync(int page, int pageSize,
																Expression<Func<T, bool>>? filter = null,
																	Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> query = _DbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<T>
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                Items = items
            };
        }
    }
}

