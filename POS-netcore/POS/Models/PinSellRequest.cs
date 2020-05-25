using System;
namespace POS.Models
{
    public class PinSellRequest
    {
        public string ProductCode { get; set; }
        public string VoucherData { get; set; }
        public string Amount { get; set; }
        public string MPin { get; set; }
        public string Email { get; set; }
        public string ANI { get; set; }
        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method PinSell
        /// This only accounts for the information provided by the customer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public PinSellRequest(string productCode, string voucherData, string amount, string mPin, string email, string aNI)
        {
            ProductCode = productCode;
            VoucherData = voucherData;
            Amount = amount;
            MPin = mPin;
            Email = email;
            ANI = aNI;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public PinSellRequest() { }
    }
}