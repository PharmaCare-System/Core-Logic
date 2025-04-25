using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using PharmaCare.BLL.DTOs.NotificationDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.NotificationService
{
    public interface INotificationService
    {
        public IEnumerable<NotificationReadDto> GetAll();
        public NotificationReadDto GetById(int id);
        void Add(NotificationAddDto pharmacy);
        void Update(NotificationUpdateDto pharmacy);
        void Delete(int id);
    }
}
