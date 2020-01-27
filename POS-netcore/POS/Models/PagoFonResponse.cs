using System;
namespace POS.Models
{
    public class PagoFonResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public ServiceList ServiceList { get; set; }

        /// <summary>
        /// PagoFonResponse based on documentation provided by PagoFon
        /// </summary>
        /// <param name="responseCode">The response code</param>
        /// <param name="responseDescription">The response description</param>
        /// <param name="serviceList">Service list data</param>
        public PagoFonResponse(string responseCode, string responseDescription, ServiceList serviceList)
        {
            ResponseCode = responseCode;
            ResponseDescription = responseDescription;
            ServiceList = serviceList;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public PagoFonResponse() { }
    }
}
