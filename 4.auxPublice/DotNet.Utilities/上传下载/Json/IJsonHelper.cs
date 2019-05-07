using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    public interface IJsonHelper
    {
        string Serialize(object obj);


        T Deserialize<T>(string json) where T : class;


    }
}
