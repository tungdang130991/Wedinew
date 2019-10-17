using System;
using System.Collections.Generic;

namespace WebEDI.Respository.Entity
{
    public partial class TtWebNouhinmeisaiRireki
    {
        public long FRirekiNo { get; set; }
        public DateTime FTaimusutanpu { get; set; }
        public int FShoriModo { get; set; }
        public long FEdiNouhinmeisaiId { get; set; }
        public string FChuumonMeisaiNo { get; set; }
        public string FChuumonNo { get; set; }
        public int FChuumonMeisaiGyou { get; set; }
        public string FShiireMeisaiNo { get; set; }
        public string FKenshuuYoteiKubun { get; set; }
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
        public int FKenshuuHi { get; set; }
        public decimal FKenshuuSuu { get; set; }
        public decimal FShiireTanka { get; set; }
        public decimal FShiireKingaku { get; set; }
        public decimal FShouhizeiKingaku { get; set; }
        public string FNouhinMeisaiBikou1 { get; set; }
        public string FNouhinMeisaiBikou2 { get; set; }
        public DateTime? FJushinNichiji { get; set; }
        public DateTime FKoushinTaimusutanpu { get; set; }
        public string FKoushinYuzaId { get; set; }
        public string FKoushinKonpyutaMei { get; set; }
        public string FKoushinKinouId { get; set; }
        public long FKoushinKontororuNo { get; set; }
        public int FBajon { get; set; }
    }
}
