using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models.UserMessages;
using PharmaCare.DAL.Database;

namespace PharmaCare.DAL.Repository.Message
{
    public class MessagesRepository : GenericRepository<Messages>, IMessagesRepository
    {
        public MessagesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
