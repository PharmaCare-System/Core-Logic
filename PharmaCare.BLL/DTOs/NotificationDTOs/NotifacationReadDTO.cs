using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.NotificationDTOs
{

    public class NotifacationReadDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserType UserType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}
