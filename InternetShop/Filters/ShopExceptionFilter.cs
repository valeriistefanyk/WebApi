using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace InternetShop.Filters
{
    public class ShopExceptionFilter : Attribute, IExceptionFilter
    {
        public bool AllowMultiple
        {
            get { return false; }
        }

        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null && 
                actionExecutedContext.Exception is IndexOutOfRangeException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Unknown exception");
            }
        }
    }
}