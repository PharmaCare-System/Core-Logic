using PharmaCare.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.AddressDTOs
{
    public class AddressAddDTO
    {
        public string Country { get; set; }
        public string City { get; set; }
        public short streetNumber { get; set; }

        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}
