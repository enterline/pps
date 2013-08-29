/*
 * Created by SharpDevelop.
 * User: Maura
 * Date: 10/6/2012
 * Time: 12:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PerfectPlacement
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				"post-contact",
				"contact",
				new {
					controller = "Contact",
					action = "Contact",
					id = UrlParameter.Optional
				},
				new { httpMethod = new HttpMethodConstraint("POST") });
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				});
//			routes.MapRoute(
//				"get-home",
//				"{controller}/{action}/{id}",
//				new {
//					controller = "Home",
//					action = "Home",
//					id = UrlParameter.Optional
//				});
//			routes.MapRoute(
//				"get-jobs",
//				"{controller}/{action}/{id}",
//				new {
//					controller = "Jobs",
//					action = "Index",
//					id = UrlParameter.Optional
//				});
//			routes.MapRoute(
//				"get-about",
//				"{controller}/{action}/{id}",
//				new {
//					controller = "AboutUs",
//					action = "Index",
//					id = UrlParameter.Optional
//				});
//			routes.MapRoute(
//				"ComingSoon",
//				"{controller}/{action}/{id}",
//				new {
//					controller = "ComingSoon",
//					action = "Index",
//					id = UrlParameter.Optional
//				});
			
			
		}
		
		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
		}
	}
}
