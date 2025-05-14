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
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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
			await _context.SaveChangesAsync();
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _DbSet.ToListAsync();
		}

        public async Task<PagedResult<T>> GetPagedAsync(Expression<Func<T, bool>> filter, PaginationParameters parameters)
        {
			var Query = _DbSet.Where(filter).AsQueryable();
            //oprtional if we needed sorting and searching

            //        if (!string.IsNullOrEmpty(parameters.SortBy))
            //        {
            //            var sortOrder = parameters.IsAscending ? "ascending" : "descending";
            //Query = Query.OrderBy($"{parameters.SortBy}{sortOrder}");
            //        }
            //        if (!string.IsNullOrEmpty(parameters.SearchTerm))
            //        {
            //            Query = Query.Where($"Name.Contains(@0)", parameters.SearchTerm);
            //        }



            var totalCount = Query.Count();
			var items = await Query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
				.Take(parameters.PageSize)
				.ToListAsync();
			return new PagedResult<T>
			{
				Items = items,
				TotalCount = totalCount,
				PageNumber= parameters.PageNumber,
				PageSize = parameters.PageSize
            };

        }
    }
}
