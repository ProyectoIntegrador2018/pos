using System;
namespace POS.Models
{

    //{"ActivationCode":"7216875370","SystemModuleID":""
    //,"ProductServiceType":"0","RequestUniqueID": "7151315284617938637",
    //"MethodName":"GetProductDetails","RequestIP":"127.0.0.1"
    public class GetProductDetailsRequest
    {
        public string ActivationCode { get; set; }
        public string SystemModuleID { get; set; }
        public string ProductServiceType { get; set; }
        public string RequestUniqueID { get; set; }
        public string MethodName { get; set; }
        public string RequestIP { get; set; }


        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public GetProductDetailsRequest(string activationCode, string systemModuleID, string productServiceType,
        string requestUniqueID, string methodName, string requestIP)
        {
            ActivationCode = activationCode;
            SystemModuleID = systemModuleID;
            ProductServiceType = productServiceType;
            RequestUniqueID = requestUniqueID;
            MethodName = methodName;
            RequestIP = requestIP;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public GetProductDetailsRequest() { }
    }
}