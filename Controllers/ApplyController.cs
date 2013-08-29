using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

using PerfectPlacement.Models;

namespace PerfectPlacement.Controllers
{
	/// <summary>
	/// Description of ApplyController.
	/// </summary>
	public class ApplyController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Success()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult SubmitApplication(ApplyViewModel applyViewModel, HttpPostedFileBase file)
		{
			if (String.IsNullOrEmpty(applyViewModel.Message) && file == null)
			{
				ModelState.AddModelError(String.Empty, "Please upload your résumé.");
			}
			
		    if (!ModelState.IsValid)
		    {
		    	
	    		foreach(var error in ViewData.ModelState["FirstName"].Errors)
		    	{
		    		ModelState.AddModelError(String.Empty, error.ErrorMessage);
		    	}
	    		foreach(var error in ViewData.ModelState["LastName"].Errors)
		    	{
		    		ModelState.AddModelError(String.Empty, error.ErrorMessage);
		    	}
    			foreach(var error in ViewData.ModelState["EmailAddress"].Errors)
		    	{
		    		ModelState.AddModelError(String.Empty, error.ErrorMessage);
		    	}
		    	
		    	
		        return View("Index", applyViewModel);
		    }
		 
		    StringBuilder body = new StringBuilder();
		    body.AppendLine("New Application Received From Website<br/><br/>");
		    body.AppendFormat("First Name : {0}<br/>", applyViewModel.FirstName).AppendLine();
		    body.AppendFormat("Last Name : {0}<br/>", applyViewModel.LastName).AppendLine();
		    if (!String.IsNullOrEmpty(applyViewModel.Message))
	        {
	        	body.AppendFormat("Message : {0}<br/>", applyViewModel.Message.Replace("\r\n", "<br/>")).AppendLine();
	        }
		    
		    
		    String fullName = String.Format("{0} {1}", applyViewModel.FirstName, applyViewModel.LastName);
		    string fromAddress = applyViewModel.EmailAddress;
			
			MailAddress from = new MailAddress(fromAddress, fullName);

			MailMessage message = new MailMessage();
			message.From = from;
			message.Body = body.ToString();
			message.To.Add(new MailAddress("resume@pps-az.com"));
			message.IsBodyHtml = true;
			message.Subject = "New Application Received From Website";
			
			if (file != null && file.ContentLength > 0)
			{
				message.Attachments.Add(new Attachment(file.InputStream, System.IO.Path.GetFileName(file.FileName)));
			}
			
			EmailService.SendEmail(message);
			
		 
		    return View("Success");
		}
	}
	
	
}