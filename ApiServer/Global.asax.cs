using ApiServer.Domain.Interfaces;
using ApiServer.Domain.Services;
using ApiServer.Infra.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Http;


namespace ApiServer
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterWebApi();
            RegisterDependencyInjection();
            ResponseFormat();

        }

        private static void ResponseFormat()
        {
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Permitir solicitações de qualquer origem, métodos e cabeçalhos
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.StatusCode = 200;
                HttpContext.Current.Response.End();
            }
        }

        private void RegisterWebApi()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterDependencyInjection()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types using the scoped lifestyle
            container.Register<IInvestimentoService, InvestimentoServices>(Lifestyle.Scoped);
            container.Register<ICDIRepository, CDIRepository>(Lifestyle.Scoped);
            container.Register<ITBRepository, TBRepository>(Lifestyle.Scoped);
            container.Register<IImpostoRepository, ImpostoRepository>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

    }
}
