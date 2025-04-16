﻿using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace PharmaCare.DAL.Models
{
    public class Purchase
    {
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
    
}
