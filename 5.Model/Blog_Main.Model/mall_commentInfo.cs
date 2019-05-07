using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///评论表
    ///</summary>
    public partial class mall_commentInfo
    {
           public mall_commentInfo(){


           }
           /// <summary>
           /// Desc:评论表ID
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("评论表ID")]           
           public int CommentID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public int? ArticleID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public string ContentMsg {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public int? UserID {get;set;}

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
           public bool? isDelete {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public bool? isShow {get;set;}

    }
}
