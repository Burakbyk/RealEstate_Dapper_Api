using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public  int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=1";
            using(var connection = _context.CreateConnection())
            {
            
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            
            
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Employee Where Status=1";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product Where Title like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

        public decimal AvgProductPriceByRent()
        {
            string query = " Select AVG(Price) From Product Where Type = 'Kiralık' ";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;


            }
        }

        public decimal AvgProductPriceBySale()
        {
            string query = " Select AVG(Price) From Product Where Type = 'Satılık' ";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;


            }
        }

        public int AvgRoomCount()
        {
            string query = " Select AVG(RoomCount) from ProductDetails ";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

        public int CategoryCount()
        {
            string query = " Select Count(*) from Category";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<string>(query);
                return value;

                
            }
        }

        public string CityNameByMaxProductCount()
        {
            throw new NotImplementedException();
        }

        public int DiffrentCityCount()
        {
            throw new NotImplementedException();
        }

        public string EmployeNameByMaxProductCount()
        {
            throw new NotImplementedException();
        }

        public decimal LastProductPrice()
        {
            throw new NotImplementedException();
        }

        public string NewestBuildingYear()
        {
            throw new NotImplementedException();
        }

        public string OldestBuildingYear()
        {
            throw new NotImplementedException();
        }

        public int PassiveCategoryCount()
        {
            throw new NotImplementedException();
        }

        public int ProductCount()
        {
            throw new NotImplementedException();
        }

      
    }
}
