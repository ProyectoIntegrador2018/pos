using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase 
    {
        /// <summary>
        /// Gets the dummy data for TransactionsController POST request
        /// </summary>
        /// <returns>The result of the requested transaction</returns>
        [HttpPost]
        public string PostTransaction(TransactionRequest request)
        {
            var jsonString = @"{
                    ""ResponseCode"":""000"",
                    ""ResponseDescription"":""Txn Successful"",
                    ""Balance"":""99980.000000"",
                    ""ConfirmationCode"":""20171206091723"",
                    ""TransactionID"":""5378"",
                    ""TransactionInfo"":{
                        ""TransactionId"":""091723"",
                        ""OperatorCode"":""20171206""
                    },
                    ""RequestDateTime"":""2017-12-06 09:17:22"",
                    ""TransactionFee"":""0.10"",
                    ""Commission"":""0.10""
                }";
            // This is intended to simulate the deserialization and serialization of
            // the actual response from PagoFon.
            var response = JsonConvert.DeserializeObject<TransactionResponse>(jsonString);

            if(request.Amount == 0) {
                response.ResponseCode = "999";
                response.ResponseDescription = "Txn Failed";
            }

            return JsonConvert.SerializeObject(response);
        }

        [HttpDelete("{id}")]
        public string DeleteTransaction(int id) {
            // In case the transaction doesn't exist
            var jsonString = "";
            if(id == 0) {
                jsonString = @"{
                ""ResponseCode"":""999"",
                ""ResponseDescription"":""Txn Does not Exist"",
            }";
            } else {
                jsonString = @"{
                ""ResponseCode"":""000"",
                ""ResponseDescription"":""Txn Deleted"",
            }";
            }
            return jsonString;
        }
    }
    
}