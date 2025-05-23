using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models.UserNotifications;
namespace PharmaCare.DAL.Models.UserMessages
{
    public abstract class Messages :  BaseEntity
    {
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }  

        // Sender may be Pharmacist or Customer
        public UserType UserType { get; set; }

        public int? ChatId { get; set; }
        public virtual Chat? Chat { get; set; }

    }
}
