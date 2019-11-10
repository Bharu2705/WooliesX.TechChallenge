using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using WooliesX.Model;
using WoooliesX.Service;

namespace WooliesX.TechChallenge.Controllers
{
    /// <summary>
    /// controller for computing trolley total
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class TrolleyTotalController : ControllerBase
    {
        private readonly ITrolleyService _trolleyService;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Dependency injection for troller controller
        /// </summary>
        /// <param name="trolleyService"></param>
        public TrolleyTotalController(ITrolleyService trolleyService)
        {
            _trolleyService = trolleyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TrolleyRequest request)
        {
            try
            {
                var response = await _trolleyService.TrolleyTotal(request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                logger.Error(ex, "Unable to retrieve total trolley details");
            }

            return new BadRequestResult();
        }
    }
}