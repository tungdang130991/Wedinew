using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEDI.Respository.ViewModels;
using WebEDI.Respository.Interface;
using Microsoft.AspNetCore.Hosting;
using WebEDI.Common.Core;
using System.IO;
namespace WebEDI.Controllers
{
    public class OrderDetailController : Controller
    {
        public IOrderDetailService _IOrderDetailService { get; set; }
        public IHostingEnvironment _IHostingEnvironment { get; set; }
        public IActionResult Index()
        {
            var orderid = HttpContext.Request.Query["orderid"];
            //List<OrderDetailModel> ListOrderDetail = _IOrderDetailAllService.GetData("00002").listOrderDetail;
            OrderDetailAllModel Order = _IOrderDetailService.GetData(orderid);
            decimal SumAmount = 0;
            decimal? SumTexAmount = 0;
            foreach (var Nouhin in Order.listOrderDetail)
            {
                SumAmount += Nouhin.FChuumonKingaku;
                SumTexAmount += Nouhin.FShouhizeiKingaku;
            }
            ViewBag.sumAmount = SumAmount;
            ViewBag.sumTexAmount = SumTexAmount;
            return View(Order);
        }
        public OrderDetailController(IOrderDetailService _order, IHostingEnvironment env)
        {
            _IOrderDetailService = _order;
            _IHostingEnvironment = env;
        }
        public IActionResult ZipFile(int index)
        {
            OrderDetailAllModel Order = _IOrderDetailService.GetData("2");
            string pathAttachFile = Order.listOrderDetail[index - 1].pathAttachFile;
            //string[] listPath = Directory.GetFiles(pathAttachFile);
            string fileName = Order.listOrderDetail[index - 1].FChuumonNo + "_" + Order.listOrderDetail[index - 1].FChuumonMeisaiGyou.ToString() + "_temp.zip";
            var zipfile = FileUtils.ZipFolder(pathAttachFile);
            return File(zipfile, "application/x-compressed", fileName);
        }
        public IActionResult ZipMultiSelect(List<int> index)
        {
            OrderDetailAllModel Order = _IOrderDetailService.GetData("2");
            List<string> listPath = new List<string>();
            List<string> listFileName = new List<string>();
            foreach (var i in index)
            {
                OrderDetailModel orderDetail = Order.listOrderDetail[i - 1];
                string fileName = orderDetail.FChuumonNo + "_" + orderDetail.FChuumonMeisaiGyou.ToString() + "_temp.zip";
                listPath.Add(orderDetail.pathAttachFile);
                listFileName.Add(fileName);
            }
            var zipfile = FileUtils.ZipMultiFolders(listPath.ToArray(),listFileName.ToArray());
            return File(zipfile, "application/x-compressed", "temp.zip");
        }
    }
}