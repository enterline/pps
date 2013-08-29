/*
 * Created by SharpDevelop.
 * User: Maura
 * Date: 11/3/2012
 * Time: 3:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Mail;

namespace PerfectPlacement
{
	/// <summary>
	/// Description of Email.
	/// </summary>
	public class Email
	{
		public Email()
		{
		}
		
		public void Send(Contact contact)
        {
//            MailMessage mail = new MailMessage(                
//               "solutions@pps-az.com",
//                "solutions@pps-az.com",
//                "testing",
//                "test message");
//			new SmtpClient("smtp.secureserver.net").Send(mail);
            //new SmtpClient().
            string fromAddress = "solutions@pps-az.com";
			string sendToAddress = "solutions@pps-az.com";
			SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
			MailAddress from = new MailAddress(fromAddress);
			MailAddress to = new MailAddress(sendToAddress);
			MailMessage message = new MailMessage(from, to);
			message.Body = "This is a test";
			message.IsBodyHtml = true;
			message.Subject = "Submission";
			client.Send(message);
        }
	}
	
	public class Contact
    {
        public string Name { get; set; }
        
        public string FromEmailAddress { get; set; }
        
        public string ToEmailAddress { get; set; }
 
        public string Subject { get; set; }
 
        public string Message { get; set; }
    }
	
	// TODO : Change from static class to use interface and IoC
	/// <summary>
	/// Email Service
	/// </summary>
	public static class EmailService
	{
		public static void SendEmail(MailMessage mailMessage)
		{
			SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
			client.Send(mailMessage);
		}
	}
}
