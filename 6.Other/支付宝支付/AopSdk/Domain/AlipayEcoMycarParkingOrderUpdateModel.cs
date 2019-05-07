using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEcoMycarParkingOrderUpdateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarParkingOrderUpdateModel : AopObject
    {
        /// <summary>
        /// 设备商订单订单状态
        /// </summary>
        [XmlElement("eorder_status")]
        public string EorderStatus { get; set; }

        /// <summary>
        /// 停车平台订单号
        /// </summary>
        [XmlElement("parking_orderid")]
        public string ParkingOrderid { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
