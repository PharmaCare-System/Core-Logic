using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using PharmaCare.BLL.DTOs.NotifaciionDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.NotifacationService
{
    public interface INotifacationService
    {
        public IEnumerable<NotifacationReadDto> GetAll();
        public NotifacationReadDto GetById(int id);
        void Add(NotifacationAddDto pharmacy);
        void Update(NotifacationUpdateDto pharmacy);
        void Delete(int id);
    }
}
