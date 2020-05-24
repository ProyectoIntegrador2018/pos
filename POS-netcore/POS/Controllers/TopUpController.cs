using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/TopUp")]
    [ApiController]
    public class TopUpController : ControllerBase 
    {
        /// <summary>
        /// Gets the dummy data for ProductsController GET request
        /// </summary>
        /// <returns>The list of dummy products</returns>
        [HttpPost]
        public string topUpSend(TopUpRequest request)
        {

            pagoFonApi topUp = new pagoFonApi();

            var result = topUp.TopUp(request.ProductCode, request.TxReference, request.Amount, request.LoginPin, request.Email, request.Ani);            
            var response = JsonConvert.DeserializeObject<TopUpResponse>(result);

            return JsonConvert.SerializeObject(response);
        }
    }
    
}