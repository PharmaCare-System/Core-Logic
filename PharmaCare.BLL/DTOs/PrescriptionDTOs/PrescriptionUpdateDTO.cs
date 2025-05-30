﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;

namespace PharmaCare.BLL.DTOs.PrescriptionDTOs
{
    public class PrescriptionUpdateDTO
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public PrescriptionStatus Status { get; set; }

        public string Image { get; set; }

    }
}
