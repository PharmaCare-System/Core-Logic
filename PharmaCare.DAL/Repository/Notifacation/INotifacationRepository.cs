using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserNotifications;

namespace Notification.Dal
{
    public interface INotifacationRepository
    {
        public IQueryable<Notifacation> GetAll();
        public Notifacation GetById(int id);
        void Add(Notifacation pharmacy);
        void Update(Notifacation pharmacy);
        void Delete(Notifacation pharmacy);

    }
}
