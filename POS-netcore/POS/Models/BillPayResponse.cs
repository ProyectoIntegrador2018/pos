using System;
namespace POS.Models
{
    public class BillPayResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string TransactionID { get; set; }
        public string RequestDateTime { get; set; }
        public string TransactionFee { get; set; }
        public string Commission { get; set; }

         public string RequestUniqueID { get; set; }
        public string AccessID { get; set; }

        
        /// <summary>
        /// TransactionRequest based on documentation provided by PagoFon, on method Topup
        /// This only accounts for the information provided by the costumer, the other
        /// parameteres should be environment variables from the POS
        /// </summary>
        /*
        public BillPayResponse(string ResponseCode, string ResponseDescription, string TransactionID,string RequestDateTime, string TransactionFee, string Commission )
        {
            this.ResponseCode = ResponseCode;
            this.ResponseDescription = ResponseDescription;
            this.TransactionID = TransactionID;
            this.RequestDateTime = RequestDateTime;
            this.TransactionFee = TransactionFee;
            this.Commission = Commission;
        }
        */

         public BillPayResponse(String ResponseCode, string ResponseDescription,string TransactionID, string RequestDateTime, string TransactionFee, string Commission, string RequestUniqueID, string AccessID)
         {
            this.ResponseCode = ResponseCode;
            this.ResponseDescription = ResponseDescription;
            this.TransactionID = TransactionID;
            this.RequestDateTime = RequestDateTime;
            this.TransactionFee = TransactionFee;
            this.Commission = Commission;
            this.RequestUniqueID = RequestUniqueID;
            this.AccessID = AccessID;     
         }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public BillPayResponse() { }
    }
}