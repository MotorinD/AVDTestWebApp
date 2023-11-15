using AVDTestWebApp.Models;

namespace AVDTestWebApp.Interfaces
{
    public interface ICheckConnectionService
    {
        /// <summary>
        /// Проверить подключение к домену
        /// </summary>
        /// <param name="domen">Домен или ip</param>
        /// <returns></returns>
        PingResult Ping(string domen);
    }
}
