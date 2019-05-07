using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlipayUtilities.AliPay
{
    /// <summary>
    /// 支付类型
    /// </summary>
    public class PayType
    { 
        /// <summary>
        /// 支付类型 微信支付 APP
        /// </summary>
        public const int TYPE_PAY_WX_APP = 1;
        /// <summary>
        /// 支付类型 支付宝 APP
        /// </summary>
        public const int TYPE_PAY_ALIPAY_APP = 2;
        /// <summary>
        /// 支付类型 微信支付 网页
        /// </summary>
        public const int TYPE_PAY_WX_WEB = 3;
        /// <summary>
        /// 支付类型 支付宝 网页
        /// </summary>
        public const int TYPE_PAY_ALIPAY_WEB = 4;
    }
}
