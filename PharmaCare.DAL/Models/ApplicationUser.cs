using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? CreatedById { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? DeletedById { get; set; }
        public string? DeletedByName { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
