using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.PharmacistDTOs
{
    public class PharmacistAddDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;


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



        public int PharmacyId { get; set; }
 
        public int ManagerPharmacistId { get; set; }
    }
}
