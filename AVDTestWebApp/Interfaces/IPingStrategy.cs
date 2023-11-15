using AVDTestWebApp.Models;

namespace AVDTestWebApp.Interfaces
{
    /// <summary>
    /// Способ проверки подключения
    /// </summary>
    public interface IPingStrategy
    {
        PingResult Execute(string domen);
    }
}
