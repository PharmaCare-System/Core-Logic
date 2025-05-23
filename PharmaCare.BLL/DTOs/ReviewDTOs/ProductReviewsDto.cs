using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.ReviewDTOs
{
    public class ProductReviewsDto
    {
        public string ProductName { get; set; }
        public List<ReviewReadDto> ProductReviews { get; set; }
    }
}
