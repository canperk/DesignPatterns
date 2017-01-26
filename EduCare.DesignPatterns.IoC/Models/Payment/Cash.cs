using System;

namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class Cash : IPayment
    {
        public double Limit { get; set; }

        public int UsageCount { get; set; }

        public string SendMoney(double amount)
        {
            return $"Payment is cash. Amount : {amount}";
        }
    }
}
