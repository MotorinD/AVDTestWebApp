using AVDTestWebApp.Controllers;
using AVDTestWebApp.Models;
using AVDTestWebApp.Services.CheckConnetion;
using AVDTestWebApp.Services.CheckConnetion.PingStrategy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace AVDTestWebApp.Tests.ControllersTests
{
    public class PingControllerTest
    {
        private readonly PingController _pingController;
        public PingControllerTest()
        {
            var mockLogger = new Mock<ILogger<PingController>>();
            _pingController = new PingController(new CheckConnectionService(new PingWithDotNetUtill()), mockLogger.Object);
        }

        [Fact]
        public void PingBadRequestPostModelCheck()
        {
            var response = _pingController.Post(null);

            Assert.IsType<BadRequestResult>(response);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("qwe@eee")]
        public void PingBadRequestDomainCheck(string domain)
        {
            var postModel = new PingPostModel { Domain = domain};
            var response = _pingController.Post(postModel);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PingLocalhostSuccessCheck()
        {
            var postModel = new PingPostModel { Domain = "localhost" };
            var actionResult = _pingController.Post(postModel);

            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            var resultModel = Assert.IsType<PingResult>(okObjectResult.Value);

            Assert.Equal(true, resultModel.IsSuccess);
        }
    }
}
