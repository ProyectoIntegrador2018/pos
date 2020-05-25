using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/GetBalance")]
    [ApiController]
    public class GetBalanceController : ControllerBase
    {
        /// <summary>
        /// Gets the dummy data for ProductsController GET request
        /// </summary>
        /// <returns>The list of dummy products</returns>
        [HttpGet]
        public string Get()
        {
            pagoFonApi llamada1 = new pagoFonApi();
            var result = llamada1.GetBalance();
            Console.WriteLine(result + "Result");



            // This is intended to simulate the deserialization and serialization of
            // the actual response from PagoFon.
            var response = JsonConvert.DeserializeObject<GetBalanceResponse>(result);

            return JsonConvert.SerializeObject(response);
        }
    }

}