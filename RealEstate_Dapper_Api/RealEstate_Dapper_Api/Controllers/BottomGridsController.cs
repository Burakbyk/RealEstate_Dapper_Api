using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _buttomGridRepository;

        public BottomGridsController(IBottomGridRepository buttomGridRepository)
        {
            _buttomGridRepository = buttomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBottomGrid()
        {

            var values = await _buttomGridRepository.GetAllButtomGridAsync();

            return Ok(values);






        }







    }
}
