using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///权限表
    ///</summary>
    public partial class Sys_Rules
    {
           public Sys_Rules(){


           }
           /// <summary>
           /// Desc:表id
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("表id")]           
           public int RulesId {get;set;}

           /// <summary>
           /// Desc:角色id
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("角色id")]           
           public int? RoleId {get;set;}

           /// <summary>
           /// Desc:	权限项
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("	权限项")]           
           public string RolesItemNo {get;set;}

           /// <summary>
           /// Desc:权限类型
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("权限类型")]           
           public string RulesType {get;set;}

    }
}
