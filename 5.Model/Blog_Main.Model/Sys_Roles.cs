using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///角色表
    ///</summary>
    public partial class Sys_Roles
    {
           public Sys_Roles(){


           }
           /// <summary>
           /// Desc:角色表id
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("角色表id")]           
           public int RoleId {get;set;}

           /// <summary>
           /// Desc:	角色名称
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("	角色名称")]           
           public string RoleName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public bool? IsDeleted {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public DateTime? CreateTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public DateTime? UpdateTime {get;set;}

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
           public int? UpdateAdminId {get;set;}

    }
}
