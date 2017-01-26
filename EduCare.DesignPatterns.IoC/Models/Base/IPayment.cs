namespace EduCare.DesignPatterns.IoC.Models
{
    public interface IPayment
    {
        string SendMoney(double amount);
        int UsageCount { get; set; }
        double Limit { get; set; }
    }
}
