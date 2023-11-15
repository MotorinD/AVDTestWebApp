using AVDTestWebApp.Models;

namespace AVDTestWebApp.Interfaces
{
    /// <summary>
    /// Сервис проверки подключений
    /// </summary>
    public interface ICheckConnectionService
    {
        /// <summary>
        /// Проверить подключение к домену
        /// </summary>
        /// <param name="domain">Домен или ip</param>
        /// <returns></returns>
        PingResult Ping(string domain);
    }
}
