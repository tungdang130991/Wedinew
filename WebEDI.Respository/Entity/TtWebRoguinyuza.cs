using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEDI.Respository.Entity
{
    public partial class TtWebRoguinyuza
    {
        [Key]
        public long FEdiRoguinYuzaId { get; set; }
        public string FEdiRoguinYuzaNo { get; set; }
        public string FRotsukuKubun { get; set; }
        public string FJishaShiiresakiKubun { get; set; }
        public string FShiiresakiCd { get; set; }
        public string FTantoushaMei { get; set; }
        public string FYuzaId { get; set; }
        public string FPasuwado { get; set; }
        public string FMeruadoresu { get; set; }
        public string FMeruSoushinKubun { get; set; }
        public string FYuzaBikou { get; set; }
        public DateTime? FSaishuuRoguinNichiji { get; set; }
        public DateTime FKoushinTaimusutanpu { get; set; }
        public string FKoushinYuzaId { get; set; }
        public string FKoushinKonpyutaMei { get; set; }
        public string FKoushinKinouId { get; set; }
        public long FKoushinKontororuNo { get; set; }
        public int FBajon { get; set; }
    }
}
