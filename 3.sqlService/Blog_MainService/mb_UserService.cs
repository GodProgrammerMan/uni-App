using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MainService
{
    public class mb_UserService
    {
        SqlSugarClient db = DBHelper.DBBase.Blog_MainDBConnection();

        public Blog_Main.Model.mb_User GetUserLogin(string loginName)
        {

            var  Model = db.Queryable<Blog_Main.Model.mb_User>().Where(t => t.UserNo == loginName && t.IsShow == true && t.IsCheck == true).First();
            if (Model != null && Model.UserId == 0)
                return null;
            return Model;
        }
    }
}
