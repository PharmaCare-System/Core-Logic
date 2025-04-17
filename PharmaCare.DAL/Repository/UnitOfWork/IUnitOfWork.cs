using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		//IGenericRepository<Product> ProductRepository {get; set;}
		//Inventory
		//Purchase

		Task<int> CompleteAsync();
	}
}
