﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InternetShop.Filters
{
    public class ShopAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get { return false; } }

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, 
            CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            return Task.FromResult<HttpResponseMessage>(
                actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
        }
    }
}