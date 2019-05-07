using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///管理员表
    ///</summary>
    public partial class Sys_Manager
    {
           public Sys_Manager(){


           }
           /// <summary>
           /// Desc:管理员表ID
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("管理员表ID")]           
           public int AdminId {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("角色ID")]           
           public int? RoleId {get;set;}

           /// <summary>
           /// Desc:登录号
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("登录号")]           
           public string AdminNo {get;set;}

           /// <summary>
           /// Desc:管理员姓名
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("管理员姓名")]           
           public string AdminName {get;set;}

           /// <summary>
           /// Desc:登录密匙
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("登录密匙")]           
           public string AdminKey {get;set;}

           /// <summary>
           /// Desc:	密匙标识
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("	密匙标识")]           
           public string AdminKeyStr {get;set;}

           /// <summary>
           /// Desc:昵称
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("昵称")]           
           public string NickName {get;set;}

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
           public int? CreateAdminId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public bool? IsAllowLogin {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string LastLoginIP {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public DateTime? LastLoginTime {get;set;}

    }
}
