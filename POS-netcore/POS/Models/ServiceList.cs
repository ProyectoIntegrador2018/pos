using System.Collections.Generic;

namespace POS.Models
{
    public class ServiceList
    {
        public List<string> ServiceID { get; set; }
        public List<string> ServiceName { get; set; }
        public List<string> ServiceCode { get; set; }
        public List<string> ServiceType { get; set; }
        public List<string> ServiceDenominationID { get; set; }
        public List<string> MinAmount { get; set; }
        public List<string> MaxAmount { get; set; }
        public List<string> IsActive { get; set; }
        public List<string> InternalModuelID { get; set; }
        public List<string> ModuleName { get; set; }
        public List<string> ServiceImage { get; set; }
        public List<string> ServiceIconWeb { get; set; }
        public List<string> ServiceIconMob { get; set; }

        /// <summary>
        /// Initializes a ServiceList based on PoagoFon documentation file
        /// </summary>
        /// <param name="serviceID">A list of service ids</param>
        /// <param name="serviceName">A list of service names matching the service ids</param>
        /// <param name="serviceCode">A list of service codes matching the service ids</param>
        /// <param name="serviceType">A list of service types matching the service ids</param>
        /// <param name="serviceDenominationID">A list of service denomination ids matching the service ids</param>
        /// <param name="minAmount">A list of service minimum amounts matching the service ids</param>
        /// <param name="maxAmount">A list of service maximum amounts matching the service ids</param>
        /// <param name="isActive">A list of booleans determining if the service is active</param>
        /// <param name="internalModuelID">A list of service internal module ids matching the service ids</param>
        /// <param name="moduleName">A list of service module names matching the service ids</param>
        /// <param name="serviceImage">A list of service images matching the service ids</param>
        /// <param name="serviceIconWeb">A list of service icons for web matching the service ids</param>
        /// <param name="serviceIconMob">A list of service icons for mobile matching the service ids</param>
        public ServiceList(List<string> serviceID, List<string> serviceName, List<string> serviceCode, List<string> serviceType, List<string> serviceDenominationID, List<string> minAmount, List<string> maxAmount, List<string> isActive, List<string> internalModuelID, List<string> moduleName, List<string> serviceImage, List<string> serviceIconWeb, List<string> serviceIconMob)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceCode = serviceCode;
            ServiceType = serviceType;
            ServiceDenominationID = serviceDenominationID;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
            IsActive = isActive;
            InternalModuelID = internalModuelID;
            ModuleName = moduleName;
            ServiceImage = serviceImage;
            ServiceIconWeb = serviceIconWeb;
            ServiceIconMob = serviceIconMob;
        }

        /// <summary>
        /// Parameterless constructor for service list
        /// </summary>
        public ServiceList() { }
    }
}
