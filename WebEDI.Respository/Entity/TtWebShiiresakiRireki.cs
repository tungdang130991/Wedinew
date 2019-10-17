using System;
using System.Collections.Generic;

namespace WebEDI.Respository.Entity
{
    public partial class TtWebShiiresakiRireki
    {
        public long FRirekiNo { get; set; }
        public DateTime FTaimusutanpu { get; set; }
        public int FShoriModo { get; set; }
        public long FEdiShiiresakiId { get; set; }
        public string FShiiresakiCd { get; set; }
        public string FShiiresakiMei { get; set; }
        public string FEdiChuumonshoKingakuhyoujiKubun { get; set; }
        public string FEdiNouhinmeisaiShoukaihyoujiKubun { get; set; }
        public string FHatsuchuuEdiSoushinKubun { get; set; }
        public string FToiawaseTantoushaMei { get; set; }
        public string FToiawaseTel { get; set; }
        public string FToiawaseFax { get; set; }
        public string FShiiresakiBikou1 { get; set; }
        public string FShiiresakiBikou2 { get; set; }
        public DateTime FKoushinTaimusutanpu { get; set; }
        public string FKoushinYuzaId { get; set; }
        public string FKoushinKonpyutaMei { get; set; }
        public string FKoushinKinouId { get; set; }
        public long FKoushinKontororuNo { get; set; }
        public int FBajon { get; set; }
    }
}
