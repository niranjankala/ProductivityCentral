using Autofac;
using Autofac.Integration.Mvc;
using ProductivityCentral.Environment;
using ProductivityCentral.FileStorage;
using ProductivityCentral.Logging;
using ProductivityCentral.Web.Services;
//using Microsoft.Owin.Security;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCentral.Web
{
    /// <summary>
    /// The main class <c>AutofacConfig</c>.
    /// Provides Autofac DI configuration of the API.
    /// </summary>
    public static class AutofacConfig
    {

        #region Autofac Container
        private static Lazy<IContainer> builder =
          new Lazy<IContainer>(() =>
          {
              var autofacbuilder = new ContainerBuilder();
              RegisterTypes(autofacbuilder);
              return autofacbuilder.Build();
          });

        /// <summary>
        /// Configured Autofac Container.
        /// </summary>
        public static IContainer Container => builder.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the autofac container builder.
        /// </summary>
        /// <param name="builder">The autofac container builder to configure.</param>
        /// <remarks>
        /// </remarks>
        public static void RegisterTypes(ContainerBuilder builder)
        {
           string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + "bin";
            if (!Directory.Exists(baseDirectoryPath))
                baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

            builder.RegisterModule(new EnvironmentModule());
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new FileStoreModule());
            //API Controllers Registration
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            //builder.RegisterType<GlobalExceptionLogger>().InstancePerLifetimeScope();

            var assemblies = Directory.EnumerateFiles(baseDirectoryPath, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("ProductivityCentral"))
                .Select(Assembly.LoadFrom).Where(assemblyType =>
                (assemblyType.FullName.StartsWith("ProductivityCentral") && !assemblyType.FullName.Contains("ProductivityCentral.Framework") &&
                !assemblyType.FullName.Contains("ProductivityCentral.Web")
                )).ToArray();

            builder.RegisterType<OperatorReportService>().As<IOperatorReportService>().InstancePerLifetimeScope();
            //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();            

            builder.RegisterAssemblyTypes(assemblies)
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<App_Start.MVCGridConfig>().InstancePerLifetimeScope();
        }
    }
}