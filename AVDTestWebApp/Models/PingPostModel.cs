namespace AVDTestWebApp.Models
{
    /// <summary>
    /// Модель для проверки подключения к домену или ip
    /// </summary>
    public class PingPostModel
    {
        /// <summary>
        /// Домен или ip
        /// </summary>
        public string? Domain { get; set; }
    }
}
