using PharmaCare.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		//public IGenericRepository<Product> ProductRepository { get; set; }
		//Inventory
		//Purchase
		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			//ProductRepository = new GenericRepository<Product>(_context);
			//Inventory
			//Purchase
		}
		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
