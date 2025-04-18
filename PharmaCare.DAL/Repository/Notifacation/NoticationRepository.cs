using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Dal;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCareNot.DAL
{
    public class NoticationRepository:GenericRepository<Notifacation>, INotifacationRepository
    {
        public NoticationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
   
}
