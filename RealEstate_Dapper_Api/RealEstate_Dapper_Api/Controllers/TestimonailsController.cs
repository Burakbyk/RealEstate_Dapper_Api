using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonailsController : ControllerBase
    {
        private readonly ITestimonialRepository _testimoailRepository;

        public TestimonailsController(ITestimonialRepository testimoailRepository)
        {
            _testimoailRepository = testimoailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var values = await _testimoailRepository.GetAllTestimonialsAsync();

            return Ok(values);

        }

    }
}
