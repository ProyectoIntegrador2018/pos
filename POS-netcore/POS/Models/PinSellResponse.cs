using System;
namespace POS.Models
{
    public class PinSellResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public float TransactionID { get; set; }
        public DateTime RequestDateTime { get; set; }
        public float TransactionFee { get; set; }
        public float Commission { get; set; }

        /// <summary>
        /// PinSellResponse based on documentation provided by PagoFon, on method Topup
        /// </summary>
        public PinSellResponse(string responseCode, string responseDescription, float transactionID, DateTime requestDateTime, float transactionFee, float commission)
        {
            ResponseCode = responseCode;
            ResponseDescription = responseDescription;
            TransactionID = transactionID;
            RequestDateTime = requestDateTime;
            TransactionFee = transactionFee;
            Commission = commission;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public PinSellResponse() { }
    }
}