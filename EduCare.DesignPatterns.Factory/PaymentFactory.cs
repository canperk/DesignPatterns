using EduCare.DesignPatterns.Factory.Base;
using EduCare.DesignPatterns.Factory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.Factory
{
    public class PaymentFactory
    {
        public IPayment GetPayment(PaymentType type)
        {
            IPayment payment = null;
            switch (type)
            {
                case PaymentType.CreditCard:
                    payment = new CreditCard();
                    break;
                case PaymentType.Cash:
                    payment = new Cash();
                    break;
                case PaymentType.BankTransfer:
                    payment = new BankTransfer();
                    break;
                case PaymentType.Paypal:
                    payment = new PayPal();
                    break;
            }
            return payment;
        }
    }
}
