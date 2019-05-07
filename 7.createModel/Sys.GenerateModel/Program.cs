using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.GenerateModel
{
    class Program
    {
        static void Main(string[] args)
        {
            //取解决方案根目录
            string objecturl = Environment.CurrentDirectory.ToString().ToLower().Replace(@"\实体生成\sys.generatemodel\bin\debug", "");
            var service = new CongifService();
            service.InitdbModelForChooseHouse(objecturl + @"\实体层Model\Blog_Main.Model");//选房系统 
        }
    }
}
