using System;
namespace POS.Models
{
    public class GetBalanceRequest
    {
        public string ActivationCode { get; set; }
        public string RequestUniqueID { get; set; }
        public string BillPayData { get; set; }
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