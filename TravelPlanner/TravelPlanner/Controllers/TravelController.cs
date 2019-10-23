using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TravelPlanner.Controllers
{
    [ApiController]
    [Route("api/travelPlan")]
    public class TravelController : ControllerBase
    {
        private HttpClient client;

        public TravelController(IHttpClientFactory factory)
        {
            this.client = factory.CreateClient("TravelPlan");
        }


        [HttpGet]
        public async Task<ActionResult<ResultTravel>> Get([FromQuery] string from, [FromQuery] string to, [FromQuery] string start)
        {
            var travelPlanResponse = await client.GetAsync("travelPlan.json");
            travelPlanResponse.EnsureSuccessStatusCode();
            var responseBody = await travelPlanResponse.Content.ReadAsStringAsync();
            var travelPlans = JsonSerializer.Deserialize<List<Travel>>(responseBody);

            ConnectionFinder cf = new ConnectionFinder(travelPlans);
            var resTravel = cf.FindConnection(from, to, start);
            if(resTravel == null)
            {
                return NotFound();
            }

            return resTravel;
        }
    }
}
