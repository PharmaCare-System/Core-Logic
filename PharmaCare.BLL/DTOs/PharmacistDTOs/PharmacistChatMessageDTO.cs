using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;

namespace PharmaCare.BLL.DTOs.PharmacistDTOs
{
    public class PharmacistChatMessageDTO
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }

        // Sender may be Pharmacist or Customer
        public UserType UserType { get; set; }
    }

    }

