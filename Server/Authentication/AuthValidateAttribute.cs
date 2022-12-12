using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CDPModule1.Server.Authentication
{
        public class AuthValidateAttribute : AuthorizationFilterAttribute
        {
            private readonly string _realm;
       
        public AuthValidateAttribute(string realm, IConfiguration configuration)
            {
                _realm = realm;
                if (string.IsNullOrWhiteSpace(_realm))
                {
                    throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
                }
            }

            public override void OnAuthorization(HttpActionContext actionContext)
            {

                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    // Gets header parameters  
                    string? authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                    string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                    // Gets username and password  
                    string usrename = originalString.Split(':')[0];
                    string password = originalString.Split(':')[1];

                    // Validate username and password  
                    if (!UserValidate.IsValid(usrename, password))
                    {
                        // returns unauthorized error  
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(usrename), null);
                    }
                }

                base.OnAuthorization(actionContext);
            }

       
    }
}