using System;
using EduCare.DesignPatterns.Factory.Base;

namespace EduCare.DesignPatterns.Factory.Models
{
    public class BankTransfer : IPayment
    {
        public void Cancel()
        {
            
        }

        public bool Pay(decimal amount)
        {
            return SendMoneyViaBankAccount(amount);
        }

        private bool SendMoneyViaBankAccount(decimal amount)
        {
            //imagine that you have transferred money via bank account or IBAN number
            return true;
        }
    }
}
