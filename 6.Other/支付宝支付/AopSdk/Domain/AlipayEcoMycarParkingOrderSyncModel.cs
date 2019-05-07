using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEcoMycarParkingOrderSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarParkingOrderSyncModel : AopObject
    {
        /// <summary>
        /// 支付流水号
        /// </summary>
        [XmlElement("alipay_orderid")]
        public string AlipayOrderid { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        [XmlElement("car_number")]
        public string CarNumber { get; set; }

        /// <summary>
        /// 如果是扫停车卡，填入停车卡卡号
        /// </summary>
        [XmlElement("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// 设备商订单号
        /// </summary>
        [XmlElement("eorder_id")]
        public string EorderId { get; set; }

        /// <summary>
        /// 设备商订单状态，1：成功，0：失败
        /// </summary>
        [XmlElement("eorder_status")]
        public string EorderStatus { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        [XmlElement("eorder_time")]
        public string EorderTime { get; set; }

        /// <summary>
        /// 停车时长（以分为单位）
        /// </summary>
        [XmlElement("in_duration")]
        public string InDuration { get; set; }

        /// <summary>
        /// 入场时间
        /// </summary>
        [XmlElement("in_time")]
        public string InTime { get; set; }

        /// <summary>
        /// 停车平台ID
        /// </summary>
        [XmlElement("parking_id")]
        public string ParkingId { get; set; }

        /// <summary>
        /// 停车场名称
        /// </summary>
        [XmlElement("parking_name")]
        public string ParkingName { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        [XmlElement("pay_money")]
        public string PayMoney { get; set; }

        /// <summary>
        /// 缴费时间
        /// </summary>
        [XmlElement("pay_time")]
        public string PayTime { get; set; }

        /// <summary>
        /// 付款方式，1：支付宝在线缴费
        /// </summary>
        [XmlElement("pay_type")]
        public string PayType { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
