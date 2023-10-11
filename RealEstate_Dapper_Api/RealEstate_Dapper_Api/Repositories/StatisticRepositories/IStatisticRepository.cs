

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        

        int CategoryCount();

        int ActiveCategoryCount();

        int PassiveCategoryCount();

        int ProductCount();

        int ApartmentCount();

        string EmployeNameByMaxProductCount();

        string CategoryNameByMaxProductCount();

        decimal AvgProductPriceByRent();

        decimal AvgProductPriceBySale();

        string CityNameByMaxProductCount();

        int DiffrentCityCount();

        decimal LastProductPrice();

        string NewestBuildingYear();

        string OldestBuildingYear();

        int AvgRoomCount();

        int ActiveEmployeeCount();


    }
}
