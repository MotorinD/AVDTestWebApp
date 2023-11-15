using AVDTestWebApp.Controllers;
using AVDTestWebApp.Models;
using AVDTestWebApp.Services.CheckConnetion;
using AVDTestWebApp.Services.CheckConnetion.PingStrategy;
using Microsoft.AspNetCore.Mvc;

namespace AVDTestWebApp.Tests.ControllersTests
{
    public class PingControllerTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("qwe@eee")]
        public void PingBadRequestCheck(string domain)
        {
            var controller = new PingController(new CheckConnectionService(new PingWithDotNetUtill()), null);
            var model = new PingPostModel { Domain = domain};
            var response = controller.Post(model);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PingLocalhostSuccessCheck()
        {
            var controller = new PingController(new CheckConnectionService(new PingWithDotNetUtill()), null);
            var postModel = new PingPostModel { Domain = "localhost" };

            var actionResult = controller.Post(postModel);

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            var resultModel = Assert.IsType<PingResult>(okObjectResult.Value);

            Assert.Equal(true, resultModel.IsSuccess);
        }
    }
}
