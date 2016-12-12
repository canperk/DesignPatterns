using EduCare.DesignPatterns.Factory.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Factory.Models
{
    public class PayPal : IPayment
    {
        public void Cancel()
        {
            
        }

        public bool Pay(decimal amount)
        {
            return SendMoney(amount);
        }

        private bool SendMoney(decimal amount)
        {
            //imagine that money will be sent via paypal
            return true;
        }
    }
}
