using System;
using EduCare.DesignPatterns.Factory.Base;

namespace EduCare.DesignPatterns.Factory.Models
{
    class CreditCard : IPayment
    {
        public void Cancel()
        {
            
        }

        public bool Pay(decimal amount)
        {
            return UseCreditForPayment(amount);
        }

        private bool UseCreditForPayment(decimal amount)
        {
            //imagine that you have started 3D security operation to pay money
            return true;
        }
    }
}
