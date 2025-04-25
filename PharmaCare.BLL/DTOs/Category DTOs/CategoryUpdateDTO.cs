using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.Category_DTOs
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
