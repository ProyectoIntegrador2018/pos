using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase 
    {
        [HttpGet]
        public async  Task<ActionResult<string>> Get()
        {
            var url = "https://jsonplaceholder.typicode.com/posts";
            using HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
    
}