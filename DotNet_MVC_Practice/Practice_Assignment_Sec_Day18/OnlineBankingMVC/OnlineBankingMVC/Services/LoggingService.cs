namespace OnlineBankingMVC.Services
{
    public class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}