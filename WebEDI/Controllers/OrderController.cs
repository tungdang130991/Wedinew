using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEDI.Respository.Entity;
using WebEDI.Respository.Interface;
using Microsoft.Extensions.Configuration;
using WebEDI.Respository.ViewModels;
using WebEDI.Utility;
using WebEDI.Common.Core;
using Serilog;
using WebEDI.Common;
using Microsoft.Extensions.Localization;

namespace WebEDI.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _OrderService { get; set; }
        public IConfiguration configuration;
        private IViewRenderService _viewRenderService { get; set; }
        public IStringLocalizer<Resources> StringLocalizer { get; set; }
        public OrderController(IConfiguration Config, IOrderService _order, IViewRenderService viewRenderService, IStringLocalizer<Resources> stringLocalizer)
        {
            _OrderService = _order;
            configuration = Config;
            _viewRenderService = viewRenderService;
            StringLocalizer = stringLocalizer;
        }
        public IActionResult Index()
        {
            ViewBag.DropSearch = _OrderService.GetDrops();
            return View(_OrderService.GetTable());
        }
        public async Task<JsonResult> SearchOrder(string _id, DateTime _dateorder, DateTime _dateend,string _check)
        {
            string html = "";
            var supliername = "";
            try {
                List<OrderModel> ordermodel = _OrderService.SearchOrder(_id, _dateorder, _dateend,_check);
                if(_id!="" && _id!=null)
                {
                    supliername = ordermodel.Select(x => x.FShiiresakiMei).Distinct().FirstOrDefault();
                }
                if(ordermodel.Count>1000)
                {
                    return Json(new { status = 1, message = StringLocalizer["E.SS_WE000004.005"].Value, html });
                }
                html = await _viewRenderService.RenderViewToStringAsync("~/Views/Order/_List.cshtml", ordermodel);
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex, "Failed to send mail.");
            }
            return Json(new { status =0, html,supliername });
        }
        public JsonResult SendMail(string _id)
        {
           ErrorCodes result;
            try { 
            result = _OrderService.SendMail(_id);
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex, "Failed to send mail.");
                result = ErrorCodes.SendMailFail;
            }
            string msg = (result == ErrorCodes.None) ? StringLocalizer["I.SS_WE000004.003"].Value
                                                     : StringLocalizer["E.SS_WE000004.002"].Value;
            return Json(new { status = (result == ErrorCodes.None) ? 0 : 1, message = msg });
        }
    }
}