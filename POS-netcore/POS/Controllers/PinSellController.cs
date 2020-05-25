using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

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
            pagofonAPI api = new pagofonAPI();
            
            var jsonString = api.PinSell(request.ProductCode, request.VoucherData, request.Amount, request.MPin, request.Email, request.ANI);

            var response = JsonConvert.DeserializeObject<PinSellResponse>(jsonString);
            
            return JsonConvert.SerializeObject(response);
        }

    }    
}