using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Repository.GenericRepository
{
	public interface IGenericRepository<T> 
    {
		Task AddAsync(T entity);
		Task<IEnumerable<T>> GetAllAsync();
		IQueryable<T> GetQueryable();
		Task<T> GetAsyncById(int id);
		Task UpdateAsync(T entity);
		Task SoftDelete(T entity);

    }
}
