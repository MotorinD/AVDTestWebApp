using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVDTestWebApp.Controllers
{
    /// <summary>
    /// Проверка подключений
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ICheckConnectionService _checkConnectionService;
        private readonly ILogger<PingController> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="checkConnectionService">Сервис проверки подключений</param>
        /// <param name="logger">Логгер</param>
        public PingController(ICheckConnectionService checkConnectionService, ILogger<PingController> logger)
        {
            _checkConnectionService = checkConnectionService;
            _logger = logger;
        }

        /// <summary>
        /// Проверка подключения к домену или ip с помощью утилиты Ping
        /// </summary>
        /// <param name="pingPostModel">Модель PingPostModel</param>
        /// <returns>Модель PingResult</returns>
        [HttpPost(Name = "Ping")]
        public IActionResult Post([FromBody] PingPostModel pingPostModel)
        {
            try
            {
                if(pingPostModel == null || pingPostModel.Domain == null 
                    || Uri.CheckHostName(pingPostModel.Domain) == UriHostNameType.Unknown)
                    return BadRequest();

                var res = _checkConnectionService.Ping(pingPostModel.Domain);

                return Ok(res);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Ошибка в Post методе Ping, полученный Domain: {pingPostModel.Domain} \n Ошибка: {ex}");
                return StatusCode(500, $"Ошибка на сервере");
            }
        }
    }
}
