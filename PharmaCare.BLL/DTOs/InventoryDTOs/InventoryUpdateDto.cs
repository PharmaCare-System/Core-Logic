using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.InventoryDTOs
{
    public class InventoryUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int PharmacyId { get; set; }
    }
}
