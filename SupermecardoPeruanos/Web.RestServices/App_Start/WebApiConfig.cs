﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.RestServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{tipo}/{cantidad}/{pagina}",
                defaults: new { id = RouteParameter.Optional,
                                tipo = RouteParameter.Optional,
                                cantidad = RouteParameter.Optional,
                                pagina = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
            new { id = RouteParameter.Optional });
            //config.Routes.MapHttpRoute("API Carrito", "api/{controller}/{action}/{ids}",
            //new { ids = RouteParameter.Optional });
        }
    }
}
