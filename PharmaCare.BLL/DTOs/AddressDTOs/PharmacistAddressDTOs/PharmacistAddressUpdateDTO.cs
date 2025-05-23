using PharmaCare.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.AddressDTOs.CustomerAddressDTOs
{
    public class PharmacistAddressUpdateDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public short streetNumber { get; set; }

        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}
