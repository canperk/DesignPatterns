namespace EduCare.DesignPatterns.Strategy
{
    public class Logger
    {
        private ILogger _logger;
        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void Save(string text)
        {
            _logger.Save(text);
        }
    }
}
