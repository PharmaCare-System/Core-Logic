using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.PharmacistDTOs
{
    public class PharmacistChatsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<PharmacistChatMessageDTO> Messages { get; set; }
    }
}
