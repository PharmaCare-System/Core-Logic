using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Enums
{
    public enum SenderType
    {
        Order,
        Message,
        Inventory
    }
    public enum UserType
    {
        Customer,
        Pharmacist,
        Admin,
        Pharmacy
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
        BankTransfer,
        Cash
    }
}
