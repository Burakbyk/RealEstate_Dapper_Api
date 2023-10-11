using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }


        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_statisticRepository.ActiveCategoryCount());
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_statisticRepository.ActiveEmployeeCount());
        }

        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            return Ok(_statisticRepository.ApartmentCount());
        }

        [HttpGet("AvgProductPriceByRent")]
        public IActionResult AvgProductPriceByRent()
        {
            return Ok(_statisticRepository.AvgProductPriceByRent());
        }



        [HttpGet("AvgProductPriceBySale")]
        public IActionResult AvgProductPriceBySale()
        {
            return Ok(_statisticRepository.AvgProductPriceBySale());
        }

        [HttpGet("AvgRoomCount")]
        public IActionResult AvgRoomCount()
        {
            return Ok(_statisticRepository.AvgRoomCount());
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_statisticRepository.CategoryCount());
        }

        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            return Ok(_statisticRepository.CategoryNameByMaxProductCount());
        }
    }
}
