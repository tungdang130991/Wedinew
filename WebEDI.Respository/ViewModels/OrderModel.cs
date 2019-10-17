using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebEDI.Respository.ViewModels
{
    public class OrderModel
    {
        public long FEdiHatsuchuumeisaiId { get; set; }
        public string FShiiresakiCd { get; set; }
        public string FShiiresakiMei { get; set; }
        public string FChuumonNo { get; set; }
        public string FKoubaiKishumei { get; set; }
        public decimal FSuuryou { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FChuumonHi { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FKibouNouki { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? FJushinNichiji { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? FKakuninNichiji { get; set; }
        public string FMeruSoushinKubun { get; set; }
        public string FMeruadoresu { get; set; }
    }
}
