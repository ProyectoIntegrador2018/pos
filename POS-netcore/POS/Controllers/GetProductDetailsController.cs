using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/GetProductDetails")]
    [ApiController]
    public class GetProductDetailsController : ControllerBase
    {
        /// <summary>
        /// Gets the dummy data for ProductsController GET request
        /// </summary>
        /// <returns>The list of dummy products</returns>
        [HttpGet]
        public string Get(GetProductDetailsRequest request)
        {

            pagoFonApi llamada1 = new pagoFonApi();
            var result = llamada1.GetProductDetails("Vendor1Topup", "", "", "0");
            // var result = llamada1.GetProductDetails(request.ProductID, "", "", request.ProductServiceType);
            Console.WriteLine("result" + result);


            // This is intended to simulate the deserialization and serialization of
            // the actual response from PagoFon.
            // var response = JsonConvert.DeserializeObject<PagoFonResponse>(jsonString);
            var response = JsonConvert.DeserializeObject<GetProductDetailsResponse>(result);
            Console.WriteLine("RESPONSE DENISSE" + result);
            return JsonConvert.SerializeObject(response);
            ;
        }
    }

}