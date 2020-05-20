using System;
namespace POS.Models
{
    //{"ActivationCode":"7216875370","RequestUniqueID":"2151247287976471930",
    //"MethodName":"GetB alance","RequestIP":"127.0.0.1"}
    public class GetBalanceRequest
    {
        public string ActivationCode { get; set; }
        public string RequestUniqueID { get; set; }
        public string MethodName { get; set; }
        public string RequestIP { get; set; }


        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public GetBalanceRequest(string activationCode, string requestUniqueID, string methodName, string requestIP)
        {
            ActivationCode = activationCode;
            RequestUniqueID = requestUniqueID;
            MethodName = methodName;
            RequestIP = requestIP;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public GetBalanceRequest() { }
    }
}