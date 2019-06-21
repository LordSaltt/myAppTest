using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Reflection;
using System.Web.Http;
using Ninject.Extensions.Conventions;
using System.Net.Http.Formatting;

namespace my_app.Host
{
    public class startup
    {
        public void Configuration(IAppBuilder appbuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            appbuilder.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(httpConfiguration);

            httpConfiguration.Formatters.Clear();
            httpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());


        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind(x => { });

            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            return kernel;
        }

    }
}