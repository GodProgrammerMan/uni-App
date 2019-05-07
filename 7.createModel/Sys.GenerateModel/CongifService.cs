

using DBHelper;

namespace Sys.GenerateModel
{
    public class CongifService
    {


        /// <summary>
        /// 初始化ZpMain对象模型数据库
        /// </summary>
        /// <param name="path">路径</param>
        public void InitdbModelForChooseHouse(string path)
        {
            var db = DBBase.Blog_MainDBConnection();
            db.DbFirst.CreateClassFile(path, "Blog_Main.Model");
        }
     

    }
}
