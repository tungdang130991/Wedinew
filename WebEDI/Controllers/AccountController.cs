using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;
using WebEDI.Common.Core;
using Microsoft.Extensions.Configuration;
using WebEDI.Respository.Services;
using Microsoft.EntityFrameworkCore;
using WebEDI.Respository.Entity;
using WebEDI.Common;
using WebEDI.ServiceExtension;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace WebEDI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _IUserService { get; set; }
        private IConfiguration _configuration;
        private readonly IStringLocalizer<Resources> _localizer;
        private IShiiresakiService _ShiiresakiService { get; }
        public AccountController(IUserService userService,IConfiguration configuration, IStringLocalizer<Resources> localizer, IShiiresakiService shiiresakiService)
        {
            _IUserService = userService;
            _configuration = configuration;
            _localizer = localizer;
            _ShiiresakiService = shiiresakiService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel usermodel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Home/Index");
            string cookietimeout = _configuration.GetSection("AppSettings").GetSection("CookieUserTimeOut").Value;
            if (ModelState.IsValid)
            {
                try
                {
                    if (_IUserService.CheckConnection().Result)
                    {
                        var user = await _IUserService.GetUserByUserName(usermodel.UserName, usermodel.CompanyCode);
                        if (user != null)
                        {
                            var shiiresakien = _ShiiresakiService.GetAllList().Result.FirstOrDefault(x => x.FShiiresakiCd == user.FShiiresakiCd);
                            shiiresakien = shiiresakien != null ? shiiresakien : new TtWebShiiresaki();
                            string passwordhash = Crypto.Hash(usermodel.PassWord);
                            if (user.FPasuwado != passwordhash)
                            {
                                return Json(new { status = false, errorcodes = ErrorCodes.AccountInvalidPassWord, message = _localizer["E.SS_WE000010.003"].Value });
                            }
                            else
                            {
                                DateTime dateparse = WebEDI.Common.Core.Utility.ConvertToDateTime(user.FSaishuuRoguinNichiji);
                                var userId = Guid.NewGuid().ToString();
                                var claims = new List<Claim>
                                  {
                                     new Claim(ClaimTypes.Name, usermodel.UserName),
                                     new Claim("access_token", GetAccessToken(userId)),
                                     new Claim("dateloginfirst",dateparse.ToString("yyyy/MM/dd HH:mm:ss")),
                                     new Claim ("dateloginnow",DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                                     new Claim("f_edi_roguin_yuza_id", user.FEdiRoguinYuzaId != null? user.FEdiRoguinYuzaId.ToString():""),
                                     new Claim("f_edi_roguin_yuza_no", user.FEdiRoguinYuzaNo != null? user.FEdiRoguinYuzaNo.ToString():""),
                                     new Claim("f_rotsuku_kubun",user.FRotsukuKubun!=null?user.FRotsukuKubun:""),
                                     new Claim("f_jisha_shiiresaki_kubun",user.FJishaShiiresakiKubun!=null? user.FJishaShiiresakiKubun:""),
                                     new Claim("f_shiiresaki_cd",user.FShiiresakiCd!=null?user.FShiiresakiCd:""),
                                     new Claim("f_tantousha_mei",user.FTantoushaMei!=null?user.FTantoushaMei:""),
                                     new Claim("f_meruadoresu", user.FMeruadoresu !=null? user.FMeruadoresu:""),
                                     new Claim("f_meru_soushin_kubun",user.FMeruSoushinKubun!=null?user.FMeruSoushinKubun:""),
                                     new Claim("f_yuza_bikou", user.FYuzaBikou!=null? user.FYuzaBikou:""),
                                     new Claim("f_saishuu_roguin_nichiji", user.FSaishuuRoguinNichiji != null? user.FSaishuuRoguinNichiji.ToString():""),
                                     new Claim("f_edi_shiiresaki_id",  shiiresakien.FEdiShiiresakiId!=null? shiiresakien.FEdiShiiresakiId.ToString():""),
                                     new Claim("f_shiiresaki_mei",shiiresakien.FShiiresakiMei!=null?shiiresakien.FShiiresakiMei:""),
                                     new Claim("f_edi_chuumonsho_kingakuhyouji_kubun", shiiresakien.FEdiChuumonshoKingakuhyoujiKubun!=null?shiiresakien.FEdiChuumonshoKingakuhyoujiKubun:""),
                                     new Claim("f_edi_nouhinmeisai_shoukaihyouji_kubun", shiiresakien.FEdiNouhinmeisaiShoukaihyoujiKubun!=null?shiiresakien.FEdiNouhinmeisaiShoukaihyoujiKubun:""),
                                     new Claim("f_hatsuchuu_edi_soushin_kubun", shiiresakien.FHatsuchuuEdiSoushinKubun!=null?shiiresakien.FHatsuchuuEdiSoushinKubun:""),
                                     new Claim("f_toiawase_tantousha_mei",shiiresakien.FToiawaseTantoushaMei!=null?shiiresakien.FToiawaseTantoushaMei:""),
                                     new Claim("f_toiawase_tel", shiiresakien.FToiawaseTel!=null?shiiresakien.FToiawaseTel:""),
                                     new Claim("f_toiawase_fax", shiiresakien.FToiawaseFax!=null?shiiresakien.FToiawaseFax:""),
                                     new Claim("f_shiiresaki_bikou1",shiiresakien.FShiiresakiBikou1!=null?shiiresakien.FShiiresakiBikou1:""),
                                     new Claim("f_shiiresaki_bikou2", shiiresakien.FShiiresakiBikou2!=null?shiiresakien.FShiiresakiBikou2:""),

                                  };
                                if (user.FJishaShiiresakiKubun == "01")
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                                }
                                else
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                                }
                                var claimsIdentity = new ClaimsIdentity(
                                  claims, CookieAuthenticationDefaults.AuthenticationScheme);
                                var authProperties = new AuthenticationProperties
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(Convert.ToInt16(cookietimeout))
                                };

                                await HttpContext.SignInAsync(
                                  CookieAuthenticationDefaults.AuthenticationScheme,
                                  new ClaimsPrincipal(claimsIdentity),
                                  authProperties);

                                // Update date login user
                                 user.FSaishuuRoguinNichiji = DateTime.Now;
                                _IUserService.UpdateInfoUser(user);
                                return Json(new { status = true, message = _localizer["I.SS_WE000010.004"].Value, url = returnUrl });
                            }
                        }
                        else
                        {
                            return Json(new { status = false, errorcodes = ErrorCodes.AccountInvalidUsername, message = _localizer["E.SS_WE000010.002"].Value });
                        }
                    }
                    else
                    {
                        return Json(new { status = false, errorcodes= ErrorCodes.DBConnectionFailed, message = _localizer["E.SS_WE000010.001"].Value });
                    }
               
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    return Json(new { status = false, message = ex.Message});
                }
            }
            return  Json(new { status = false, message = "Model not IsValid !" });

        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
              CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login","Account");
        }
        private string GetAccessToken(string userId)
        {
            string issuer = _configuration.GetSection("AppSettings").GetSection("jwtIssuer").Value;
            string audience = _configuration.GetSection("AppSettings").GetSection("jwtAudience").Value;
            string cookietimeout = _configuration.GetSection("AppSettings").GetSection("CookieUserTimeOut").Value;


            var identity = new ClaimsIdentity(new List<Claim>
              {
                new Claim("sub", userId)
              });

            var bytes = Encoding.UTF8.GetBytes(userId);
            var key = new SymmetricSecurityKey(bytes);
            var signingCredentials = new SigningCredentials(
              key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(
              issuer, audience, identity,
              now, now.Add(TimeSpan.FromHours(Convert.ToInt16(cookietimeout))),
              now, signingCredentials);

            return handler.WriteToken(token);
        }
    }
}