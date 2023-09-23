using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
           
                string query = "Insert Into Employee ([Name],[Title],[Mail],[PhoneNumber],[ImageUrl],[Status]) values (@Name,@Title,@Mail,@PhoneNumber,@ImageUrl,@Status)";

                using (var connection = _context.CreateConnection())
                {


                    await connection.ExecuteAsync(query, createEmployeeDto);

                    

                }
                                          
            
        }

        public async void DeleteEmploye(int id)
        {
          
                string query = "Delete From Employee Where [EmployeeID]=@id";

                using (var connection = _context.CreateConnection())
                {

                    await connection.ExecuteAsync(query, new { id });



                }

            

          

        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {

           
                string query = "Select * From Employee";

                using (var connection = _context.CreateConnection())
                {

                    var values = await connection.QueryAsync<ResultEmployeeDto>(query);

                    return values.ToList();

                }
            
          
        }

        public async Task<GetByIdEmployeeDto> GetEmployeeAsync(int id)
        {
            string query = "Select * From Employee Where [EmployeeID] = @id";

            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query,new {id});
                return value;
            }


        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = $"Update Employee Set [Name]=@Name,[Title]=@Title,[Mail]=@Mail,[PhoneNumber]=@PhoneNumber,[ImageUrl]=@ImageUrl,[Status]=@Status Where [EmployeeID]={updateEmployeeDto.EmployeeID} ";

            using(var connection = _context.CreateConnection())
            {

               
                    await connection.ExecuteAsync(query, updateEmployeeDto);
                
              
             

            }


        }
    }
}
