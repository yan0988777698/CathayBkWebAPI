using CathayBkWebAPI.DataAccess;
using CathayBkWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel;


namespace CathayBkWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BTCController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly MyDbcentext _myDbcentext;

        public BTCController(IHttpClientFactory httpClientFactory,MyDbcentext myDbcentext)
        {
            _httpClient = httpClientFactory.CreateClient();
            _myDbcentext = myDbcentext;
        }

        [HttpGet(Name = "GetBTCPrice")]
        public async Task<IActionResult> Get()
        {
            var requestUrl = "https://api.coindesk.com/v1/bpi/currentprice.json";
            var response = await _httpClient.GetAsync(requestUrl);
            var data = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(data);
            BTCPrice currentBTCPrice = new ()
            {
                UpdateTime = json["time"]["updatedISO"].Value<DateTime>(),
                USDRate = json["bpi"]["USD"]["rate"].Value<double>(),
                GBPRate = json["bpi"]["GBP"]["rate"].Value<double>(),
                EURRate = json["bpi"]["EUR"]["rate"].Value<double>()
            };

            _myDbcentext.BTCPrices.Add(currentBTCPrice);
            _myDbcentext.SaveChanges();
            return Ok();
        }
    }
}
