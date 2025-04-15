using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.PharmayDTOs
{
    public class PharmacyUpdateDto
    {

        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public int MangerPharmacyId { get; set; }



    }
}
