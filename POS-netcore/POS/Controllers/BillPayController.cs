using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Net;

namespace POS.Controllers
{
    [Route("api/BillPay")]
    [ApiController]

    public class BillPayController : ControllerBase 
    {
        /// <summary>
        /// Gets the dummy data for ProductsController GET request
        /// </summary>
        /// <returns>The list of dummy products</returns>
        [HttpPost]
        public string PostBillPayTransaction(BillPayRequest request){

            pagofonAPI billpay = new pagofonAPI();

            var result = billpay.BillPay(request.ProductCode,request.BillPayData,request.Amount,request.MPin,request.Email,request.ANI);
            
            var response = JsonConvert.DeserializeObject<BillPayResponse>(result);
            return JsonConvert.SerializeObject(response);

        }
    }

    
}