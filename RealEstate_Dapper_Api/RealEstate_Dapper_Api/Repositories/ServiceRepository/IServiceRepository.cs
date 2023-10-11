using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultStatisticDto>> GetAllServiceAsync();

        void CreateService(CreateStatisticDto createServiceDto);

        void DeleteService(int id);

        void UpdateService(UpdateStatisticDto updateServiceDto);

        Task<GetByIdStatisticDto> GetServiceAsync(int id);
    }
}
