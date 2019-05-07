using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///用户表
    ///</summary>
    public partial class mb_User
    {
           public mb_User(){


           }
           /// <summary>
           /// Desc:用户表ID
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("用户表ID")]           
           public int UserId {get;set;}

           /// <summary>
           /// Desc:登录号
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("登录号")]           
           public string UserNo {get;set;}

           /// <summary>
           /// Desc:密匙
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("密匙")]           
           public string UserKey {get;set;}

           /// <summary>
           /// Desc:密匙标识
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("密匙标识")]           
           public string UserKeyStr {get;set;}

           /// <summary>
           /// Desc:姓名
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("姓名")]           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:昵称
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("昵称")]           
           public string NickName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public bool? IsDeleted {get;set;}

           /// <summary>
           /// Desc:是否展示
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("是否展示")]           
           public bool? IsShow {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("创建时间")]           
           public DateTime? CreateTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public DateTime? UpdateTime {get;set;}

           /// <summary>
           /// Desc:头像
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("头像")]           
           public string UserLogo {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string LastLoginIp {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public DateTime? LastLoginTime {get;set;}

           /// <summary>
           /// Desc:是否审核
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("是否审核")]           
           public bool? IsCheck {get;set;}

           /// <summary>
           /// Desc:审核人
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("审核人")]           
           public int? CheckAdminId {get;set;}

           /// <summary>
           /// Desc:审核时间
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("审核时间")]           
           public DateTime? CheckTime {get;set;}

           /// <summary>
           /// Desc:个性签名
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("个性签名")]           
           public string Description {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string QQ {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string phone {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string Email {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string Sex {get;set;}

    }
}
