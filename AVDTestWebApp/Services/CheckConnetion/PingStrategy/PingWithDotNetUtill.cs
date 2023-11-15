using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;
using System.Net.NetworkInformation;

namespace AVDTestWebApp.Services.CheckConnetion.PingStrategy
{
    /// <summary>
    /// Проверка подкючения к домену с помощью .Net.NetworkInformation.Ping 
    /// </summary>
    public class PingWithDotNetUtill : IPingStrategy
    {
        /// <summary>
        /// Выполнить проверку подключения с помощью .Net.NetworkInformation.Ping 
        /// </summary>
        /// <param name="domain">Домен или ip</param>
        /// <returns>Модель PingResult</returns>
        public PingResult Execute(string domain)
        {
            PingResult pingResult;

            try
            {
                using (var ping = new Ping())
                {
                    var pingReply = ping.Send(domain);
                    pingResult = GetResultFromReply(pingReply);
                }
            }
            catch (PingException ex)
            {
                pingResult = new PingResult
                {
                    IsSuccess = false,
                    Text = $"Не удалось подключиться: {ex.InnerException?.Message ?? ex.Message}"
                };
            }

            return pingResult;
        }

        private PingResult GetResultFromReply(PingReply pingReply)
        {
            if (pingReply == null)
                throw new ArgumentNullException("pingReply");

            var pingResult = new PingResult();

            switch (pingReply.Status)
            {
                case IPStatus.Success:
                    pingResult.IsSuccess = true;
                    pingResult.Text = "Подключение доступно";
                    break;

                default:
                    pingResult.IsSuccess = false;
                    pingResult.Text = "Подключение не доступно";
                    break;
            }

            return pingResult;
        }
    }
}
