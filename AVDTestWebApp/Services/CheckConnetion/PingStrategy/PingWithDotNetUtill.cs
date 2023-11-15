using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace AVDTestWebApp.Services.CheckConnetion.PingStrategy
{
    /// <summary>
    /// Проверка подкючения к домену с помощью .Net.NetworkInformation.Ping 
    /// </summary>
    public class PingWithDotNetUtill : IPingStrategy
    {
        public PingResult Execute(string domen)
        {
            PingResult pingResult;

            try
            {
                var pingReply = new Ping().Send(domen);
                pingResult = GetResultFromReply(pingReply);
            }
            catch (PingException ex)
            {
                pingResult = new PingResult
                {
                    IsSuccess = false,
                    Text = $"Не удалось подключиться, ошибка: {ex.InnerException?.Message ?? ex.Message}"
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
