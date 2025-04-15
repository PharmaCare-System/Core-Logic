using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Models
{
    public class Pharmacist
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }


        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;

                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }

        }
        public string Password { get; set; }

        public string Address { get; set; }


        public int PharmacyId { get; set; }

        public ICollection<Message>? messages { get; set; }
        public ICollection<Chat>? Chats { get; set; }

        public ICollection<Prescription>? Prescriptions { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public Pharmacy? pharmacy { get; set; }
        public Pharmacist? ManagerPharmacist { get; set; }
        public ICollection<Pharmacist>? Pharmacists { get; set; }
        public Pharmacy? Pharmacy { get; set; }
        public int ManagerPharmacistId { get; set; }

    }
}
