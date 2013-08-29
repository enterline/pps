using System;
using System.Web.Mvc;

namespace PerfectPlacement.Controllers
{
	/// <summary>
	/// Description of ErrroController.
	/// </summary>
	public class ErrorController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult NotFound()
		{
			return View();
		}
	}
}