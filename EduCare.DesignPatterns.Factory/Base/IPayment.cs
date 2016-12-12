namespace EduCare.DesignPatterns.Factory.Base
{
    public interface IPayment
    {
        bool Pay(decimal amount);
        void Cancel();
    }
}
