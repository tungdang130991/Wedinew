using System;
using System.Collections.Generic;

namespace WebEDI.Respository.Entity
{
    public partial class TtWebKanjounengetsu
    {
        public long FEdiKanjounengetsuId { get; set; }
        public string FEdiKanjounengetsuNo { get; set; }
        public int FNengetsu { get; set; }
        public int FKaishiHi { get; set; }
        public int FShuuryouHi { get; set; }
        public int FShimezumi { get; set; }
        public DateTime FKoushinTaimusutanpu { get; set; }
        public string FKoushinYuzaId { get; set; }
        public string FKoushinKonpyutaMei { get; set; }
        public string FKoushinKinouId { get; set; }
        public long FKoushinKontororuNo { get; set; }
        public int FBajon { get; set; }
    }
}
