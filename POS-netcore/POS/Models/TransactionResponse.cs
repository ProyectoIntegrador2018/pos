using System;
namespace POS.Models
{
    public class TransactionResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public float Balance { get; set; }
        public string ConfirmationCode { get; set; }
        public string TransactionID { get; set; }
        public string TransactionInfo { get; set; }
        public DateTime RequestDateTime { get; set; }
        public float TransactionFee { get; set; }
        public float Commission { get; set; }

        /// <summary>
        /// TransactionResponse based on documentation provided by PagoFon, on method Topup
        /// </summary>
        public TransactionResponse(string responseCode, string responseDescription, float balance, string confirmationCode, string transactionID, string transactionInfo, DateTime requestDateTime, float transactionFee, float commission)
        {
            ResponseCode = responseCode;
            ResponseDescription = responseDescription;
            Balance = balance;
            ConfirmationCode = confirmationCode;
            TransactionID = transactionID;
            TransactionInfo = transactionInfo;
            RequestDateTime = requestDateTime;
            TransactionFee = transactionFee;
            Commission = commission;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public TransactionResponse() { }
    }
}