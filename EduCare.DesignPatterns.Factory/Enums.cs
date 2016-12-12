using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Factory
{
    public enum PaymentType
    {
        NotSet = 0,
        CreditCard = 1,
        Cash = 2,
        BankTransfer = 3,
        Paypal = 4
    }
}
