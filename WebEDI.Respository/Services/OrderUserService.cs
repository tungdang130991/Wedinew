using System;
using System.Collections.Generic;
using System.Linq;
using WebEDI.Respository.Entity;
using WebEDI.Respository.Interface;
using WebEDI.Respository.ViewModels;

namespace WebEDI.Respository.Services
{
    public class OrderUserService : ConnectService, IOrderUserService
    {
        public OrderUserService(webedidbContext dbContext) : base(dbContext)
        {
        }

        public List<OrderUserModel> GetTable(DateTime chuumon_tsuki, String hinmoku_cd)
        {
            List<OrderUserModel> orderUser = new List<OrderUserModel>();
            var dataTable = (from a in _dbContext.TtWebHatsuchuumeisai
                             // from b in _dbContext.TtWebKanjounengetsu.Where(x => x.FEdiKanjounengetsuNo == a.FChuumonMeisaiNo).DefaultIfEmpty()
                             from c in _dbContext.TtWebShiiresaki.Where(x => x.FShiiresakiCd == a.FShiiresakiCd).DefaultIfEmpty()
                             select new
                             {
                                a.FEdiHatsuchuumeisaiId,
                                 c.FToiawaseTantoushaMei,
                                 c.FToiawaseTel,
                                 c.FToiawaseFax,
                                 a.FChuumonMeisaiJoutaiKubun,
                                 a.FChuumonHi,
                                 a.FChuumonNo,
                                 a.FChuumonMeisaiGyou,
                                 a.FSeiban,
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
                                 a.FKoushinTaimusutanpu,
                                 a.FKoushinYuzaId,
                                 a.FKoushinKonpyutaMei,
                                 a.FKoushinKinouId,
                                 a.FKoushinKontororuNo,
                                 a.FBajon
                             }).ToList();
            foreach (var item in dataTable)
            {
                OrderUserModel term = new OrderUserModel();
                term.f_chuumon_tsuki = chuumon_tsuki;
                term.f_edi_hatsuchuumeisai_id = item.FEdiHatsuchuumeisaiId;
                term.f_toiawase_tel = item.FToiawaseTel;
                term.f_toiawase_fax = item.FToiawaseFax;
                term.f_toiawase_tantousha_mei = item.FToiawaseTantoushaMei;
                term.f_chuumon_meisai_joutai_kubun = item.FChuumonMeisaiJoutaiKubun;
                term.f_chuumon_hi = item.FChuumonHi;
                term.f_chuumon_no = item.FChuumonNo;
                term.f_chuumon_meisai_gyou = item.FChuumonMeisaiGyou;
                term.f_seiban = item.FSeiban;
                term.f_hinmoku_cd = item.FHinmokuCd;
                term.f_hinmoku_mei = item.FHinmokuMei;
                term.f_koubai_kishumei = item.FKoubaiKishumei;
                term.f_saizu_w = item.FSaizuW;
                term.f_saizu_h = item.FSaizuH;
                term.f_saizu_l = item.FSaizuL;
                term.f_shiyou_jouhou = item.FShiyouJouhou;
                term.f_shiyou_bikou = item.FShiyouBikou;
                term.f_kibou_nouki = item.FKibouNouki;
                term.f_suuryou = item.FSuuryou;
                term.f_tani_mei = item.FTaniMei;
                term.f_chuumon_tanka = item.FChuumonTanka;
                term.f_chuumon_kingaku = item.FChuumonKingaku;
                term.f_shouhizei_kingaku = item.FShouhizeiKingaku;
                term.f_nounyuusaki_mei = item.FNounyuusakiMei;
                term.f_tanaban = item.FTanaban;
                term.f_chuumon_meisai_bikou1 = item.FChuumonMeisaiBikou1;
                term.f_jushin_nichiji = item.FJushinNichiji;
                term.f_kakunin_nichiji = item.FKakuninNichiji;
                term.f_koushin_taimusutanpu = item.FKoushinTaimusutanpu;
                term.f_koushin_yuza_id = item.FKoushinYuzaId;
                term.f_koushin_konpyuta_mei = item.FKoushinKonpyutaMei;
                term.f_koushin_kinou_id = item.FKoushinKinouId;
                term.f_koushin_kontororu_no = item.FKoushinKontororuNo;
                term.f_bajon = item.FBajon;
                orderUser.Add(term);                
            }
            return orderUser;
        }

        public List<searchModel> GetData()
        {
            searchModel data = new searchModel();
            List<searchModel> lstData = new List<searchModel>();
            var dataTable = (from a in _dbContext.TtWebShiiresaki
                             select new
                             {
                                 a.FToiawaseTantoushaMei,
                                 a.FToiawaseTel,
                                 a.FToiawaseFax
                             });
            foreach (var item in dataTable)
            {
                data.f_toiawase_tantousha_mei = item.FToiawaseTantoushaMei;
                data.f_toiawase_tel = item.FToiawaseTel;
                data.f_toiawase_fax = item.FToiawaseFax;
            }
            lstData.Add(data);
            return lstData;
        }

        public void UpdateConfirm(DateTime dateConfirm, string[] ids)
        {
            var table = _dbContext.TtWebHatsuchuumeisai;
            var dataTable = _dbContext.TtWebHatsuchuumeisai.Where(f => ids.Contains(f.FEdiHatsuchuumeisaiId+""));

            foreach (var row in dataTable)
            {
                row.FKakuninNichiji = dateConfirm;
                _dbContext.Update(row);                
            }
            _dbContext.SaveChanges();
        }
    }
}