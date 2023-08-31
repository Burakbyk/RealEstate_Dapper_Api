using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultServicesComponentPartial : ViewComponent
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultServicesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7125/api/Service");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await  responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                ViewBag.serviceID = value.Select(x=>x.ServiceID).FirstOrDefault();
                ViewBag.serviceName = value.Select(x=>x.ServiceName).FirstOrDefault();
                ViewBag.serviceStatus = value.Select(x=>x.ServiceStatus).FirstOrDefault();
                return View();

            
            }

            return View();
        }

    }
}
