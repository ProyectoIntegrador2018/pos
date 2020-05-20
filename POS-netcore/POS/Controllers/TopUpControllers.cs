using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/TopUp")]
    [ApiController]
    public class TopUpControllers : ControllerBase 
    {
        /// <summary>
        /// Gets the dummy data for ProductsController GET request
        /// </summary>
        /// <returns>The list of dummy products</returns>
        [HttpPost]
        public TopUpRequest topUpSend(TopUpRequest request)
        {
        

            return request;
        }
    }
    
}