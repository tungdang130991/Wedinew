using System;
using System.Collections.Generic;
using System.Text;

namespace WebEDI.Respository.ViewModels
{
    public class OrderDetailAllModel
    {
        public string FChuumonNo { get; set; }
        public string FShiiresakiCd { get; set; }
        public string FShiiresakiMei { get; set; }
        public string FTantoushaMei { get; set; }
        public string FToiawaseTel { get; set; }
        public string FToiawaseFax { get; set; }
        public DateTime FChuumonHi { get; set; }
        public DateTime? FJushinNichiji { get; set; }
        public DateTime? FKakuninNichiji { get; set; }
        public List<OrderDetailModel> listOrderDetail { get; set; }
    }
}
