using System;
namespace POS.Models
{
    public class BillPayRequest
    {
        public string ProductCode { get; set; }
        public string BillPayData { get; set; }
        public string Amount { get; set; }
        public string MPin { get; set; }
        public string Email { get; set; }
        public string ANI { get; set; }
        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public BillPayRequest(string ProductCode, string BillPayData,string Amount, string MPin, string Email, string ANI)
        {
            this.ProductCode = ProductCode;
            this.BillPayData = BillPayData;
            this.Amount = Amount;
            this.MPin = MPin;
            this.Email = Email;
            this.ANI = ANI;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public BillPayRequest() { }
    }
}