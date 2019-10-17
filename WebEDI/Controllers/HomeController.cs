using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using WebEDI.Common.Core;
using WebEDI.Models;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;

namespace WebEDI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class HomeController : Controller
    {

        private IUserService _IUserService { get;}
        private IShiiresakiService _ShiiresakiService { get; }
        private IConfiguration _configuration;
        public HomeController(IUserService userService, IShiiresakiService shiiresakiService, IConfiguration configuration)
        {
            _IUserService = userService;
            _ShiiresakiService = shiiresakiService;
            _configuration = configuration;
        }

        [Authorize]
        public IActionResult Index()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            
            LoginModelExtension modelView = new LoginModelExtension();
            if (principal != null)
            {
                modelView.UserName = HttpContext.User.Identity.Name;
                modelView.Role = principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                modelView.DateLoginFirst = principal?.Claims.FirstOrDefault(c => c.Type == "dateloginfirst").Value;
                modelView.DateLoginNow = principal?.Claims.FirstOrDefault(c => c.Type == "dateloginnow").Value;
                modelView.AccessToken = principal?.Claims.FirstOrDefault(c => c.Type == "access_token").Value;
            }
            return View(modelView);
        }

        public  IActionResult _CompanyNameLayout()
        {
            string companyName = _configuration.GetSection("AppSettings").GetSection("CompanyName").Value;
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            LoginModelExtension modelView = new LoginModelExtension();
            var user = _IUserService.GetAll().Result.FirstOrDefault(x => x.FYuzaId == HttpContext.User.Identity.Name);
            var shiiresakien = _ShiiresakiService.GetAllList().Result.FirstOrDefault(x => x.FShiiresakiCd == user.FShiiresakiCd);
            if(shiiresakien != null)
            {
                companyName = shiiresakien.FShiiresakiMei;
            }
            TempData["FShiiresakiMei"] = companyName;
            return PartialView("_CompanyNameLayout");
        }


        public IActionResult Privacy()
        {
        
            string[] folders = { "wwwroot\\css", "wwwroot\\js" };
            string[] names = { "css.zip", "js.zip" };
            string[] files = { "wwwroot\\css\\Login.css", "wwwroot\\css\\site.css" };

            //return File(FileUtils.ZipMultiFolders(folders,names), "application/zip", "temp.zip");
            return File(FileUtils.ZipMultiFiles(files), "application/zip", "temp.zip");
        }

        [HttpPost]
        public IActionResult Export()
        {
            FileStream fileStream = new FileStream("wwwroot\\Content\\editnew.txt", FileMode.Open);
            var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            fileStream.Flush();
            fileStream.Close();
            memoryStream.Position = 0;
            return File(memoryStream, "application/csv","data.csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (ex != null)
            {
                Log.Logger.Error(ex.Error, ex.Path);
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }     
    }
}
