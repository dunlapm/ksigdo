using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KsigDo.Web.Models;

namespace KsigDo.Web {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.MapHubs();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            InitDatabase();
        }


        void InitDatabase() {
            Database.SetInitializer<KsigDoContext>(new DropCreateDatabaseIfModelChanges<KsigDoContext>());

            using (var context = new KsigDoContext()) {
                if (context.Tasks.Count() == 0) {
                    context.Tasks.Add
                        (
                        new Task() {
                            title = "Need to buy my milk",
                            lastUpdated = DateTime.Now,
                        }
                    );

                    context.Tasks.Add
                        (
                        new Task() {
                            title = "Call my wife",
                            lastUpdated = DateTime.Now,
                        }
                    );
                }
            }
        }




    }
}