using Autofac;
using ProductivityCentral.Environment.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ProductivityCentral.Environment
{
    public class EnvironmentModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            
            builder.RegisterType<AppConfigurationAccessor>().As<IAppConfigurationAccessor>().SingleInstance();
        }
    }
}
