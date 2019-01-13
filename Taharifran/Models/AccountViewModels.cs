using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taharifran.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class ChangeInfoViewModel
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Invalid Firstname, use letters A-Z")]
        [Display(Name="Firstname")]
        public string Firstname { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Invalid Lastname, use letters A-Z")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name ="Age")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Invalid, use letters A-Z")]
        [Display(Name = "Describe yourself with one word..")]
        public string Description { get; set; }

    }

   
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Invalid Firstname, use letters A-Z")]
        public string Firstname { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Invalid Lastname, use letters A-Z")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Invalid, use letters A-Z")]
        [Display(Name = "Describe yourself with one word..")]
        public string Description { get; set; }
        
        [Display(Name = "User Photo")]
        public byte [] UserPhoto { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }


}
