using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.GenericRepository
{
	public interface IGenericRepository<T> where T : class
	{
		Task AddAsync(T entity);
		IQueryable<T> GetQueryable();
		Task<T> GetAsyncById(int id);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
