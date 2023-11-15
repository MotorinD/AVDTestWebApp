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
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pingStrategy">Реализация способа проверки подключения</param>
        public CheckConnectionService(IPingStrategy pingStrategy)
        {
            _pingStrategy = pingStrategy;
        }

        /// <summary>
        /// Проверить подключение к домену или ip
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public PingResult Ping(string domain)
        {
            return _pingStrategy.Execute(domain);
        }
    }
}
