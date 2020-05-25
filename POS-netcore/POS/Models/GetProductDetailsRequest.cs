using System;
namespace POS.Models
{

    //{"ActivationCode":"7216875370","SystemModuleID":""
    //,"ProductServiceType":"0","RequestUniqueID": "7151315284617938637",
    //"MethodName":"GetProductDetails","RequestIP":"127.0.0.1"
    public class GetProductDetailsRequest
    {
        public string ProductID { get; set; }
        public string SystemModuleID { get; set; }
        public string SystemServiceID { get; set; }
        public string ProductServiceType { get; set; }

        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public GetProductDetailsRequest(string productID, string systemModuleID,
        string systemServiceID, string productServiceType)
        {
            ProductID = productID;
            SystemModuleID = systemModuleID;
            SystemServiceID = systemServiceID;
            ProductServiceType = productServiceType;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public GetProductDetailsRequest() { }
    }
}