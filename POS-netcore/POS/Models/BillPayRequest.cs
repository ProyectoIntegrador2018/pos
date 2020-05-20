using System;
namespace POS.Models
{
    public class BillPayRequest
    {
        public string ActivationCode { get; set; }
        public string RequestUniqueID { get; set; }
        public string BillPayData { get; set; }
        public string MPin { get; set; }
        public string Email { get; set; }
        public string ANI { get; set; }
        public string MethodName { get; set; }
        public string RequestIP { get; set; }

        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public BillPayRequest(string activationCode, string requestUniqueID, string billPayData,string mPin, string email, string aNI, string methodName,string requestIP )
        {
            ActivationCode = activationCode;
            RequestUniqueID = requestUniqueID;
            BillPayData = billPayData;
            MPin = mPin;
            Email = email;
            ANI = aNI;
            MethodName = methodName;
            RequestIP = requestIP;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public BillPayRequest() { }
    }
}