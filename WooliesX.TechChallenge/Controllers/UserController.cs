using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using WoooliesX.Service;

namespace WooliesX.TechChallenge.Controllers
{
    /// <summary>
    /// Controller for user response
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userResponse;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Dependency injection for User controller
        /// </summary>
        /// <param name="userResponse"></param>
        public UserController(IUserService userResponse)
        {
            _userResponse = userResponse;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var response = _userResponse.GetUserResponse();
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Unable to retrieve the products");
                return new BadRequestResult();
            }
        }
    }
}