using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = true;
        // relations
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
