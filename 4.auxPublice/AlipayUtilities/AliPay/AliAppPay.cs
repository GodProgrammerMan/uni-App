using Aop.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlipayUtilities.AliPay
{
    public class AliAppPay
    {
        private DotNet.Utilities.JsonHelper jsonHelper = new DotNet.Utilities.JsonHelper();

        /// <summary>
        /// App支付宝支付
        /// </summary>
        /// <param name="body">商品描述</param>
        /// <param name="subject">标题</param>
        /// <param name="total_amount">金额</param>
        /// <param name="newOrderId">订单ID</param> 
        public string ZfbPayMethod(string body, string subject, string total_amount, string newOrderId)
        { 
            if (newOrderId != null && newOrderId != "")
            {
                IDictionary<string, string> paramsMap = new Dictionary<string, string>();
                paramsMap.Add("appId", AlipayUtilities.AliPay.Config.appid);
                string privateKeyPem = AppDomain.CurrentDomain.BaseDirectory + "/Signature/" + "aop-sandbox-RSA-private-c#.pem";
                string sign = AlipaySignature.RSASign(paramsMap, privateKeyPem, null, "RSA");
                paramsMap.Add("sign", sign);
                string publicKey = AppDomain.CurrentDomain.BaseDirectory + "/Signature/" + "public-key.pem";
                bool checkSign = AlipaySignature.RSACheckV2(paramsMap, publicKey);      //验证签名是否正确
                if (checkSign == true)
                {
                    biz_content _biz_content = new biz_content();
                    _biz_content.notify_url = Config.notify_url;
                    _biz_content.body = body == null ? "" : body;
                    _biz_content.out_trade_no = newOrderId;
                    _biz_content.product_code = "QUICK_MSECURITY_PAY";
                    _biz_content.subject = subject == null ? "" : subject;
                    _biz_content.timeout_express = "30m";
                    var newtotal_amount = "0.01";
                    if (total_amount != null || total_amount != "")
                        newtotal_amount = double.Parse(total_amount).ToString("f2");
                    _biz_content.total_amount = newtotal_amount;
                    string jsonvalue = jsonHelper.Serialize(_biz_content);
                    string BizContent = "app_id=" + AlipayUtilities.AliPay.Config.appid + @"&biz_content=" + jsonvalue + "";
                    BizContent += @"&charset=utf-8&format=json&method=alipay.trade.app.pay&sign_type=RSA&timestamp=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "&version=1.0";
                    string sign_ = AlipaySignature.RSASign(BizContent, privateKeyPem, null, "RSA");

                    BizContent += @"&sign=" + UrlEncode(sign_, Encoding.UTF8) + "";

                    return BizContent;
                }
                return "";
            }
            return "";

        }


        //特殊的转译  针对支付宝的sign java和c#是有点区别的
        private string UrlEncode(string temp, Encoding encoding)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                string t = temp[i].ToString();
                string k = System.Web.HttpUtility.UrlEncode(t, encoding);
                if (t == k)
                {
                    stringBuilder.Append(t);
                }
                else
                {
                    stringBuilder.Append(k.ToUpper());
                }
            }
            return stringBuilder.ToString();
        }

    }

    public class biz_content
    {
        /// <summary>
        /// 支付宝通过的验证url
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// 超时设置 默认30m
        /// </summary>
        public string timeout_express { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string product_code { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string total_amount { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }
        /// <summary>
        ///  订单id
        /// </summary>
        public string out_trade_no { get; set; }
    }
}
