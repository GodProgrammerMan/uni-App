using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEcoMycarParkingVehicleQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarParkingVehicleQueryModel : AopObject
    {
        /// <summary>
        /// 车辆ID
        /// </summary>
        [XmlElement("car_id")]
        public string CarId { get; set; }
    }
}
