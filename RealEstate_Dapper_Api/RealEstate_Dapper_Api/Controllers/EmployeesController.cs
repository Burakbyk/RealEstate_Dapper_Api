using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.LocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {

            var values = await _employeeRepository.GetAllEmployeeAsync();

            return Ok(values);



        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {

            _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Çalışan kaydı oluşturuldu.");


        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {  
            _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Çalışan bilgisi güncellendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmploye(id);
            return Ok("Çalışan kaydı silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdEmployee(int id)
        { 

            var value = await _employeeRepository.GetEmployeeAsync(id);

            return Ok(value);

        }





    }
}
