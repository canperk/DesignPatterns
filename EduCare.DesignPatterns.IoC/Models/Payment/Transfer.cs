namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class Transfer : IPayment
    {
        public string SendMoney(double amount)
        {
            return $"Bank transfer method has been reached. Amount : {amount}";
        }
    }
}
