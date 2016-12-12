using System;
using EduCare.DesignPatterns.Factory.Base;

namespace EduCare.DesignPatterns.Factory.Models
{
    class Cash : IPayment
    {
        public void Cancel()
        {
            
        }

        public bool Pay(decimal amount)
        {
            return PayMoney(amount);
        }

        private bool PayMoney(decimal amount)
        {
            //imagine that you have paid cash money
            return true;
        }
    }
}
