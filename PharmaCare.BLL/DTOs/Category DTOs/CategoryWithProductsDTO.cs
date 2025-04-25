using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.Category_DTOs
{
    public class CategoryWithProductsDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
