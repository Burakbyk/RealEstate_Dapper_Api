using Dapper;
using RealEstate_Dapper_Api.Dtos.LocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public class LocationRepository : ILocationRepository
    {
       private readonly Context _context;

        public LocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreateLocation(CreateLocationDto createLocationDto)
        {
            string query = "Insert Into Location (CityName,CountryName,HowManyEstateIn,LocationImage) values(@cityName,@countryName,@howManyEstateIn,@locationImage)";


            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createLocationDto.CityName);
            parameters.Add("countryName",createLocationDto.CountryName);
            parameters.Add("@howManyEstateIn", createLocationDto.HowManyEstateIn);
            parameters.Add("@locationImage", createLocationDto.LocationImage);

            using(var connection = _context.CreateConnection())
            {
            
                await connection.ExecuteAsync(query, parameters);

            
            }


        }

        public async void DeleteLocation(int id)
        {

            string query = "Delete From Location Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);

            using(var connection = _context.CreateConnection())
            { 
            
                await connection.ExecuteAsync(query, parameters);

            
            }


        }

        public async Task<List<ResultLocationDto>> GetAllLocationAsync()
        {
            string query = "Select * From Location";

            using(var connection = _context.CreateConnection())
            {
            

                var values = await connection.QueryAsync<ResultLocationDto>(query); 
                return values.ToList();

            
            }



        }

        public async Task<GetByIdLocationDto> GetLocationAsync(int id)
        {
            string query = "Select * From Location Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);

            using(var connection = _context.CreateConnection())
            {
              var value = await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query,parameters);
               return value;
                
            }

        }

        public async void UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            string query = "Update Location Set CityName=@cityName,CountryName=@countryName,HowManyEstateIn=@howManyEstateIn,LocationImage=@locationImage Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updateLocationDto.CityName);
            parameters.Add("@countryName", updateLocationDto.CountryName);
            parameters.Add("@howManyEstateIn", updateLocationDto.HowManyEstateIn);
            parameters.Add("@locationImage", updateLocationDto.LocationImage);
            parameters.Add("@locationID", updateLocationDto.LocationID);

            using(var connection = _context.CreateConnection())
            {
            
                await connection.ExecuteAsync(query,parameters);
            
            }

        }
    }
}
