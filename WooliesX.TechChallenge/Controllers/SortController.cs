using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoooliesX.Service;
using NLog;

namespace WooliesX.TechChallenge.Controllers
{
    /// <summary>
    /// Sort controller 
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly ISortService _sortService;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// DI for sort controller
        /// </summary>
        /// <param name="sortService"></param>
        public SortController(ISortService sortService)
        {
            _sortService = sortService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sortOption)
        {
            try
            {
                var response = await _sortService.SortProducts(sortOption);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                logger.Error(ex, "Unable to retrieve the products");
                return new BadRequestResult();
            }
        }
    }
}