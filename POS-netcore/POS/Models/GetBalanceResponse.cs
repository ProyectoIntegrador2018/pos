using System;
using System.Collections.Generic;

namespace POS.Models
{
    //{"ActivationCode":"7216875370","RequestUniqueID":"2151247287976471930",
    //"MethodName":"GetB alance","RequestIP":"127.0.0.1"}
    public class GetBalanceResponse
    {


        public string ResponseCode { get; set; }
        public List<PocketBalance> pocketBalance { get; set; } //PocketBalance
        public string AccessID { get; set; }



        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public GetBalanceResponse(string responseCode, List<PocketBalance> PocketBalance, string accessID)
        {



            ResponseCode = responseCode;
            pocketBalance = PocketBalance;
            AccessID = accessID;

        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public GetBalanceResponse() { }
    }
}
