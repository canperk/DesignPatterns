namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class MongoContext : IDatabase
    {
        public string Connect()
        {
            return "No-SQL structure is online";
        }
    }
}
