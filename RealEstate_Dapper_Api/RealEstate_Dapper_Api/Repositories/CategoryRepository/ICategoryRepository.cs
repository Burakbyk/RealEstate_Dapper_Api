using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultLocationDto>> GetAllCategoryAsync();

        void CreateCategory(CreateCategoryDto categoryDto);

        void DeleteCategory(int id);

        void UpdateCategory(UpdateCategoryDto categoryDto);

        Task<GetByIdCategoryDto> GetCategoryAsync(int id);
        

    }
}
