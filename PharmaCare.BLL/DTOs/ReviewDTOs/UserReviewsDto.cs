using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.ReviewDTOs
{
    public class UserReviewsDto
    {

        public int userID { get; set; }
        public string userName { get; set; }

         public List<ReviewReadDto> UserReviews { get; set; } 



    }
}
