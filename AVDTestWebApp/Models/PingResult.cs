using System.Net.NetworkInformation;

namespace AVDTestWebApp.Models
{
    /// <summary>
    /// Модель с информацией о попытке подключения к домену
    /// </summary>
    public class PingResult
    {
        /// <summary>
        /// Описание результата проверки подключения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Подключение успешно
        /// </summary>
        public bool? IsSuccess { get; set; }
    }
}
