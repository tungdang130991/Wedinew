using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;
using CsvHelper;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WebEDI.Utility;
using WebEDI.Common.Core;

namespace WebEDI.Controllers
{
    public class OrderUserController : Controller
    {
        public IOrderUserService _OrderUserService { get; set; }
        public IConfiguration configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public OrderUserController(IConfiguration Config, IOrderUserService _order, IHostingEnvironment env)
        {
            _OrderUserService = _order;
            _hostingEnvironment = env;
            configuration = Config;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Date = DateTime.Now.ToString("yyyy/MM");
            ViewBag.Name = User.Claims.FirstOrDefault(c => c.Type == "f_shiiresaki_mei").Value;
            ViewBag.Tel = User.Claims.FirstOrDefault(c => c.Type == "f_toiawase_tel").Value;
            ViewBag.Fax = User.Claims.FirstOrDefault(c => c.Type == "f_toiawase_fax").Value;
            string shiiresaki_cd= User.Claims.FirstOrDefault(c => c.Type == "f_shiiresaki_cd").Value;

            List<OrderUserModel> listOrder = new List<OrderUserModel>();

            listOrder = _OrderUserService.GetTable(DateTime.Now, shiiresaki_cd);

            if (listOrder.Count > 0)
            {
                for (int i = 0; i < listOrder.Count; i++)
                {
                    ViewBag.sumOrder = 0;
                    ViewBag.sumOrdertext = 0;
                    ViewBag.sumOrder = listOrder[i].f_chuumon_kingaku;
                    ViewBag.sumOrdertext = listOrder[i].f_shouhizei_kingaku;
                    ViewBag.sumOrder = ViewBag.sumOrder + ViewBag.sumOrder;
                    ViewBag.sumOrdertext = ViewBag.sumOrdertext + ViewBag.sumOrdertext;
                }
            }
            else
            {
                ViewBag.sumOrder = 0;
                ViewBag.sumOrdertext = 0;
            }

            ViewData["page_title"] = "注文情報照会";
            if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "User")
                ViewData["user_companyname"] = User.Claims.FirstOrDefault(c => c.Type == "f_shiiresaki_mei").Value;

            //List<searchModel> searchData = _OrderUserService.GetData();
            //ViewBag.Name = searchData[0].f_toiawase_tantousha_mei;
            //ViewBag.Tel = searchData[0].f_toiawase_tel;
            //ViewBag.Fax = searchData[0].f_toiawase_fax;

            return View(listOrder);
        }

        [HttpPost]
        // [Authorize]        
        public IActionResult ZipAndDownload([FromBody] RequestDataDTO req)
        {
            var fileName = string.Format("{0}_temp.zip", DateTime.Today.Date.ToString("dd-MM-yyyy") + "_1");
            
            string[] folders = { "wwwroot\\css", "wwwroot\\js" };
            string[] names = { "css.zip", "js.zip" };
            string[] files = { "wwwroot\\css\\Login.css", "wwwroot\\css\\site.css" };

            return File(FileUtils.ZipMultiFolders(folders,names), "application/zip", "temp.zip");
            //return File(FileUtils.ZipMultiFiles(files), "application/zip", fileName);           
        }

        [HttpPost]
        //[Authorize]
        public IActionResult btnOrderUserOutput()
        {
            var fileName = string.Format("cyumon.zip");
            string[] folders = { "wwwroot\\css", "wwwroot\\js" };
            string[] names = { "css.zip", "js.zip" };
            string[] files = { "wwwroot\\css\\Login.css", "wwwroot\\css\\site.css" };

            //return File(FileUtils.ZipMultiFolders(folders,names), "application/zip", "temp.zip");
            return File(FileUtils.ZipMultiFiles(files), "application/zip", fileName);
        }

        [HttpPost]
        //[Authorize]
        public void ConfirmUpdate([FromBody] RequestDataDTO req)
        {
            string[] ids = req.str.Split(",");
            _OrderUserService.UpdateConfirm(DateTime.Now, ids);
        }

        [HttpPost]
        public IActionResult ExportCSV([FromBody] RequestDataDTO req)
        {
            var memoryStream = new MemoryStream();
            string shiiresaki_cd = User.Claims.FirstOrDefault(c => c.Type == "f_shiiresaki_cd").Value;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string fileName = @"注文明細_受信日時" + ".csv";
            DateTime chuumon_tsuki = DateTime.Now;

            List<OrderUserModel> lstData = _OrderUserService.GetTable(chuumon_tsuki, shiiresaki_cd);
            List<OrderUserModel> lstExport = new List<OrderUserModel>();

            if(req.str==null || req.str.Equals(""))
            {
                return null;
            }

            string[] selectedIds = req.str.Split(",");

            lstData.ForEach(e =>
            {
                if (selectedIds.Contains(e.f_edi_hatsuchuumeisai_id+""))
                {
                    lstExport.Add(e);
                }
            });

            StreamWriter streamWriter = new StreamWriter(memoryStream);            
            CsvWriter csv = new CsvWriter(streamWriter);
            csv.Configuration.RegisterClassMap<GroupReportCSVMap>();                
            csv.WriteRecords(lstExport);
            streamWriter.Flush();                           
            memoryStream.Position = 0;
            return File(memoryStream, "application/csv", fileName);
        }

        //}
        public class RequestDataDTO
        {
            public string str { get; set; }
        }

        public sealed class GroupReportCSVMap : ClassMap<OrderUserModel>
        {
            //Mapping tille
            public GroupReportCSVMap()
            {
                AutoMap();
                int i = 0;
                Map(m => m.f_chuumon_tsuki).Name("注文月").TypeConverter<DMYDateConverter >().Index(i++);                
                Map(m => m.f_toiawase_tantousha_mei).Name("問合せ担当者名").Index(i++);
                Map(m => m.f_toiawase_tel).Name("問合せTEL").Index(i++);
                Map(m => m.f_toiawase_fax).Name("問合せFAX").Index(i++);
                Map(m => m.f_chuumon_meisai_joutai_kubun).Name("注文明細状態").Index(i++);
                Map(m => m.f_chuumon_hi).Name("注文日").TypeConverter<DMYDateConverter>().Index(i++);                
                Map(m => m.f_chuumon_no).Name("注文伝票NO").Index(i++);
                Map(m => m.f_chuumon_meisai_gyou).Name("注文明細行").Index(i++);
                Map(m => m.f_seiban).Name("製番").Index(i++);
                Map(m => m.f_attach_file).Name("添付ファイル").Index(i++);
                Map(m => m.f_hinmoku_cd).Name("品目").Index(i++);
                Map(m => m.f_hinmoku_mei).Name("品名").Index(i++);
                Map(m => m.f_koubai_kishumei).Name("購買機種名").Index(i++);
                Map(m => m.f_saizu_w).Name("サイズ(W)").Index(i++);
                Map(m => m.f_saizu_h).Name("サイズ(H)").Index(i++);
                Map(m => m.f_saizu_l).Name("サイズ(L)").Index(i++);
                Map(m => m.f_shiyou_jouhou).Name("仕様").Index(i++);
                Map(m => m.f_shiyou_bikou).Name("仕様備考").Index(i++);
                Map(m => m.f_kibou_nouki).Name("希望納期").TypeConverter<DMYDateConverter>().Index(i++);
                Map(m => m.f_suuryou).Name("数量").Index(i++);
                Map(m => m.f_tani_mei).Name("単位名").Index(i++);
                Map(m => m.f_chuumon_tanka).Name("注文単価").TypeConverter<NumConverter>().Index(i++);
                Map(m => m.f_chuumon_kingaku).Name("注文金額").TypeConverter<NumConverter>().Index(i++);
                Map(m => m.f_shouhizei_kingaku).Name("消費税金額").TypeConverter<NumConverter>().Index(i++);
                Map(m => m.f_nounyuusaki_mei).Name("納入場所名").Index(i++);
                Map(m => m.f_tanaban).Name("棚番").Index(i++);
                Map(m => m.f_chuumon_meisai_bikou1).Name("注文明細備考１").Index(i++);                
                Map(m => m.f_jushin_nichiji).Name("受信日時").TypeConverter<DMYDateConverter>().Index(i++);
                Map(m => m.f_kakunin_nichiji).Name("確認日時").TypeConverter<DMYDateConverter>().Index(i++);
                Map(m => m.f_yuza_id).Name("確認者").Index(i++);

                Map(m => m.f_edi_hatsuchuumeisai_id).Ignore();
                Map(m => m.f_koushin_taimusutanpu).Ignore();
                Map(m => m.f_koushin_yuza_id).Ignore();
                Map(m => m.f_koushin_konpyuta_mei).Ignore();
                Map(m => m.f_koushin_kinou_id).Ignore();
                Map(m => m.f_koushin_kontororu_no).Ignore();
                Map(m => m.f_bajon).Ignore();
                

            }
        }
    }
}

