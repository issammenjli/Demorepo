using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Diagnostics;

namespace POC.SSO
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// Get the current User repository for user authentication
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        protected void Application_PostAuthenticateRequest(object s, EventArgs e)
        {
            // Get current Authentication interface & Http context
            HttpContextWrapper context = new HttpContextWrapper(HttpContext.Current);

            CheckCurrentUser(context);
        }

        /// <summary>
        /// Checks the current user.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void CheckCurrentUser(HttpContextBase context)
        {
            if (context.Request.IsAuthenticated)
            {
                Debug.WriteLine("Authenticated");

                
               
            }

        }
    }
}