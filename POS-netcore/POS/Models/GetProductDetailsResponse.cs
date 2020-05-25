using System;
namespace POS.Models
{
    public class GetProductDetailsResponse
    {
        public string ResponseCode { get; set; }

        public string ResponseDescription { get; set; }

        public float BalanceofSubscriber { get; set; }

        public ServiceList serviceList { get; set; }


        /// <summary>
        /// TransactionResponse based on documentation provided by PagoFon, on method Topup
        /// </summary>
        public GetProductDetailsResponse(string responseCode, string responseDescription, float balance,
        ServiceList servicelist)
        {
            ResponseCode = responseCode;
            ResponseDescription = responseDescription;
            BalanceofSubscriber = balance;
            serviceList = servicelist;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public GetProductDetailsResponse() { }
    }
}