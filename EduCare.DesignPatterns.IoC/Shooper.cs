using EduCare.DesignPatterns.IoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.IoC
{
    public class Shooper
    {
        private IPayment _payment;
        public Shooper(IPayment payment)
        {
            _payment = payment;
        }

        public string Charge(double value)
        {
            _payment.UsageCount++;
            return _payment.SendMoney(value);
        }

        public double GetUsage()
        {
            return _payment.UsageCount;
        }
    }
}
