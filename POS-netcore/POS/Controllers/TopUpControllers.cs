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
        [HttpGet]
        public string Get()
        {
            var jsonString = @"{
                ""ResponseCode"":""000"",
                ""ResponseDescription"":""TxnSuccessful"",
                ""ServiceList"":{
                    ""ServiceID"":[""10"",""81"",""30"",""66"",""28"",""17""],
                    ""ServiceName"":[""TopUp"", ""GetBalance"",""BillPay"",""PinSell"",""GetEnterpriseList"",""GetProductsDetails""],
                    ""ServiceCode"":[""S2S"",""S2NR"",""S2EC"",""S2A"",""S2O"",""S2M""],
                    ""ServiceType"":[""P"",""P"",""P"",""P"",""P"",""P""],
                    ""ServiceDenominationID"":[],
                    ""MinAmount"":[""250.010000"",""1.000000"",""1.000000"",""1.000000"",""1000.010000"",""1.000000""],
                    ""MaxAmount"":[""500.000000"",""10000.000000"",""5000.000000"",""200.000000"",""5000.000000"",""1000.000000""],
                    ""IsActive"":[""1"",""1"",""1"",""1"",""1"",""1""],""InternalModuleID"":[""6"",""6"",""4"",""7"",""7"",""8""],
                    ""ModuleName"":[""Transfer Money"",""Transfer Money"",""Business Payment"",""Cash Out"",""CashOut"",""MerchantPayment""],
                    ""ServiceImage"":[""e91e"",""e91e"",""e90a"",""e90c"",""e90c"",""e913""],
                    ""ServiceIconWeb"":[""ms-icon-transfer-money"",""ms-icon-transfer-money"",""ms-icon-business-payment"",""ms-icon-cash-out"",""ms-icon-cash-out"",""ms-icon-merchant-payment""],
                    ""ServiceIconMob"":[""e91e"",""e91e"",""e90a"",""e90c"",""e90c"",""e913""],
                }
            }";

            // This is intended to simulate the deserialization and serialization of
            // the actual response from PagoFon.
            var response = JsonConvert.DeserializeObject<PagoFonResponse>(jsonString);

            return JsonConvert.SerializeObject(response);
        }
    }
    
}