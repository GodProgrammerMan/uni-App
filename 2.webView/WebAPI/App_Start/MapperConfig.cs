using AutoMapper;
using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.App_Start
{
    public class MapperConfig
    {
        public static void CreateMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoProfile>();
            });
        }
    }
}