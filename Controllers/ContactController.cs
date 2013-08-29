using System;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

using PerfectPlacement.Models;

namespace PerfectPlacement.Controllers
{
	/// <summary>
	/// Description of ContactController.
	/// </summary>
	[HandleError]
	public class ContactController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Success()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Contact(ContactViewModel contactViewModel)
		{
		    if (!ModelState.IsValid)
		    {
		    	
	    		foreach(var error in ViewData.ModelState["FullName"].Errors)
		    	{
		    		ModelState.AddModelError(String.Empty, error.ErrorMessage);
		    	}
	    		foreach(var error in ViewData.ModelState["EmailAddress"].Errors)
		    	{
		    		ModelState.AddModelError(String.Empty, error.ErrorMessage);
		    	}
    			foreach(var error in ViewData.ModelState["Message"].Errors)
		    	{
		    		ModelState.AddModelError(String.Empty, error.ErrorMessage);
		    	}
		    	
		    	
		        return View("Index", contactViewModel);
		    }
		    StringBuilder body = new StringBuilder();
		    body.AppendLine("New Correspondence From perfectplacementservices.com:<br/>");
		    body.AppendFormat("Name : {0}<br/>", contactViewModel.FullName).AppendLine();
		    body.AppendFormat("Message: {0}", contactViewModel.Message.Replace("\r\n", "<br/>")).AppendLine();
		    
		    MailAddress from = new MailAddress(contactViewModel.EmailAddress, contactViewModel.FullName);
			MailAddressCollection toCollection = new MailAddressCollection();
			MailAddress to = new MailAddress("solutions@pps-az.com");
			toCollection.Add(to);
		    MailMessage message = new MailMessage();
			message.From = from;
			message.Body = body.ToString();
			message.To.Add(to);
			message.IsBodyHtml = true;
			message.Subject = "New Correspondence From perfectplacementservices.com";
			
			
			
			EmailService.SendEmail(message);
		
		    return RedirectToAction("Success");
		}
	}
	
}