using System;
namespace POS.Models
{
    public class TransactionInfo
    {
        public string TransactionId { get; set; }
        public string OperatorCode { get; set; }
        
        /// <summary>
        /// TransactionInfo based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public TransactionInfo(string transactionId, string operatorCode)
        {
            TransactionId = transactionId;
            OperatorCode = operatorCode;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public TransactionInfo() { }
    }
}