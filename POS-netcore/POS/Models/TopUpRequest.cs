using System;
namespace POS.Models
{
    public class TopUpRequest
    {
        public string ActivationCode { get; set; }
        public string RequestUniqueID { get; set; }
        public string ProductCode { get; set; }
        public string TxReference { get; set; }
        public string Amount { get; set; }
        public string LoginPin { get; set; }
        public string MethodName { get; set; }
        public string RequestIP { get; set; }

        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public TopUpRequest(string ActivationCode, string RequestUniqueID, string ProductCode,string TxReference, string Amount, string LoginPin, string MethodName,string RequestIP )
        {
            this.ActivationCode = ActivationCode;
            this.RequestUniqueID = RequestUniqueID;
            this.ProductCode = ProductCode;
            this.TxReference = TxReference;
            this.Amount = Amount;
            this.LoginPin = LoginPin;
            this.MethodName = MethodName;
            this.RequestIP = RequestIP;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public TopUpRequest() { }
    }
}