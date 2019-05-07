using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///文章类型表
    ///</summary>
    public partial class mb_Article_Property
    {
           public mb_Article_Property(){


           }
           /// <summary>
           /// Desc:文章类型
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("文章类型")]           
           public int ArticleTypeId {get;set;}

           /// <summary>
           /// Desc:文章类型名称
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("文章类型名称")]           
           public string ArticleTypeName {get;set;}

           /// <summary>
           /// Desc:文章类型描述
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("文章类型描述")]           
           public string TravelsTypeNote {get;set;}

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
           public bool? IsDeleted {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("")]           
           public bool? IsShow {get;set;}

           /// <summary>
           /// Desc:排序值
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("排序值")]           
           public int? Sort {get;set;}

    }
}
