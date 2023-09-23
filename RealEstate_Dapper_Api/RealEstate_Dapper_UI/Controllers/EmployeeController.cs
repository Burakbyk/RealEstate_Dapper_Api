using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
      

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7125/api/Employees");

            if(responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(values);

            }


            return View();
        }


        [HttpGet]
        public IActionResult CreateEmployee()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var uploadLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmployeeImages", imageName);

                using (var stream = new FileStream(uploadLocation, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Yükleme başarılıysa, yeni yolu hazırlayın
                var imageUrl = "/EmployeeImages/" + imageName;

                // CreateEmployeeDto nesnesini güncelleyin
                createEmployeeDto.ImageUrl = imageUrl;
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEmployeeDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7125/api/Employees", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7125/api/Employees/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();


        }


        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7125/api/Employees/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
            
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
                return View(value);
            
            }



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var uploadLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmployeeImages", imageName);

                using (var stream = new FileStream(uploadLocation, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Yükleme başarılıysa, yeni yolu hazırlayın
                var newImageUrl = "/EmployeeImages/" + imageName;

                // Veritabanında kaydedilecek yeni yolu güncelleyin
                updateEmployeeDto.ImageUrl = newImageUrl;
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEmployeeDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7125/api/Employees/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
