using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InternetShop.Filters
{
    public class ShopExtendedActionFilter : ActionFilterAttribute
    {
        DateTime start;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            start = DateTime.Now;
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            DateTime end = DateTime.Now;

            actionExecutedContext.Response.Headers.Add("Start-Time", start.ToLongDateString());
            actionExecutedContext.Response.Headers.Add("End-Time", end.ToLongDateString());
        }
    }


    //public class Ext : ActionFilterAttribute
    //{
    //    DateTime start;

    //    public override void OnActionExecuting(HttpActionContext actionContext)
    //    {
    //        base.OnActionExecuting(actionContext);

    //        start = DateTime.Now;
    //    }

    //    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    //    {
    //        base.OnActionExecuted(actionExecutedContext);

    //        DateTime end = DateTime.Now;

    //        actionExecutedContext.Response.Headers.Add("Start-Time", start.ToLongTimeString());
    //        actionExecutedContext.Response.Headers.Add("End-Time", end.ToLongTimeString());
    //    }
    //}
}