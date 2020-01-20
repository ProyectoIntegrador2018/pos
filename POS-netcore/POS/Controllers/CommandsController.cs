using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase 
    {
        [HttpGet]
        public async  Task<ActionResult<string>> Get()
        {
            string url="https://jsonplaceholder.typicode.com/todos"; 
            using (HttpClient client = new HttpClient())
            {
                return  await client.GetStringAsync(url);
            }
        }
    }
    
}