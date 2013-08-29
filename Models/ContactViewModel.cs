/*
 * Created by SharpDevelop.
 * User: Maura
 * Date: 11/3/2012
 * Time: 3:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PerfectPlacement.Models
{
	/// <summary>
	/// Description of ContactFormModel.
	/// </summary>
	public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
 
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
 
        [Required(ErrorMessage = "Please enter your message to us.")]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
	
	public class ApplyViewModel
	{
		[Required(ErrorMessage = "Please enter your first name.")]
		[Display(Name = "* First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "* Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "* Email Address")]
        public string EmailAddress { get; set; }
 
        [Display(Name = "Message (Optional)")]
        public string Message { get; set; }
	}
}
