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
            string query = "Select Top(1)City,COUNT(*) as 'product_count' From Product Group By City order by product_count Desc";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<string>(query);
                return value;


            }
        }

        public int DiffrentCityCount()
        {
            string query = "Select COUNT(Distinct(City)) From Product";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

        public string EmployeNameByMaxProductCount()
        {
            string query = "Select Name,Count(*) 'product_count' From Product Inner Join Employee on Product.EmployeeID=Employee.EmployeeID Group By Name Order By product_count";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<string>(query);
                return value;


            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price From Product  Order By ProductID desc";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;


            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails  Order By BuildYear desc";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<string>(query);
                return value;


            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails  Order By BuildYear asc";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<string>(query);
                return value;


            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {

                var value = connection.QueryFirstOrDefault<int>(query);
                return value;


            }
        }

      
    }
}
