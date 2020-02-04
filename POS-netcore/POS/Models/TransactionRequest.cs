using System;
namespace POS.Models
{
    public class TransactionRequest
    {
        public string ProductCode { get; set; }
        public float Amount { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public TransactionRequest(string productCode, float amount, string phoneNumber, string email)
        {
            ProductCode = productCode;
            Amount = amount;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public TransactionRequest() { }
    }
}