﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Payment
{
    public interface IPaymentRepository : IGenericRepository<DAL.Models.Payment>
    {
    }
}
