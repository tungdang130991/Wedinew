using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEDI.Respository.ViewModels
{
    public class ViewNouhinmeisaiModel
    {
        public string FKenshuuYoteiKubun { get; set; }
        public string FChuumonNo { get; set; }
        public int FChuumonMeisaiGyou { get; set; }
        public string FKoubaiKishumei { get; set; }
        public string FHinmokuMei { get; set; }
        public string FKatashiki { get; set; }
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
    }
}
