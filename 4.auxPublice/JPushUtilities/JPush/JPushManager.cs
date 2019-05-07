using cn.jpush.api;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPushUtilities
{
    public class JPushManager
    {
        /// <summary>
        /// 极光推送服务 
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="Msg">用户ID</param>
        public static void PushiOS_Android(string userid, string Msg)
        {

            try
            {
                JPushClient pushClient = new JPushClient(Config.app_key, Config.masterSecret);

                PushPayload pushPayload = new PushPayload();
                pushPayload.platform = Platform.android_ios();
                pushPayload.audience = Audience.s_alias(userid);
                var options = new Options();
                options.apns_production = false;     //true表示IOS 生产环境   false 表示开发环境   
                pushPayload.options = options;        //如果默认不设置则表示开发环境
                var notification = new Notification();
                // "您有新的订单，请处理"
                notification.IosNotification = new IosNotification().setAlert(Msg)
                                                                    .setBadge(1)
                                                                    .setSound("happy")
                                                                    .AddExtra("from", "JPush");

                notification.AndroidNotification = new AndroidNotification().setAlert(Msg).AddExtra("from", "JPush");
                pushPayload.notification = notification;
                var result = pushClient.SendPush(pushPayload);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }

    }
}
