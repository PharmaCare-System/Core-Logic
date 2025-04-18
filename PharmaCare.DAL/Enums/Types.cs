using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Enums
{
    public enum SenderType
    {
        order = 1,
        message = 2,
        other = 3,
    }
    public enum UserType
    {
        Customer,
        Pharmacist,
        Admin
    }
    public enum OrderTypes
    {
        Retail,
        Bulk
    }
    public enum PaymentType
    {
        CreditCard,
        DebitCard,
        PayPal,
        BankTransfer
    }
}
