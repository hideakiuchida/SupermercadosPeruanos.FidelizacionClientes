using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.CanjePuntos.ActionFilters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" }
                });
        }
    }
}