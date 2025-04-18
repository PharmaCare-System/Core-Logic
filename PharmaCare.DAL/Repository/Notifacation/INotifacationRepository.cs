using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace Notification.Dal
{
    public interface INotifacationRepository : IGenericRepository<Notifacation>
    {
    

    }
}
