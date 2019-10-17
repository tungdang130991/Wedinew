using System;
using System.ComponentModel.DataAnnotations;
using WebEDI.Common.Core;

namespace WebEDI.Respository.ViewModels
{
    public class OrderUserModel
    {

        public long f_edi_hatsuchuumeisai_id { get; set; }

        public string f_attach_file { get; set; }
        public string f_yuza_id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime f_chuumon_tsuki { get; set; }
        public string f_toiawase_tantousha_mei { get; set; }
        public string f_toiawase_tel { get; set; }
        public string f_toiawase_fax { get; set; }
        public string f_chuumon_meisai_joutai_kubun { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime f_chuumon_hi { get; set; }
        public string f_chuumon_no { get; set; }
        public int f_chuumon_meisai_gyou { get; set; }
        public string f_seiban { get; set; }
        public string f_hinmoku_cd { get; set; }
        public string f_hinmoku_mei { get; set; }
        public string f_koubai_kishumei { get; set; }
        public decimal? f_saizu_w { get; set; }
        public decimal? f_saizu_h { get; set; }
        public decimal? f_saizu_l { get; set; }
        public string f_shiyou_jouhou { get; set; }
        public string f_shiyou_bikou { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime f_kibou_nouki { get; set; }
        public decimal f_suuryou { get; set; }
        public string f_tani_mei { get; set; }
        public decimal f_chuumon_tanka { get; set; }
        public decimal f_chuumon_kingaku { get; set; }
        public decimal? f_shouhizei_kingaku { get; set; }
        public string f_nounyuusaki_mei { get; set; }
        public string f_tanaban { get; set; }
        public string f_chuumon_meisai_bikou1 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime? f_jushin_nichiji { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime? f_kakunin_nichiji { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]

        public DateTime? f_koushin_taimusutanpu { get; set; }
        public string f_koushin_yuza_id { get; set; }
        public string f_koushin_konpyuta_mei { get; set; }
        public string f_koushin_kinou_id { get; set; }
        public long  f_koushin_kontororu_no { get; set; }
        public int f_bajon { get; set; }

    }

    public class searchModel
    {
        public string f_toiawase_tantousha_mei { get; set; }
        public string f_toiawase_tel { get; set; }
        public string f_toiawase_fax { get; set; }

    }
}
