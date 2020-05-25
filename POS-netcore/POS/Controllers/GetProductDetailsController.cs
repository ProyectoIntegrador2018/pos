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
        public string Get()
        {

            pagofonAPI llamada1 = new pagofonAPI();
            var result = llamada1.GetProductDetails("Vendor1Topup001", "", "", "0");
            //var result = llamada1.GetProductDetails(request.ProductID, request.SystemModuleID, request.SystemServiceID, request.ProductServiceType);
            var response = JsonConvert.DeserializeObject<GetProductDetailsResponse>(result);

            return JsonConvert.SerializeObject(response);
            ;
        }
    }

}