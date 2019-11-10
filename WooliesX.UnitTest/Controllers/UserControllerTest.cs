using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WooliesX.TechChallenge.Controllers;
using WoooliesX.Service;

namespace WooliesX.UnitTest
{
    [TestClass]
    public class UserControllerTest
    {
        private IUserService _userService;
        private UserController _userController;

        [TestInitialize]
        public void Initialize()
        {
            _userService = Substitute.For<IUserService>();
            _userService.GetUserResponse().Returns(new Model.User() { Name = "Bharu", Token = "abc" });
            _userController = Substitute.ForPartsOf<UserController>(_userService);

        }

        [TestMethod]
        public void UserController_ReturnsOk()
        {
            var controllerResponse = _userController.GetUser() as OkObjectResult;
            var okResult = controllerResponse as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}
