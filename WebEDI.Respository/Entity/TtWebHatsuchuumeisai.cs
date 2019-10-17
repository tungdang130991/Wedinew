using System;
using System.Collections.Generic;

namespace WebEDI.Respository.Entity
{
    public partial class TtWebHatsuchuumeisai
    {
        public long FEdiHatsuchuumeisaiId { get; set; }
        public string FChuumonMeisaiNo { get; set; }
        public string FChuumonNo { get; set; }
        public int FChuumonMeisaiGyou { get; set; }
        public string FChuumonMeisaiJoutaiKubun { get; set; }
        public string FShiiresakiCd { get; set; }
        public string FShiharaisakiCd { get; set; }
        public string FHinmokuCd { get; set; }
        public string FHinban { get; set; }
        public string FHinmokuMei { get; set; }
        public string FKoubaiKishumei { get; set; }
        public string FKatashiki { get; set; }
        public string FZuban { get; set; }
        public string FSeiban { get; set; }
        public decimal? FSaizuW { get; set; }
        public decimal? FSaizuH { get; set; }
        public decimal? FSaizuL { get; set; }
        public string FShiyouJouhou { get; set; }
        public string FShiyouBikou { get; set; }
        public DateTime FChuumonHi { get; set; }
        public DateTime FKibouNouki { get; set; }
        public decimal FSuuryou { get; set; }
        public string FTaniMei { get; set; }
        public decimal FChuumonTanka { get; set; }
        public decimal FChuumonKingaku { get; set; }
        public decimal? FShouhizeiKingaku { get; set; }
        public string FNounyuusakiMei { get; set; }
        public string FYuubinbangou { get; set; }
        public string FJuusho1 { get; set; }
        public string FJuusho2 { get; set; }
        public string FDenwabangou { get; set; }
        public string FFaxBangou { get; set; }
        public string FEmail { get; set; }
        public int? FYusoult { get; set; }
        public string FNiuketantoushaMei { get; set; }
        public string FNiuketantoushaDenwabangou { get; set; }
        public string FTanaban { get; set; }
        public string FHakobangou { get; set; }
        public string FChuumonMeisaiBikou1 { get; set; }
        public string FChuumonMeisaiBikou2 { get; set; }
        public DateTime? FJushinNichiji { get; set; }
        public DateTime? FKakuninNichiji { get; set; }
        public DateTime FKoushinTaimusutanpu { get; set; }
        public string FKoushinYuzaId { get; set; }
        public string FKoushinKonpyutaMei { get; set; }
        public string FKoushinKinouId { get; set; }
        public long FKoushinKontororuNo { get; set; }
        public int FBajon { get; set; }
    }
}
