using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;

namespace PharmaCare.BLL.DTOs.PrescriptionDTOs
{
    public class PrescriptionAddDTO
    {

        public DateTime UploadDate { get; set; }
        public PrescriptionStatus Status { get; set; }

        public byte[] Image { get; set; }


    }
}
