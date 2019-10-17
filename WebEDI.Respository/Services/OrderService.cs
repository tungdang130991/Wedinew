using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.Interface;
using WebEDI.Respository.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebEDI.Respository.ViewModels;
using WebEDI.Common.Core;
using Microsoft.Extensions.Configuration;
using WebEDI.Common;

namespace WebEDI.Respository.Services
{

   public class OrderService:ConnectService,IOrderService
    {
        public IConfiguration configuration;
        public OrderService(webedidbContext dbContext,IConfiguration _configuration) : base(dbContext)
        {
            configuration = _configuration;
        }
        public List<OrderModel> GetTable()
        {

            List<OrderModel> order = new List<OrderModel>();
            var a = (from c in _dbContext.TtWebHatsuchuumeisai
                     from o in _dbContext.TtWebRoguinyuza.Where(x => x.FShiiresakiCd == c.FShiiresakiCd).DefaultIfEmpty()
                     from k in _dbContext.TtWebShiiresaki.Where(x => x.FShiiresakiCd == c.FShiiresakiCd).DefaultIfEmpty()
                     select new
                     {
                         c.FShiiresakiCd,
                         k.FShiiresakiMei,
                         c.FChuumonNo,
                         c.FKoubaiKishumei,
                         c.FSuuryou,
                         c.FKibouNouki,
                         c.FJushinNichiji,
                         c.FKakuninNichiji,
                         c.FChuumonHi,
                         o.FMeruSoushinKubun,
                         o.FMeruadoresu
                     }).Distinct().ToList();
            foreach (var item in a)
            {
                OrderModel term = new OrderModel();
                term.FChuumonHi = item.FChuumonHi;
                term.FChuumonNo = item.FChuumonNo;
                term.FJushinNichiji = item.FJushinNichiji;
                term.FKakuninNichiji = item.FKakuninNichiji;
                term.FKibouNouki = item.FKibouNouki;
                term.FKoubaiKishumei = item.FKoubaiKishumei;
                term.FMeruadoresu = item.FMeruadoresu;
                term.FMeruSoushinKubun = item.FMeruSoushinKubun;
                term.FShiiresakiCd =item.FShiiresakiCd;
                term.FShiiresakiMei = item.FShiiresakiMei;
                term.FSuuryou = item.FSuuryou;
                order.Add(term);
            }
            return order;
        }
        public List<DropDown> GetDrops()
        {
            List<DropDown> list = new List<DropDown>();
            var a = _dbContext.TtWebRoguinyuza.Select(s=> s.FMeruSoushinKubun).Distinct().ToList();
            DropDown terms = new DropDown();
            terms.Id = "00";
            terms.Value = "全て";
            list.Add(terms);
            foreach (var item in a)
            {
                DropDown term = new DropDown();
                term.Id = item;
                if(item=="01")
                { 
                term.Value =item+" 未確認";
                }
                else
                {
                    term.Value =item+" 確認済み";
                }
                list.Add(term);
            }
                return list;
        }
        public List<OrderModel> SearchOrder(string id, DateTime beginorder, DateTime endorder,string checkmail)
        {
            List<OrderModel> order = new List<OrderModel>();

            var a = (from c in _dbContext.TtWebHatsuchuumeisai.Where(x => (id == null||id=="" || x.FShiiresakiCd == id) && (beginorder == new DateTime()||beginorder.ToString()=="" || beginorder <=x.FChuumonHi) && (endorder == new DateTime()||endorder.ToString()=="" || x.FChuumonHi <= endorder))
                     from o in _dbContext.TtWebRoguinyuza.Where(x => x.FShiiresakiCd == c.FShiiresakiCd).DefaultIfEmpty()
                     from k in _dbContext.TtWebShiiresaki.Where(x => x.FShiiresakiCd == c.FShiiresakiCd).DefaultIfEmpty()
                     where checkmail=="00" ||(o.FMeruSoushinKubun==checkmail &&  checkmail=="01" && c.FKakuninNichiji==null) || (o.FMeruSoushinKubun == checkmail && checkmail == "02" && c.FKakuninNichiji != null)
                     select new
                     {
                         c.FShiiresakiCd,
                         k.FShiiresakiMei,
                         c.FChuumonNo,
                         c.FKoubaiKishumei,
                         c.FSuuryou,
                         c.FKibouNouki,
                         c.FJushinNichiji,
                         c.FKakuninNichiji,
                         c.FChuumonHi,
                         o.FMeruSoushinKubun,
                         o.FMeruadoresu
                     }).Distinct().ToList();
            
            foreach (var item in a)
            {
                OrderModel term = new OrderModel();
                term.FChuumonHi = item.FChuumonHi;
                term.FChuumonNo = item.FChuumonNo;
                term.FJushinNichiji = item.FJushinNichiji;
                term.FKakuninNichiji = item.FKakuninNichiji;
                term.FKibouNouki = item.FKibouNouki;
                term.FKoubaiKishumei = item.FKoubaiKishumei;
                term.FMeruadoresu = item.FMeruadoresu;
                term.FMeruSoushinKubun = item.FMeruSoushinKubun;
                term.FShiiresakiCd = item.FShiiresakiCd;
                term.FShiiresakiMei = item.FShiiresakiMei;
                term.FSuuryou = item.FSuuryou;
                order.Add(term);
            }
            return order;
        }
        public ErrorCodes SendMail(string id)
        {
            if (id!="" && id!=null)
            {
                id = id.Remove(id.Length - 1);
                var arrayorder = id.Split(',');
                var host = configuration.GetSection("SMTP").GetSection("ML_HOST").Value;
                int port =Convert.ToInt32(configuration.GetSection("SMTP").GetSection("ML_PORT").Value);
                var user = configuration.GetSection("SMTP").GetSection("ML_USER").Value; 
                var pass = configuration.GetSection("SMTP").GetSection("ML_PASS").Value; 
                var sendmaddress = configuration.GetSection("SMTP").GetSection("ML_SENDMADDRESS").Value; 
                var sendname = configuration.GetSection("SMTP").GetSection("ML_SENDNAME").Value; 
                var sendsubject = configuration.GetSection("SMTP").GetSection("ML_SENDSUBJECT").Value; 
                var body = String.Format(configuration.GetSection("SMTP").GetSection("ML_BODY").Value,sendname);
                var cc = "";
                var bbc = "";
                foreach (var chumonNo in arrayorder)
                {
                    var a = (from c in _dbContext.TtWebHatsuchuumeisai.Where(x=> x.FChuumonNo == chumonNo)
                             from o in _dbContext.TtWebRoguinyuza.Where(x => x.FShiiresakiCd == c.FShiiresakiCd).DefaultIfEmpty()
                             from k in _dbContext.TtWebShiiresaki.Where(x => x.FShiiresakiCd == c.FShiiresakiCd).DefaultIfEmpty()
                             select new
                             {
                                 c.FKakuninNichiji,
                                 k.FShiiresakiMei,
                                 o.FMeruSoushinKubun,
                                 o.FMeruadoresu
                             }).Distinct().FirstOrDefault();
                    if(a!=null)
                    { 
                       // if(a.FMeruSoushinKubun=="01" && a.FKakuninNichiji==null)
                       // { 
                    string to = a.FMeruadoresu;
                    var sendmail = Email.SendMail(user,pass, sendmaddress, to,cc,bbc,sendsubject,body,host,port);
                    if(sendmail==false)
                    {
                        return ErrorCodes.SendMailFail;
                    }
                   //}
                    }
                    else { 
                    return ErrorCodes.SendMailFail;
                    }
                }
            }
            return ErrorCodes.None;
        }
    }
}
