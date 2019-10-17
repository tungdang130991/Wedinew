using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;

namespace WebEDI.ViewComponents
{
    public class CompanyViewComponent : ViewComponent
    {
        private IUserService _IUserService { get; }
        private IShiiresakiService _ShiiresakiService { get; }
        private IConfiguration _configuration;
        public CompanyViewComponent(IUserService userService, IShiiresakiService shiiresakiService, IConfiguration configuration)
        {
            _IUserService = userService;
            _ShiiresakiService = shiiresakiService;
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string companyName = _configuration.GetSection("AppSettings").GetSection("CompanyName").Value;
            LoginModelExtension modelView = new LoginModelExtension();
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            if (principal != null)
            {
                var f_shiiresaki_mei = principal?.Claims.FirstOrDefault(c => c.Type == "f_shiiresaki_mei");
                if (f_shiiresaki_mei != null)
                {
                    companyName = f_shiiresaki_mei.Value;
                }
                
            }
            if (principal != null)
            {
                modelView.UserName = HttpContext.User.Identity.Name;
                modelView.Role = principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                modelView.DateLoginFirst = principal?.Claims.FirstOrDefault(c => c.Type == "dateloginfirst").Value;
                modelView.DateLoginNow = principal?.Claims.FirstOrDefault(c => c.Type == "dateloginnow").Value;
                modelView.AccessToken = principal?.Claims.FirstOrDefault(c => c.Type == "access_token").Value;
                modelView.CompanyName = companyName!=null?companyName:"";
            }
            return View(modelView);
        }
    }
}
