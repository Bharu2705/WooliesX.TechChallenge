using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WooliesX.Model;
using WoooliesX.Service;

namespace WooliesX.UnitTest.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _userService;

        [TestInitialize]
        public void Initialize()
        {
            var userResponse = new User() { Name = "Bharathi R", Token = "sample token" };
            //arrange
            _userService = Substitute.For<IUserService>();
            _userService.GetUserResponse().Returns(userResponse);
        }

        [TestMethod]
        public void UserReponseService_GetUser()
        {
            //act
            var response = _userService.GetUserResponse();

            //assert
            Assert.AreEqual("Bharathi R", response.Name);
            Assert.AreEqual("sample token", response.Token);
        }

    } 
}
