using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace InternetShop.Filters
{
    public class ShopAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple { get { return false; } }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            context.Principal = null;
            AuthenticationHeaderValue authenticationHeader = context.Request.Headers.Authorization;
            if (authenticationHeader != null && authenticationHeader.Scheme == "Basic")
            {
                string[] authData = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(authenticationHeader.Parameter)).Split(':');
                string[] roles = new string []{ "user"};
                string login = authData[0];
                context.Principal = new GenericPrincipal(new GenericIdentity(login), roles);
            }
            if (context.Principal == null)
            {
                context.ErrorResult =
                    new UnauthorizedResult(new AuthenticationHeaderValue[] 
                    { new AuthenticationHeaderValue("Basic") }, context.Request);
            }
            return Task.FromResult<object>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, 
            CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
    }
}