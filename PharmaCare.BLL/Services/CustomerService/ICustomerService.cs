using PharmaCare.BLL.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.CustomerService
{
    public interface ICustomerService
    {
        // Add, Update, Delete, GetAll, GetById
        public IEnumerable<CustomerReadDTO> GetAll();
        public CustomerReadDTO GetById(int id);
        public void Add(CustomerAddDTO customer);
        public void Update(CustomerUpdateDTO customer);
        public void Delete(int id);
    }
}
