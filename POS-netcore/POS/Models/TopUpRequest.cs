using System;
namespace POS.Models
{
    public class TopUpRequest
    {
        public string ProductCode { get; set; }
        public string TxReference { get; set; }
        public string Amount { get; set; }
        public string LoginPin { get; set; }
        public string Email { get; set; }
        public string Ani { get; set; }

        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public TopUpRequest(string ActivationCode, string RequestUniqueID, string ProductCode,string TxReference, string Amount, string LoginPin, string Email,string Ani )
        {

            this.ProductCode = ProductCode;
            this.TxReference = TxReference;
            this.Amount = Amount;
            this.LoginPin = LoginPin;
            this.Email = Email;
            this.Ani = Ani;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public TopUpRequest() { }
    }
}