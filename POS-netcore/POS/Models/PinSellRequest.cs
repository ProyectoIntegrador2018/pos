using System;
namespace POS.Models
{
    public class PinSellRequest
    {
        public string MethodName { get; set; }
        public string ActivationCode { get; set; }
        public string RequestUniqueID { get; set; }
        public string ProductCode { get; set; }
        public string VoucherData { get; set; }
        public float Amount { get; set; }
        public string ANI { get; set; }
        public string MPin { get; set; }
        public string Email { get; set; }
        public string RequestIP { get; set; }

        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method PinSell
        /// This only accounts for the information provided by the customer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public PinSellRequest(string methodName, string activationCode, string requestUniqueID, string productCode, string voucherData, float amount, string aNI, string mPin, string email, string requestIP )
        {
            MethodName = methodName;
            ActivationCode = activationCode;
            RequestUniqueID = requestUniqueID;
            ProductCode = productCode;
            VoucherData = voucherData;
            Amount = amount;
            ANI = aNI;
            MPin = mPin;
            Email = email;
            RequestIP = requestIP;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public PinSellRequest() { }
    }
}