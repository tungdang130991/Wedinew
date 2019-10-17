using System;
using System.Collections.Generic;
using System.Text;

namespace WebEDI.Respository.ViewModels
{
    public class OrderDetailModel
    {
        public string FChuumonMeisaiJoutaiKubun { get; set; }
        public int FChuumonMeisaiGyou { get; set; }
        public string FChuumonNo { get; set; }
        public string FSeiban { get; set; }
        public string FShiiresakiMei { get; set; }
        public string FHinmokuCd { get; set; }
        public string FHinmokuMei { get; set; }
        public string FKoubaiKishumei { get; set; }
        public decimal? FSaizuW { get; set; }
        public decimal? FSaizuH { get; set; }
        public decimal? FSaizuL { get; set; }
        public string FShiyouJouhou { get; set; }
        public string FShiyouBikou { get; set; }
        public DateTime FKibouNouki { get; set; }
        public decimal FSuuryou { get; set; }
        public string FTaniMei { get; set; }
        public decimal FChuumonTanka { get; set; }
        public decimal FChuumonKingaku { get; set; }
        public decimal? FShouhizeiKingaku { get; set; }
        public string FNounyuusakiMei { get; set; }
        public string FTanaban { get; set; }
        public string FChuumonMeisaiBikou1 { get; set; }
        public DateTime? FJushinNichiji { get; set; }
        public DateTime? FKakuninNichiji { get; set; }
        public bool flagAttachFile { get; set; }
        public string pathAttachFile { get; set; }
    }
}
