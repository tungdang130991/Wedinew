using System;
using System.Collections.Generic;
using System.Text;
using WebEDI.Respository.Interface;
using WebEDI.Respository.Entity;
using WebEDI.Respository.ViewModels;
using System.Linq;
namespace WebEDI.Respository.Services
{
    public class NouhinmeisaiService:ConnectService,INouhinmeisaiService
    {
        public NouhinmeisaiService(webedidbContext dbContext) : base(dbContext)
        {

        }

        public List<ViewNouhinmeisaiModel> ListNouhinmeisais()
        {
            List<ViewNouhinmeisaiModel> List = new List<ViewNouhinmeisaiModel>();
            var datalist = (from m in _dbContext.TtWebNouhinmeisai
                            select new
                            {
                                m.FKenshuuYoteiKubun,
                                m.FChuumonNo,
                                m.FChuumonMeisaiGyou,
                                m.FKoubaiKishumei,
                                m.FHinmokuMei,
                                m.FKatashiki,
                                m.FSaizuW,
                                m.FSaizuH,
                                m.FSaizuL,
                                m.FShiyouJouhou,
                                m.FShiyouBikou,
                                m.FKenshuuHi,
                                m.FKenshuuSuu,
                                m.FShiireTanka,
                                m.FShiireKingaku,
                                m.FShouhizeiKingaku
                            }).ToList();
            foreach (var item in datalist)
            {
                ViewNouhinmeisaiModel pvm = new ViewNouhinmeisaiModel();
                pvm.FKenshuuYoteiKubun = item.FKenshuuYoteiKubun;
                pvm.FChuumonNo = item.FChuumonNo;
                pvm.FChuumonMeisaiGyou = item.FChuumonMeisaiGyou;
                pvm.FKoubaiKishumei = item.FKoubaiKishumei;
                pvm.FHinmokuMei = item.FHinmokuMei;
                pvm.FKatashiki = item.FKatashiki;
                pvm.FSaizuW = item.FSaizuW;
                pvm.FSaizuH = item.FSaizuH;
                pvm.FSaizuL = item.FSaizuL;
                pvm.FShiyouJouhou = item.FShiyouJouhou;
                pvm.FShiyouBikou = item.FShiyouBikou;
                pvm.FKenshuuHi = item.FKenshuuHi;
                pvm.FKenshuuSuu = item.FKenshuuSuu;
                pvm.FShiireTanka = item.FShiireTanka;
                pvm.FShiireKingaku = item.FShiireKingaku;
                pvm.FShouhizeiKingaku = item.FShouhizeiKingaku;

                List.Add(pvm);
            }
            return List;
        }
    }
}
