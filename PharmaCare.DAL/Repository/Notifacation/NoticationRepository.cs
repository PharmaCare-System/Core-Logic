using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Dal;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCareNot.DAL
{
    public class NoticationRepository:INotifacationRepository
    {
        private readonly ApplicationDbContext _context;
        public NoticationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Notifacation> GetAll()
        {
            return _context.notifacations;
        }
        public Notifacation GetById(int id)
        {
            return _context.notifacations.Find(id);
        }
        public void Add(Notifacation pharmacy)
        {
            _context.notifacations.Add(pharmacy);
            _context.SaveChanges();
        }
        public void Update(Notifacation pharmacy)
        {
            _context.notifacations.Update(pharmacy);
            _context.SaveChanges();
        }
        public void Delete(Notifacation pharmacy)
        {
            _context.notifacations.Remove(pharmacy);
            _context.SaveChanges();
        }
    }
}
