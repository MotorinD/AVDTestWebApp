using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;

namespace AVDTestWebApp.Services.CheckConnetion
{
    /// <summary>
    /// Сервис проверки подключения к домену
    /// </summary>
    public class CheckConnectionService : ICheckConnectionService
    {
        private readonly IPingStrategy _pingStrategy;
        public CheckConnectionService(IPingStrategy pingStrategy)
        {
            _pingStrategy = pingStrategy;
        }

        public PingResult Ping(string domen)
        {
            return _pingStrategy.Execute(domen);
        }
    }
}
