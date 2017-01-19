
namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class CreditCard : IPayment
    {
        public string SendMoney(double amount)
        {
            return $"Money transfered via password secured credit card system. Amount : {amount}";
        }
    }
}
