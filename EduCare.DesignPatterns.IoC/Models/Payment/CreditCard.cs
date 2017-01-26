
using System;

namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class CreditCard : IPayment
    {
        public double Limit { get; set; }

        public int UsageCount { get; set; }

        public string SendMoney(double amount)
        {
            return $"Money transfered via password secured credit card system. Amount : {amount}";
        }
    }
}
