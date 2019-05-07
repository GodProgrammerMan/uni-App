using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static WebAPI.Models.ResultModel;

namespace WebAPI.Controllers.ShoppingMall
{
    /// <summary>
    /// shoppingMall首页接口
    /// </summary>
    [RoutePrefix("api/shoppingMall")]
    public class HomeIndexController : ApiController
    {
        /// <summary>
        /// 获取首页信息
        /// </summary>
        /// <returns></returns>
        [Route("GetIndexData")]
        [HttpGet]
        public async Task<JSONResult<ShoppingMallIndexModel>> GetIndexData()
        {
            return await Task.Run(() =>
            {
                return new BaseJsonResult().UnifiedFucn(() =>
                {
                    var model = new JSONResult<ShoppingMallIndexModel>();
                    List<Carousel> carouselList = new List<Carousel>() { new Carousel() { src = "/static/temp/banner3.jpg", background= "rgb(203, 87, 60)" },new Carousel() {src= "/static/temp/banner2.jpg", background= "rgb(205, 215, 218)" },new Carousel() { src= "/static/temp/banner4.jpg", background= "rgb(183, 73, 69)" } };
                    List<Goods> goodsList = new List<Goods>() { new Goods() { image= "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553187020783&di=bac9dd78b36fd984502d404d231011c0&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201609%2F26%2F20160926173213_s5adi.jpeg", image2 = "http://pic.rmb.bdstatic.com/819a044daa66718c2c40a48c1ba971e6.jpeg", image3= "http://img001.hc360.cn/y5/M00/1B/45/wKhQUVYFE0uEZ7zVAAAAAMj3H1w418.jpg", price= 179, sales = 61, title= "古黛妃 短袖t恤女夏装2019新款韩版宽松" }, new Goods() { image = "https://ss0.bdstatic.com/70cFuHSh_Q1YnxGkpoWK1HF6hhy/it/u=4031878334,2682695508&fm=11&gp=0.jpg", image3 = "http://img.zcool.cn/community/017a4e58b4eab6a801219c77084373.jpg", price = 78, sales = 16, title = "潘歌针织连衣裙", image2= "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1554013048&di=a3dc9fd1406dd7bad7fbb97b5489ec04&imgtype=jpg&er=1&src=http%3A%2F%2Fimg009.hc360.cn%2Fhb%2FnKo44ac2656F831c684507E3Da0E3a26841.jpg" }, new Goods() { image = "https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=1620020012,789258862&fm=26&gp=0.jpg", image2 = "http://m.360buyimg.com/n12/jfs/t247/42/1078640382/162559/3628a0b/53f5ad09N0dd79894.jpg%21q70.jpg", image3 = "http://ikids.61kids.com.cn/upload/2018-12-29/1546070626796114.jpg", price = 108.9, sales = 10, title = " 巧谷2019春夏季新品新款女装" }, new Goods() { image = "https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=756705744,3505936868&fm=11&gp=0.jpg", image2 = "http://images.jaadee.com/images/201702/goods_img/30150_d85aed83521.jpg", image3 = "http://img13.360buyimg.com/popWaterMark/jfs/t865/120/206320620/138889/dcc94caa/550acedcN613e2a9d.jpg", price = 265, sales = 17, title = "私萱连衣裙" }, new Goods() { image = "https://img13.360buyimg.com/n8/jfs/t1/30343/20/1029/481370/5c449438Ecb46a15b/2b2adccb6dc742fd.jpg", image2 = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553418265666&di=d4a7f7eb0ae3c859edeb921641ee1c3a&imgtype=0&src=http%3A%2F%2Fimg003.hc360.cn%2Fy3%2FM02%2FF8%2F9F%2FwKhQh1TuSkGELIlQAAAAAPuLl4M987.jpg", image3 = "http://img.ef43.com.cn/product/2016/8/05100204b0c.jpg", price = 165, sales = 45, title = "娇诗茹 ulzzang原宿风学生潮韩版春夏短" }, new Goods() { image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553187020783&di=bac9dd78b36fd984502d404d231011c0&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201609%2F26%2F20160926173213_s5adi.jpeg", image2 = "http://image5.suning.cn/uimg/b2c/newcatentries/0070158827-000000000622091973_2_800x800.jpg", image3 = "http://img.61ef.cn/news/201903/20/2019032009251784.jpg", price = 179, sales = 94, title = "古黛妃 短袖t恤女夏装2019新款韩版宽松" }, new Goods() { image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553187020783&di=bac9dd78b36fd984502d404d231011c0&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201609%2F26%2F20160926173213_s5adi.jpeg", image2 = "http://pic.rmb.bdstatic.com/819a044daa66718c2c40a48c1ba971e6.jpeg", image3 = "http://img001.hc360.cn/y5/M00/1B/45/wKhQUVYFE0uEZ7zVAAAAAMj3H1w418.jpg", price = 179, sales = 61, title = "古黛妃 短袖t恤女夏装2019新款韩版宽松" }, new Goods() { image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553187020783&di=bac9dd78b36fd984502d404d231011c0&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201609%2F26%2F20160926173213_s5adi.jpeg", image2 = "http://pic.rmb.bdstatic.com/819a044daa66718c2c40a48c1ba971e6.jpeg", image3 = "http://img001.hc360.cn/y5/M00/1B/45/wKhQUVYFE0uEZ7zVAAAAAMj3H1w418.jpg", price = 179, sales = 61, title = "古黛妃 短袖t恤女夏装2019新款韩版宽松" }, new Goods() { image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553187020783&di=bac9dd78b36fd984502d404d231011c0&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201609%2F26%2F20160926173213_s5adi.jpeg", image2 = "http://pic.rmb.bdstatic.com/819a044daa66718c2c40a48c1ba971e6.jpeg", image3 = "http://img001.hc360.cn/y5/M00/1B/45/wKhQUVYFE0uEZ7zVAAAAAMj3H1w418.jpg", price = 179, sales = 61, title = "古黛妃 短袖t恤女夏装2019新款韩版宽松" }, new Goods() { image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1553187020783&di=bac9dd78b36fd984502d404d231011c0&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201609%2F26%2F20160926173213_s5adi.jpeg", image2 = "http://pic.rmb.bdstatic.com/819a044daa66718c2c40a48c1ba971e6.jpeg", image3 = "http://img001.hc360.cn/y5/M00/1B/45/wKhQUVYFE0uEZ7zVAAAAAMj3H1w418.jpg", price = 179, sales = 61, title = "古黛妃 短袖t恤女夏装2019新款韩版宽松" } };

                    ShoppingMallIndexModel  indexModel = new ShoppingMallIndexModel();
                    indexModel.carouselList = carouselList;
                    indexModel.goodsList = goodsList;

                    model.ret = 0;
                    model.Result = "请求成功";
                    model.Content = indexModel;

                    return model;
                });

            });
        }

        /// <summary>
        /// 获取首页信息
        /// </summary>
        /// <returns></returns>
        [Route("GetGoodData")]
        [HttpPost]
        public async Task<JSONResult<DetailData>> GetGoodData([FromBody] int ID)
        {
            return await Task.Run(() =>
            {
                return new BaseJsonResult().UnifiedFucn(() =>
                {
                    var model = new JSONResult<DetailData>();
                    model.Success = true;
            DetailData data = new DetailData() { ID = ID, favorite=true, imgList="测试", title= "纯种金毛幼犬活体有血统证书", title2="拆家小能手 你值得拥有" };
                    model.ret = 0;
                    model.Result = "请求成功";
                    model.Content = data;
                    return model;
                });

            });
        }
    }
}
