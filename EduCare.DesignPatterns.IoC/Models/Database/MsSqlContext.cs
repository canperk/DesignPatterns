namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class MsSqlContext : IDatabase
    {
        public string Connect()
        {
            return "MSSQL server in running";
        }
    }
}
