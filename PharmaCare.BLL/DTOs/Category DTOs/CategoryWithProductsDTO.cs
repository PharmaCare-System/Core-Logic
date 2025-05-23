using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.ProductDTOs;

namespace PharmaCare.BLL.DTOs.Category_DTOs
{
    public class CategoryWithProductsDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<ProductReadDTO> Products { get; set; }
    }
}
