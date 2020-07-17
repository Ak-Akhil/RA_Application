using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RA_App.Models
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

    public class RegisterViewModel
    {
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Name should be between 2 to 40 Characters")]
        [Required(ErrorMessage = "The employee name is required")]
        [Display(Name = "Employee Name")]
        public string Emp_Name { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname should be between 2 to 50 Characters")]
        [Required(ErrorMessage = "The Employee surname is required")]
        [Display(Name = "Employee Surname")]
        public string Emp_Surname { get; set; }


        [StringLength(13, MinimumLength = 13, ErrorMessage = "Please enter a valid ID number (13 Digits)")]
        [Required(ErrorMessage = "ID number is required")]
        [Display(Name = "ID Number")]
        public string Emp_IDNum { get; set; }
        //which year they are in

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please enter a valid phone number")]
        [Required(ErrorMessage = "The student's contact number is required")]
        [Display(Name = "Contact Number")]
        public string Emp_ContactNo { get; set; }



        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }







        [Display(Name = "Role")]
        public string Role_Name { get; set; }
        public virtual RoleViewModel RoleViewModel { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "The password and confirmation password do not match.")]
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
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
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
