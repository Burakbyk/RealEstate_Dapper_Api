
using RealEstate_Dapper_Api.Dtos.LocationDtos;



namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public interface ILocationRepository
    {


        Task<List<ResultLocationDto>> GetAllLocationAsync();

        void CreateLocation(CreateLocationDto createLocationDto);

        void DeleteLocation(int id);

        void UpdateLocation(UpdateLocationDto updateLocationDto);

        Task<GetByIdLocationDto> GetLocationAsync(int id);






    }
}
