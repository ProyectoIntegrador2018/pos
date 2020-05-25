using System;
namespace POS.Models
{
    public class TopUpResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string Balance { get; set; }
        public string ConfirmationCode { get; set; }
        public string TransactionID { get; set; }
        public TransactionInfo TransactionInfo { get; set; }

        public string RequestDateTime { get; set; }

        public string TransactionFee { get; set; }

        public string Commission { get; set; }

        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        public TopUpResponse(string ResponseCode, string ResponseDescription, string Balance,string ConfirmationCode, string TransactionID, TransactionInfo TransactionInfo, string RequestDateTime,string TransactionFee, string Commission )
        {

            this.ResponseCode = ResponseCode;
            this.ResponseDescription = ResponseDescription;
            this.Balance = Balance;
            this.ConfirmationCode = ConfirmationCode;
            this.TransactionID = TransactionID;
            this.TransactionInfo = TransactionInfo;
            this.RequestDateTime = RequestDateTime;
            this.TransactionFee = TransactionFee;
            this.Commission = Commission;


        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public TopUpResponse() { }
    }
}