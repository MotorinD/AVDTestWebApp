using AVDTestWebApp.Models;

namespace AVDTestWebApp.Interfaces
{
    /// <summary>
    /// Способ проверки подключения к домену или ip
    /// </summary>
    public interface IPingStrategy
    {
        /// <summary>
        /// Выполнить метод проверки подключения к домену или ip
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        PingResult Execute(string domain);
    }
}
