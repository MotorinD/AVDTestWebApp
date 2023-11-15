using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVDTestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ICheckConnectionService _checkConnectionService;
        private readonly ILogger<PingController> _logger;

        public PingController(ICheckConnectionService checkConnectionService, ILogger<PingController> logger)
        {
            _checkConnectionService = checkConnectionService;
            _logger = logger;
        }

        [HttpPost(Name = "Ping")]
        public IActionResult Post([FromBody] PingPostModel pingPostModel)
        {
            try
            {
                var res = _checkConnectionService.Ping(pingPostModel.Domen);

                return Ok(res);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Ошибка в Post методе Ping: {ex}");
                return StatusCode(500, $"Ошибка на сервере: {ex}");
            }
        }
    }
}
