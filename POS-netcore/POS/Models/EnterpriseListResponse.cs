using System;
namespace POS.Models
{
    public class EnterpriseListResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string ResponseData { get; set; }

        /// <summary>
        /// EnterpriseListResponse based on documentation provided by PagoFon
        /// </summary>
        /// <param name="responseCode">The response code</param>
        /// <param name="responseData">Enterprise list data</param>
        /// <param name="responseDescription">The response description</param>
        public EnterpriseListResponse(string responseCode, string responseData, string responseDescription)
        {
            ResponseCode = responseCode;
            ResponseData = responseData;
            ResponseDescription = responseDescription;
        }

        /// <summary>
        /// Parameterless class definition for JSON deserialization
        /// </summary>
        public EnterpriseListResponse() { }
    }
}
