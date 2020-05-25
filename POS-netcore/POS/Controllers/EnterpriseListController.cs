using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/enterpriseList")]
    [ApiController]
    public class EnterpriseListController : ControllerBase 
    {
        /// <summary>
        /// Gets the dummy data for EnterpriseListController GET request
        /// </summary>
        /// <returns>The list of dummy companies</returns>
        [HttpGet]
        public string Get()
        {
            //Makes API call with data

            var jsonString = @"{
                ""ResponseCode"":""000"",
                ""ResponseData"":""[]"",
                ""ResponseDescription"":""Enterprise list success"",
            }";

            // This is intended to simulate the deserialization and serialization of
            // the actual response from PagoFon.
            var response = JsonConvert.DeserializeObject<EnterpriseListResponse>(jsonString);

            return JsonConvert.SerializeObject(response);
        }
    }
    
}