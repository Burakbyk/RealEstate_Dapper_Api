using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private string baseUrl = "https://localhost:7125";
       

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region Statistics1
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{baseUrl}/api/Statistic/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion

            #region Statistics2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync($"{baseUrl}/api/Statistic/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion

            #region Statistics3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync($"{baseUrl}/api/Statistic/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion

            #region Statistics4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync($"{baseUrl}/api/Statistic/AvgProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion

            #region Statistics5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync($"{baseUrl}/api/Statistic/AvgProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData5;
            #endregion

            #region Statistics6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync($"{baseUrl}/api/Statistic/AvgRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.avereageRoomCount = jsonData6;
            #endregion

            #region Statistics7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync($"{baseUrl}/api/Statistic/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData7;
            #endregion

            #region Statistics8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync($"{baseUrl}/api/Statistic/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData8;
            #endregion

            return View();
        }
    }
}
