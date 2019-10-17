using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebEDI.Respository.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string PassWord { get; set;}
        [Required(ErrorMessage = "Company code is required")]
        public string CompanyCode { get; set;}
    }
    public class LoginModelExtension
    {
        public string UserName { get; set; }
        public string Role { get; set;}
        public string DateLoginFirst { get; set;}
        public string DateLoginNow { get; set;}
        public string AccessToken { get; set; }
        public string CompanyName { get; set; }
    }
}
