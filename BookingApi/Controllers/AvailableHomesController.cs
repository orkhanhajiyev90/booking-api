using Microsoft.AspNetCore.Mvc;
using BookingApi.Business.Abstract;
using BookingApi.Core.Models.Request;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailableHomesController : Controller
    {
        private readonly IHomeService _homeService;
        public AvailableHomesController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAvailableHomes([FromQuery] DateRangeRequest request)
        {
            return Ok(await _homeService.GetAvailableHomeAsync(request.StartDate, request.EndDate));
        }
    }
}
