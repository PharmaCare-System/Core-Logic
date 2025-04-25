using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.NotificationDTOs
{
    public class NotificationUpdateDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
