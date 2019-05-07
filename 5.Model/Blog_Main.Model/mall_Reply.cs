using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///回复表
    ///</summary>
    public partial class mall_Reply
    {
           public mall_Reply(){


           }
           /// <summary>
           /// Desc:回复ID
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("回复ID")]           
           public int ReplyID {get;set;}

           /// <summary>
           /// Desc:评论ID
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("评论ID")]           
           public int? CommentID {get;set;}

           /// <summary>
           /// Desc:回复者
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("回复者")]           
           public string ReplyUserA {get;set;}

           /// <summary>
           /// Desc:被回复者
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("被回复者")]           
           public string ReplyUserB {get;set;}

           /// <summary>
           /// Desc:回复时间
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("回复时间")]           
           public DateTime? CreateTime {get;set;}

           /// <summary>
           /// Desc:回复内容
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("回复内容")]           
           public string ReplyMsg {get;set;}

    }
}
