using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Grafo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var origins = WebConfigurationManager.AppSettings["cors-origins"];

            if (origins == null)
            {
                throw new Exception("Origens de requisição não registradas.");
            }


            EnableCorsAttribute cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);


            //config.Filters.Add(new ExceptionHandlingAttribute());

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;


            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
