using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.Entity;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebEDI.Respository.Services
{
    public class OrderDetailService : ConnectService, IOrderDetailService
    {
        public OrderDetailService(webedidbContext dbContext, IHostingEnvironment env) : base(dbContext)
        {
            _IHostingEnvironment = env;
        }
        public IHostingEnvironment _IHostingEnvironment { get; set; }
        public List<OrderDetailModel> GetDetailOrder(string orderID)
        {
            List<OrderDetailModel> listOrderDetail = new List<OrderDetailModel>();

            var dataTable = (from a in _dbContext.TtWebHatsuchuumeisai.Where(x => x.FChuumonNo == orderID)
                             from b in _dbContext.TtWebShiiresaki.Where(x => x.FShiiresakiCd == a.FShiiresakiCd).DefaultIfEmpty()
                             select new
                             {
                                 a.FChuumonMeisaiJoutaiKubun,
                                 a.FChuumonMeisaiGyou,
                                 a.FSeiban,
                                 b.FShiiresakiMei,
                                 a.FHinmokuCd,
                                 a.FHinmokuMei,
                                 a.FKoubaiKishumei,
                                 a.FSaizuW,
                                 a.FSaizuH,
                                 a.FSaizuL,
                                 a.FShiyouJouhou,
                                 a.FShiyouBikou,
                                 a.FKibouNouki,
                                 a.FSuuryou,
                                 a.FTaniMei,
                                 a.FChuumonTanka,
                                 a.FChuumonKingaku,
                                 a.FShouhizeiKingaku,
                                 a.FNounyuusakiMei,
                                 a.FTanaban,
                                 a.FChuumonMeisaiBikou1,
                                 a.FJushinNichiji,
                                 a.FKakuninNichiji,
                                 a.FChuumonNo
                             }).ToList();
            string Rootpath = _IHostingEnvironment.WebRootPath;
            foreach (var item in dataTable)
            {
                OrderDetailModel term = new OrderDetailModel();     
                term.FChuumonMeisaiJoutaiKubun = item.FChuumonMeisaiJoutaiKubun;
                term.FChuumonMeisaiGyou = item.FChuumonMeisaiGyou;
                term.FSeiban = item.FSeiban;
                term.FShiiresakiMei = item.FShiiresakiMei;
                term.FHinmokuCd = item.FHinmokuCd;
                term.FHinmokuMei = item.FHinmokuMei;
                term.FKoubaiKishumei = item.FKoubaiKishumei;
                term.FSaizuW = item.FSaizuW;
                term.FSaizuH = item.FSaizuH;
                term.FSaizuL = item.FSaizuL;
                term.FShiyouJouhou = item.FShiyouJouhou;
                term.FShiyouBikou = item.FShiyouBikou;
                term.FKibouNouki = item.FKibouNouki;
                term.FSuuryou = item.FSuuryou;
                term.FTaniMei = item.FTaniMei;
                term.FChuumonTanka = item.FChuumonTanka;
                term.FChuumonKingaku = item.FChuumonKingaku;
                term.FShouhizeiKingaku = item.FShouhizeiKingaku;
                term.FNounyuusakiMei = item.FNounyuusakiMei;
                term.FTanaban = item.FTanaban;
                term.FChuumonMeisaiBikou1 = item.FChuumonMeisaiBikou1;
                term.FJushinNichiji = item.FJushinNichiji;
                term.FKakuninNichiji = item.FKakuninNichiji;
                term.FChuumonNo = item.FChuumonNo;
                string path = Path.Combine(Rootpath,"Data",item.FChuumonNo.ToString(),item.FChuumonMeisaiGyou.ToString(),"Attach");
                if (Directory.Exists(path))
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        term.flagAttachFile = false;
                        term.pathAttachFile = "";
                    }
                    else
                    {
                        term.flagAttachFile = true;
                        term.pathAttachFile = path;
                    }
                }
                else
                {
                    term.flagAttachFile = false;
                    term.pathAttachFile = "";
                }
                
                listOrderDetail.Add(term);
            }



            return listOrderDetail;
        }

        public OrderDetailAllModel GetData(string orderID)
        {

            OrderDetailAllModel orders = new OrderDetailAllModel();
            orders.listOrderDetail = GetDetailOrder(orderID);
            var data = (from a in _dbContext.TtWebHatsuchuumeisai.Where(x => x.FChuumonNo == orderID)
                        from b in _dbContext.TtWebShiiresaki.Where(x => x.FShiiresakiCd == a.FShiiresakiCd).DefaultIfEmpty()
                        from c in _dbContext.TtWebRoguinyuza.Where(x => x.FShiiresakiCd == b.FShiiresakiCd).DefaultIfEmpty()
                        select new
                        {
                            a.FChuumonNo,
                            a.FShiiresakiCd,
                            b.FShiiresakiMei,
                            c.FTantoushaMei,
                            b.FToiawaseTel,
                            b.FToiawaseFax,
                            a.FChuumonHi,
                            a.FJushinNichiji,
                            a.FKakuninNichiji
                        }).FirstOrDefault();
            orders.FChuumonNo = data.FChuumonNo;
            orders.FShiiresakiCd = data.FShiiresakiCd;
            orders.FShiiresakiMei = data.FShiiresakiMei;
            orders.FTantoushaMei = data.FTantoushaMei;
            orders.FToiawaseTel = data.FToiawaseTel;
            orders.FToiawaseFax = data.FToiawaseFax;
            orders.FChuumonHi = data.FChuumonHi;
            orders.FJushinNichiji = data.FJushinNichiji;
            orders.FKakuninNichiji = data.FKakuninNichiji;

            return orders;
        }
    }
}
