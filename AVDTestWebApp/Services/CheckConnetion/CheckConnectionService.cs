using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;

namespace AVDTestWebApp.Services.CheckConnetion
{
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

        /// <inheritdoc/>
        public PingResult Ping(string domain)
        {
            return _pingStrategy.Execute(domain);
        }
    }
}
