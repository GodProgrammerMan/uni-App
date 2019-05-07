using System;
using System.Linq;
using System.Text;

namespace Blog_Main.Model
{
    ///<summary>
    ///文章表
    ///</summary>
    public partial class mb_Article
    {
           public mb_Article(){


           }
           /// <summary>
           /// Desc:文章ID
           /// Default:
           /// Nullable:False
           /// </summary>
           [System.ComponentModel.Description("文章ID")]           
           public int ArticleID {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("标题")]           
           public string ArticleTitle {get;set;}

           /// <summary>
           /// Desc:文章类型ID
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("文章类型ID")]           
           public int? ArticleTypeId {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("描述")]           
           public string ArticleNote {get;set;}

           /// <summary>
           /// Desc:文章内容
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("文章内容")]           
           public string ArticleContent {get;set;}

           /// <summary>
           /// Desc:作者ID
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("作者ID")]           
           public int? UserId {get;set;}

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

           /// <summary>
           /// Desc:是否推荐
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("是否推荐")]           
           public int? isRecommendIndex {get;set;}

           /// <summary>
           /// Desc:推荐结束时间
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("推荐结束时间")]           
           public DateTime? RecommendIndexEndTime {get;set;}

           /// <summary>
           /// Desc:标签
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("标签")]           
           public string tab {get;set;}

           /// <summary>
           /// Desc:封面图
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("封面图")]           
           public string CoverPhoto {get;set;}

           /// <summary>
           /// Desc:浏览量
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("浏览量")]           
           public int? Views {get;set;}

           /// <summary>
           /// Desc:	状态，0审核中，1审核不通过，2审核通过
           /// Default:
           /// Nullable:True
           /// </summary>
           [System.ComponentModel.Description("	状态，0审核中，1审核不通过，2审核通过")]           
           public int? State {get;set;}

    }
}
