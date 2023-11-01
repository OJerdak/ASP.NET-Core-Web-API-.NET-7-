using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.DTO;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();

            //Get All Regions from Web API
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("http://localhost:5252/api/Regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

            }
            catch (Exception)
            {

                throw;
            }

            return View(response);
        }
    }
}
