using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Code.AutoMapper
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ModelProfile>(); });//增加对 ModelProfile的初始化

            Mapper.AssertConfigurationIsValid();
        }
    }
}
