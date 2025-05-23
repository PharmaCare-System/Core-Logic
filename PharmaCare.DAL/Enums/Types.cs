using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Enums
{
    public enum SenderType
    {
        Order=1,
        Message=2,
        Inventory=3
    }
    public enum UserType
    {
        Customer=1,
        Pharmacist=2,
        Admin=3,
        Pharmacy=4
    }
    public enum OrderTypes
    {
        Retail=1,
        Bulk = 2
    }
    public enum PaymentType
    {
        CreditCard = 1,
        DebitCard = 2,
        PayPal=3,
        BankTransfer=4,
        Cash=5
    }
}
