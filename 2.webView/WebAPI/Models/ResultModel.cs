using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// 返回结果Model
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// shoppingMall结果返回实体
        /// </summary>
        public class ShoppingMallIndexModel
        {
            /// <summary>
            /// 首页轮播图
            /// </summary>
            public List<Carousel> carouselList { get; set; } = new List<Carousel>();
            /// <summary>
            /// 商品列表
            /// </summary>
            public List<Goods> goodsList { get; set; } = new List<Goods>();
        }
        /// <summary>
        /// 轮播图实体
        /// </summary>
        public class Carousel {
            /// <summary>
            /// 图片地址
            /// </summary>
            public string src { get; set; }
            /// <summary>
            /// 背景图
            /// </summary>
            public string background { get; set; }
        }
        /// <summary>
        /// 商品
        /// </summary>
        public class Goods {
            /// <summary>
            /// 图片1
            /// </summary>
            public string image { get; set; }
            /// <summary>
            /// 图片2
            /// </summary>
            public string image2 { get; set; }
            /// <summary>
            /// 图片3
            /// </summary>
            public string image3 { get; set; }
            /// <summary>
            /// 标题
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 价格
            /// </summary>
            public double price { get; set; }
            /// <summary>
            /// 售出量
            /// </summary>
            public int sales { get; set; }
        }
        /// <summary>
        /// 商品详情页
        /// </summary>
        public class DetailData {
            /// <summary>
            /// 商品ID
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 标题
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 副标题
            /// </summary>
            public string title2 { get; set; }
            /// <summary>
            /// 判定
            /// </summary>
            public bool favorite { get; set; }
            /// <summary>
            /// 图片List
            /// </summary>
            public string imgList { get; set; }
        }

    }
}