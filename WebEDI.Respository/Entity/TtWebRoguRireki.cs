using System;
using System.Collections.Generic;

namespace WebEDI.Respository.Entity
{
    public partial class TtWebRoguRireki
    {
        public long FRirekiNo { get; set; }
        public DateTime FTaimusutanpu { get; set; }
        public int FShoriModo { get; set; }
        public long FEdiRoguId { get; set; }
        public string FEdiRoguNo { get; set; }
        public string FKinouId { get; set; }
        public string FKuraiantoIpadoresu { get; set; }
        public string FEraKubun { get; set; }
        public string FEraNaiyou1 { get; set; }
        public string FEraNaiyou2 { get; set; }
        public DateTime FKoushinTaimusutanpu { get; set; }
        public string FKoushinYuzaId { get; set; }
        public string FKoushinKonpyutaMei { get; set; }
        public string FKoushinKinouId { get; set; }
        public long FKoushinKontororuNo { get; set; }
        public int FBajon { get; set; }
    }
}
