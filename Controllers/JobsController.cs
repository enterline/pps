using System;
using System.Web.Mvc;

namespace PerfectPlacement.Controllers
{
	/// <summary>
	/// Description of ServicesController.
	/// </summary>
	public class JobsController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

        public ActionResult JobSearch()
        {
            return View();
        }
	}
}