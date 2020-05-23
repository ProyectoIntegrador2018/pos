using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;
using System.IO;

namespace POS.Controllers
{
    [Route("api/pinSell")]
    [ApiController]
    public class PinSellControllers : ControllerBase 
    {
        /// <summary>
        /// Gets the dummy data for PinSellController request
        /// </summary>
        /// <returns>The response of the transaction</returns>
        [HttpPost]
        public string PostPinSellTransaction(PinSellRequest request)
        {
            //Should send the request to API and get response?

            //Dummy data of json response from API 
            var jsonString = @"{
                    ""ResponseCode"":""000"",
                    ""ResponseDescription"":""Pin Sell Succesful"",
                    ""TransactionID"":""123456789"",
                    ""RequestDateTime"":""2017-12-06 09:17:22"",
                    ""TransactionFee"":""0.10"",
                    ""Commission"":""0.10""
                }";
            // This is intended to simulate the deserialization and serialization of
            // the actual response from PagoFon.
            var response = JsonConvert.DeserializeObject<PinSellResponse>(jsonString);

            return JsonConvert.SerializeObject(response);
        }

    }    
}