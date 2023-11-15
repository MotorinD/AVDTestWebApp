using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVDTestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        ICheckConnectionService _checkConnectionService;
        public PingController(ICheckConnectionService checkConnectionService)
        {
            _checkConnectionService = checkConnectionService;
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
                return StatusCode(500, $"Ошибка на сервере: {ex}");
            }
        }
    }
}
