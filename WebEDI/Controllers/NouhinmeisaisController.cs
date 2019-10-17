using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using CsvHelper;
using CsvHelper.Configuration;
using System.Security.Claims;
using Newtonsoft.Json;
namespace WebEDI.Controllers
{
    public sealed class GroupReportCSVMap : ClassMap<ViewNouhinmeisaiModel>
    {
        //Mapping tille
        public GroupReportCSVMap()
        {
            AutoMap();
            Map(m => m.FKenshuuYoteiKubun).Name("検収予定区分");
            Map(m => m.FChuumonNo).Name("注文伝票NO");
            Map(m => m.FChuumonMeisaiGyou).Name("注文明細行");
            Map(m => m.FKoubaiKishumei).Name("購買機種名");
            Map(m => m.FHinmokuMei).Name("品目");
            Map(m => m.FKatashiki).Name("品名");
            Map(m => m.FSaizuW).Name("サイズ(W)");
            Map(m => m.FSaizuH).Name("サイズ(H)");
            Map(m => m.FSaizuL).Name("サイズ(L)");
            Map(m => m.FShiyouJouhou).Name("仕様");
            Map(m => m.FShiyouBikou).Name("仕様備考");
            Map(m => m.FKenshuuHi).Name("検収日");
            Map(m => m.FKenshuuSuu).Name("検収数");
            Map(m => m.FShiireTanka).Name("単価");
            Map(m => m.FShiireKingaku).Name("金額");
            Map(m => m.FShouhizeiKingaku).Name("消費税金額");

        }
    }
    public class NouhinmeisaisController : Controller
    {
        public INouhinmeisaiService _INouhinmeisaiService { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        public NouhinmeisaisController(INouhinmeisaiService nouhinmeisaiService, IHostingEnvironment env)
        {
            _INouhinmeisaiService = nouhinmeisaiService;
            _hostingEnvironment = env;
         
        }
        public IActionResult Index()
        {
            List<ViewNouhinmeisaiModel> ProjectEmployeeslist = _INouhinmeisaiService.ListNouhinmeisais();
            decimal SumAmount = 0, SumTexAmount = 0;

            ViewData["page_title"] = "注文情報照会";
            if(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value== "User")
                ViewData["user_companyname"] = User.Claims.FirstOrDefault(c => c.Type == "f_shiiresaki_mei").Value;

            foreach (var Nouhin in ProjectEmployeeslist)
            {
                SumAmount += Nouhin.FShiireKingaku;
                SumTexAmount += Nouhin.FShouhizeiKingaku;
            }
            ViewBag.sumAmount = SumAmount;
            ViewBag.sumTexAmount = SumTexAmount;
            return View(ProjectEmployeeslist);
        }

        //Export Csv file use CsvHelper
        public async Task<IActionResult> NouhinmeisaisCsvExport()
        {
            var memoryStream = new MemoryStream();
            string webRootPath = _hostingEnvironment.WebRootPath;
            string fileName = @"納品明細_" + DateTime.Now.ToString("yyyyMMdd-HH-mm") + ".csv";
            List<ViewNouhinmeisaiModel> reportCSVModels = _INouhinmeisaiService.ListNouhinmeisais();
            
            using (StreamWriter writeFile = new StreamWriter(Path.Combine(webRootPath, fileName)))
            {
                CsvWriter csv = new CsvWriter(writeFile);
                csv.Configuration.RegisterClassMap<GroupReportCSVMap>();
                csv.WriteRecords(reportCSVModels);
            }

            using (var fileStream = new FileStream(Path.Combine(webRootPath, fileName), FileMode.Open))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return File(memoryStream, "application/csv", fileName);
        }
        //Export Csv file use CsvHelper Without create file
        public IActionResult CsvExport()
        {
            string fileName = @"納品明細_" + DateTime.Now.ToString("yyyyMMdd-HH-mm") + ".csv";
            List<ViewNouhinmeisaiModel> reportCSVModels = _INouhinmeisaiService.ListNouhinmeisais();
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            CsvWriter csv = new CsvWriter(sw);
            csv.Configuration.RegisterClassMap<GroupReportCSVMap>();
            csv.WriteRecords(reportCSVModels);
            sw.Flush();
            ms.Position = 0;
            return File(ms, "application/csv", fileName);
        }
        public IActionResult CsvExportP()
        {
            string fileName = @"納品明細_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            List<ViewNouhinmeisaiModel> reportCSVModels = _INouhinmeisaiService.ListNouhinmeisais();
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            CsvWriter csv = new CsvWriter(sw);
            csv.Configuration.RegisterClassMap<GroupReportCSVMap>();
            csv.WriteRecords(reportCSVModels);
            sw.Flush();
            ms.Position = 0;
            TempData["csvData"] = ms.ToArray();
            return new JsonResult(new { FileGuid = "csvData", FileName = fileName}); 
        }
        public IActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/csv", fileName);
            }
            else
            {
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
            }
        }
    }
}