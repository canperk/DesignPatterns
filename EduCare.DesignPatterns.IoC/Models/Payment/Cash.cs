namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class Cash : IPayment
    {
        public string SendMoney(double amount)
        {
            return $"Payment is cash. Amount : {amount}";
        }
    }
}
