namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class OracleContext : IDatabase
    {
        public string Connect()
        {
            return "Connected to Oracle database";
        }
    }
}
