using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LocationDtos;
using RealEstate_Dapper_Api.Repositories.LocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {

            var values = await _locationRepository.GetAllLocationAsync();

            return Ok(values);



        }


        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {

              _locationRepository.CreateLocation(createLocationDto);
              return Ok("Lokasyon Oluşturuldu.");


        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            _locationRepository.UpdateLocation(updateLocationDto);
            return Ok("Lokasyon Güncellendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            _locationRepository.DeleteLocation(id);
            return Ok("Lokasyon Silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdLocation(int id)
        {

            var value = await _locationRepository.GetLocationAsync(id);

            return Ok(value);

        }

    }
}
