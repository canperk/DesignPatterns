using System;

namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class Transfer : IPayment
    {
        public double Limit { get; set; }

        public int UsageCount { get; set; }

        public string SendMoney(double amount)
        {
            return $"Bank transfer method has been reached. Amount : {amount}";
        }
    }
}
