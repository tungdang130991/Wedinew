using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebEDI.Common.Core;
namespace WebEDI.Respository.Entity
{
    public partial class webedidbContext : DbContext
    {
        public webedidbContext()
        {
        }

        public webedidbContext(DbContextOptions<webedidbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TtWebHatsuchuumeisai> TtWebHatsuchuumeisai { get; set; }
        public virtual DbSet<TtWebKanjounengetsu> TtWebKanjounengetsu { get; set; }
        public virtual DbSet<TtWebKanjounengetsuRireki> TtWebKanjounengetsuRireki { get; set; }
        public virtual DbSet<TtWebNouhinmeisai> TtWebNouhinmeisai { get; set; }
        public virtual DbSet<TtWebNouhinmeisaiRireki> TtWebNouhinmeisaiRireki { get; set; }
        public virtual DbSet<TtWebRogu> TtWebRogu { get; set; }
        public virtual DbSet<TtWebRoguRireki> TtWebRoguRireki { get; set; }
        public virtual DbSet<TtWebRoguinyuza> TtWebRoguinyuza { get; set; }
        public virtual DbSet<TtWebRoguinyuzaRireki> TtWebRoguinyuzaRireki { get; set; }
        public virtual DbSet<TtWebShiiresaki> TtWebShiiresaki { get; set; }
        public virtual DbSet<TtWebShiiresakiRireki> TtWebShiiresakiRireki { get; set; }

        // Unable to generate entity type for table 'public.tt_web_hatsuchuumeisai_rireki'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(Base64.Decode("U2VydmVyPWxvY2FsaG9zdDtVc2VybmFtZT1wb3N0Z3JlcztQYXNzd29yZD0xMjM0NTY7RGF0YWJhc2U9d2ViZWRpZGI="));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TtWebHatsuchuumeisai>(entity =>
            {
                entity.HasKey(e => e.FEdiHatsuchuumeisaiId)
                    .HasName("pk_tt_web_hatsuchuumeisai");

                entity.ToTable("tt_web_hatsuchuumeisai");

                entity.HasIndex(e => e.FChuumonMeisaiNo)
                    .HasName("tt_web_hatsuchuumeisai_ix02");

                entity.HasIndex(e => new { e.FChuumonNo, e.FChuumonMeisaiGyou })
                    .HasName("tt_web_hatsuchuumeisai_uix01")
                    .IsUnique();

                entity.HasIndex(e => new { e.FShiiresakiCd, e.FShiharaisakiCd, e.FChuumonHi })
                    .HasName("tt_web_hatsuchuumeisai_ix03");

                entity.Property(e => e.FEdiHatsuchuumeisaiId)
                    .HasColumnName("f_edi_hatsuchuumeisai_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FChuumonHi).HasColumnName("f_chuumon_hi");

                entity.Property(e => e.FChuumonKingaku)
                    .HasColumnName("f_chuumon_kingaku")
                    .HasColumnType("numeric");

                entity.Property(e => e.FChuumonMeisaiBikou1)
                    .HasColumnName("f_chuumon_meisai_bikou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FChuumonMeisaiBikou2)
                    .HasColumnName("f_chuumon_meisai_bikou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FChuumonMeisaiGyou).HasColumnName("f_chuumon_meisai_gyou");

                entity.Property(e => e.FChuumonMeisaiJoutaiKubun)
                    .IsRequired()
                    .HasColumnName("f_chuumon_meisai_joutai_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FChuumonMeisaiNo)
                    .IsRequired()
                    .HasColumnName("f_chuumon_meisai_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FChuumonNo)
                    .IsRequired()
                    .HasColumnName("f_chuumon_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FChuumonTanka)
                    .HasColumnName("f_chuumon_tanka")
                    .HasColumnType("numeric");

                entity.Property(e => e.FDenwabangou)
                    .HasColumnName("f_denwabangou")
                    .HasMaxLength(20);

                entity.Property(e => e.FEmail)
                    .HasColumnName("f_email")
                    .HasMaxLength(256);

                entity.Property(e => e.FFaxBangou)
                    .HasColumnName("f_fax_bangou")
                    .HasMaxLength(20);

                entity.Property(e => e.FHakobangou)
                    .HasColumnName("f_hakobangou")
                    .HasMaxLength(20);

                entity.Property(e => e.FHinban)
                    .HasColumnName("f_hinban")
                    .HasMaxLength(30);

                entity.Property(e => e.FHinmokuCd)
                    .IsRequired()
                    .HasColumnName("f_hinmoku_cd")
                    .HasMaxLength(30);

                entity.Property(e => e.FHinmokuMei)
                    .HasColumnName("f_hinmoku_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FJushinNichiji)
                    .HasColumnName("f_jushin_nichiji")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FJuusho1)
                    .HasColumnName("f_juusho1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FJuusho2)
                    .HasColumnName("f_juusho2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKakuninNichiji)
                    .HasColumnName("f_kakunin_nichiji")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKatashiki)
                    .HasColumnName("f_katashiki")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKibouNouki).HasColumnName("f_kibou_nouki");

                entity.Property(e => e.FKoubaiKishumei)
                    .HasColumnName("f_koubai_kishumei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FNiuketantoushaDenwabangou)
                    .HasColumnName("f_niuketantousha_denwabangou")
                    .HasMaxLength(20);

                entity.Property(e => e.FNiuketantoushaMei)
                    .HasColumnName("f_niuketantousha_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FNounyuusakiMei)
                    .HasColumnName("f_nounyuusaki_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FSaizuH)
                    .HasColumnName("f_saizu_h")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSaizuL)
                    .HasColumnName("f_saizu_l")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSaizuW)
                    .HasColumnName("f_saizu_w")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSeiban)
                    .HasColumnName("f_seiban")
                    .HasMaxLength(30);

                entity.Property(e => e.FShiharaisakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiharaisaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiyouBikou)
                    .HasColumnName("f_shiyou_bikou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiyouJouhou)
                    .HasColumnName("f_shiyou_jouhou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShouhizeiKingaku)
                    .HasColumnName("f_shouhizei_kingaku")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSuuryou)
                    .HasColumnName("f_suuryou")
                    .HasColumnType("numeric");

                entity.Property(e => e.FTanaban)
                    .HasColumnName("f_tanaban")
                    .HasMaxLength(20);

                entity.Property(e => e.FTaniMei)
                    .IsRequired()
                    .HasColumnName("f_tani_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FYusoult).HasColumnName("f_yusoult");

                entity.Property(e => e.FYuubinbangou)
                    .HasColumnName("f_yuubinbangou")
                    .HasMaxLength(10);

                entity.Property(e => e.FZuban)
                    .HasColumnName("f_zuban")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TtWebKanjounengetsu>(entity =>
            {
                entity.HasKey(e => e.FEdiKanjounengetsuId)
                    .HasName("pk_tt_web_kanjounengetsu");

                entity.ToTable("tt_web_kanjounengetsu");

                entity.HasIndex(e => e.FEdiKanjounengetsuNo)
                    .HasName("tt_web_kanjounengetsu_uix01")
                    .IsUnique();

                entity.HasIndex(e => new { e.FNengetsu, e.FKaishiHi })
                    .HasName("tt_web_kanjounengetsu_ix02");

                entity.Property(e => e.FEdiKanjounengetsuId)
                    .HasColumnName("f_edi_kanjounengetsu_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiKanjounengetsuNo)
                    .IsRequired()
                    .HasColumnName("f_edi_kanjounengetsu_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FKaishiHi).HasColumnName("f_kaishi_hi");

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FNengetsu).HasColumnName("f_nengetsu");

                entity.Property(e => e.FShimezumi).HasColumnName("f_shimezumi");

                entity.Property(e => e.FShuuryouHi).HasColumnName("f_shuuryou_hi");
            });

            modelBuilder.Entity<TtWebKanjounengetsuRireki>(entity =>
            {
                entity.HasKey(e => e.FRirekiNo)
                    .HasName("pk_tt_web_kanjounengetsu_rireki");

                entity.ToTable("tt_web_kanjounengetsu_rireki");

                entity.Property(e => e.FRirekiNo)
                    .HasColumnName("f_rireki_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiKanjounengetsuId).HasColumnName("f_edi_kanjounengetsu_id");

                entity.Property(e => e.FEdiKanjounengetsuNo)
                    .IsRequired()
                    .HasColumnName("f_edi_kanjounengetsu_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FKaishiHi).HasColumnName("f_kaishi_hi");

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FNengetsu).HasColumnName("f_nengetsu");

                entity.Property(e => e.FShimezumi).HasColumnName("f_shimezumi");

                entity.Property(e => e.FShoriModo).HasColumnName("f_shori_modo");

                entity.Property(e => e.FShuuryouHi).HasColumnName("f_shuuryou_hi");

                entity.Property(e => e.FTaimusutanpu)
                    .HasColumnName("f_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");
            });

            modelBuilder.Entity<TtWebNouhinmeisai>(entity =>
            {
                entity.HasKey(e => e.FEdiNouhinmeisaiId)
                    .HasName("pk_tt_web_nouhinmeisai");

                entity.ToTable("tt_web_nouhinmeisai");

                entity.HasIndex(e => e.FChuumonMeisaiNo)
                    .HasName("tt_web_nouhinmeisai_ix02");

                entity.HasIndex(e => new { e.FChuumonNo, e.FChuumonMeisaiGyou })
                    .HasName("tt_web_nouhinmeisai_uix01")
                    .IsUnique();

                entity.HasIndex(e => new { e.FShiiresakiCd, e.FShiharaisakiCd, e.FKenshuuHi })
                    .HasName("tt_web_nouhinmeisai_ix03");

                entity.Property(e => e.FEdiNouhinmeisaiId)
                    .HasColumnName("f_edi_nouhinmeisai_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FChuumonMeisaiGyou).HasColumnName("f_chuumon_meisai_gyou");

                entity.Property(e => e.FChuumonMeisaiNo)
                    .IsRequired()
                    .HasColumnName("f_chuumon_meisai_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FChuumonNo)
                    .IsRequired()
                    .HasColumnName("f_chuumon_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FHinban)
                    .HasColumnName("f_hinban")
                    .HasMaxLength(30);

                entity.Property(e => e.FHinmokuCd)
                    .IsRequired()
                    .HasColumnName("f_hinmoku_cd")
                    .HasMaxLength(30);

                entity.Property(e => e.FHinmokuMei)
                    .HasColumnName("f_hinmoku_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FJushinNichiji)
                    .HasColumnName("f_jushin_nichiji")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKatashiki)
                    .HasColumnName("f_katashiki")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKenshuuHi).HasColumnName("f_kenshuu_hi");

                entity.Property(e => e.FKenshuuSuu)
                    .HasColumnName("f_kenshuu_suu")
                    .HasColumnType("numeric");

                entity.Property(e => e.FKenshuuYoteiKubun)
                    .IsRequired()
                    .HasColumnName("f_kenshuu_yotei_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FKoubaiKishumei)
                    .HasColumnName("f_koubai_kishumei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FNouhinMeisaiBikou1)
                    .HasColumnName("f_nouhin_meisai_bikou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FNouhinMeisaiBikou2)
                    .HasColumnName("f_nouhin_meisai_bikou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FSaizuH)
                    .HasColumnName("f_saizu_h")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSaizuL)
                    .HasColumnName("f_saizu_l")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSaizuW)
                    .HasColumnName("f_saizu_w")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSeiban)
                    .HasColumnName("f_seiban")
                    .HasMaxLength(30);

                entity.Property(e => e.FShiharaisakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiharaisaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiireKingaku)
                    .HasColumnName("f_shiire_kingaku")
                    .HasColumnType("numeric");

                entity.Property(e => e.FShiireMeisaiNo)
                    .IsRequired()
                    .HasColumnName("f_shiire_meisai_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiireTanka)
                    .HasColumnName("f_shiire_tanka")
                    .HasColumnType("numeric");

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiyouBikou)
                    .HasColumnName("f_shiyou_bikou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiyouJouhou)
                    .HasColumnName("f_shiyou_jouhou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShouhizeiKingaku)
                    .HasColumnName("f_shouhizei_kingaku")
                    .HasColumnType("numeric");

                entity.Property(e => e.FZuban)
                    .HasColumnName("f_zuban")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TtWebNouhinmeisaiRireki>(entity =>
            {
                entity.HasKey(e => e.FRirekiNo)
                    .HasName("pk_tt_web_nouhinmeisai_rireki");

                entity.ToTable("tt_web_nouhinmeisai_rireki");

                entity.Property(e => e.FRirekiNo)
                    .HasColumnName("f_rireki_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FChuumonMeisaiGyou).HasColumnName("f_chuumon_meisai_gyou");

                entity.Property(e => e.FChuumonMeisaiNo)
                    .IsRequired()
                    .HasColumnName("f_chuumon_meisai_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FChuumonNo)
                    .IsRequired()
                    .HasColumnName("f_chuumon_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FEdiNouhinmeisaiId).HasColumnName("f_edi_nouhinmeisai_id");

                entity.Property(e => e.FHinban)
                    .HasColumnName("f_hinban")
                    .HasMaxLength(30);

                entity.Property(e => e.FHinmokuCd)
                    .IsRequired()
                    .HasColumnName("f_hinmoku_cd")
                    .HasMaxLength(30);

                entity.Property(e => e.FHinmokuMei)
                    .HasColumnName("f_hinmoku_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FJushinNichiji)
                    .HasColumnName("f_jushin_nichiji")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKatashiki)
                    .HasColumnName("f_katashiki")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKenshuuHi).HasColumnName("f_kenshuu_hi");

                entity.Property(e => e.FKenshuuSuu)
                    .HasColumnName("f_kenshuu_suu")
                    .HasColumnType("numeric");

                entity.Property(e => e.FKenshuuYoteiKubun)
                    .IsRequired()
                    .HasColumnName("f_kenshuu_yotei_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FKoubaiKishumei)
                    .HasColumnName("f_koubai_kishumei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FNouhinMeisaiBikou1)
                    .HasColumnName("f_nouhin_meisai_bikou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FNouhinMeisaiBikou2)
                    .HasColumnName("f_nouhin_meisai_bikou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FSaizuH)
                    .HasColumnName("f_saizu_h")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSaizuL)
                    .HasColumnName("f_saizu_l")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSaizuW)
                    .HasColumnName("f_saizu_w")
                    .HasColumnType("numeric");

                entity.Property(e => e.FSeiban)
                    .HasColumnName("f_seiban")
                    .HasMaxLength(30);

                entity.Property(e => e.FShiharaisakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiharaisaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiireKingaku)
                    .HasColumnName("f_shiire_kingaku")
                    .HasColumnType("numeric");

                entity.Property(e => e.FShiireMeisaiNo)
                    .IsRequired()
                    .HasColumnName("f_shiire_meisai_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiireTanka)
                    .HasColumnName("f_shiire_tanka")
                    .HasColumnType("numeric");

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiyouBikou)
                    .HasColumnName("f_shiyou_bikou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiyouJouhou)
                    .HasColumnName("f_shiyou_jouhou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShoriModo).HasColumnName("f_shori_modo");

                entity.Property(e => e.FShouhizeiKingaku)
                    .HasColumnName("f_shouhizei_kingaku")
                    .HasColumnType("numeric");

                entity.Property(e => e.FTaimusutanpu)
                    .HasColumnName("f_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FZuban)
                    .HasColumnName("f_zuban")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TtWebRogu>(entity =>
            {
                entity.HasKey(e => e.FEdiRoguId)
                    .HasName("pk_tt_web_rogu");

                entity.ToTable("tt_web_rogu");

                entity.HasIndex(e => e.FEdiRoguNo)
                    .HasName("tt_web_rogu_uix01")
                    .IsUnique();

                entity.HasIndex(e => e.FKinouId)
                    .HasName("tt_web_rogu_ix02");

                entity.Property(e => e.FEdiRoguId)
                    .HasColumnName("f_edi_rogu_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiRoguNo)
                    .IsRequired()
                    .HasColumnName("f_edi_rogu_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FEraKubun)
                    .HasColumnName("f_era_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FEraNaiyou1)
                    .HasColumnName("f_era_naiyou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FEraNaiyou2)
                    .HasColumnName("f_era_naiyou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKinouId)
                    .HasColumnName("f_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKuraiantoIpadoresu)
                    .HasColumnName("f_kuraianto_ipadoresu")
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<TtWebRoguRireki>(entity =>
            {
                entity.HasKey(e => e.FRirekiNo)
                    .HasName("pk_tt_web_rogu_rireki");

                entity.ToTable("tt_web_rogu_rireki");

                entity.Property(e => e.FRirekiNo)
                    .HasColumnName("f_rireki_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiRoguId).HasColumnName("f_edi_rogu_id");

                entity.Property(e => e.FEdiRoguNo)
                    .IsRequired()
                    .HasColumnName("f_edi_rogu_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FEraKubun)
                    .HasColumnName("f_era_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FEraNaiyou1)
                    .HasColumnName("f_era_naiyou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FEraNaiyou2)
                    .HasColumnName("f_era_naiyou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FKinouId)
                    .HasColumnName("f_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKuraiantoIpadoresu)
                    .HasColumnName("f_kuraianto_ipadoresu")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShoriModo).HasColumnName("f_shori_modo");

                entity.Property(e => e.FTaimusutanpu)
                    .HasColumnName("f_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");
            });

            modelBuilder.Entity<TtWebRoguinyuza>(entity =>
            {
                entity.HasKey(e => e.FEdiRoguinYuzaId)
                    .HasName("pk_tt_web_roguinyuza");

                entity.ToTable("tt_web_roguinyuza");

                entity.HasIndex(e => e.FEdiRoguinYuzaNo)
                    .HasName("tt_web_roguinyuza_uix01")
                    .IsUnique();

                entity.HasIndex(e => new { e.FShiiresakiCd, e.FYuzaId })
                    .HasName("tt_web_roguinyuza_ix02");

                entity.Property(e => e.FEdiRoguinYuzaId)
                    .HasColumnName("f_edi_roguin_yuza_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiRoguinYuzaNo)
                    .IsRequired()
                    .HasColumnName("f_edi_roguin_yuza_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FJishaShiiresakiKubun)
                    .IsRequired()
                    .HasColumnName("f_jisha_shiiresaki_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FMeruSoushinKubun)
                    .IsRequired()
                    .HasColumnName("f_meru_soushin_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FMeruadoresu)
                    .HasColumnName("f_meruadoresu")
                    .HasMaxLength(256);

                entity.Property(e => e.FPasuwado)
                    .IsRequired()
                    .HasColumnName("f_pasuwado")
                    .HasMaxLength(4000);

                entity.Property(e => e.FRotsukuKubun)
                    .IsRequired()
                    .HasColumnName("f_rotsuku_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FSaishuuRoguinNichiji)
                    .HasColumnName("f_saishuu_roguin_nichiji")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FTantoushaMei)
                    .HasColumnName("f_tantousha_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FYuzaBikou)
                    .HasColumnName("f_yuza_bikou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FYuzaId)
                    .IsRequired()
                    .HasColumnName("f_yuza_id")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TtWebRoguinyuzaRireki>(entity =>
            {
                entity.HasKey(e => e.FRirekiNo)
                    .HasName("pk_tt_web_roguinyuza_rireki");

                entity.ToTable("tt_web_roguinyuza_rireki");

                entity.Property(e => e.FRirekiNo)
                    .HasColumnName("f_rireki_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiRoguinYuzaId).HasColumnName("f_edi_roguin_yuza_id");

                entity.Property(e => e.FEdiRoguinYuzaNo)
                    .IsRequired()
                    .HasColumnName("f_edi_roguin_yuza_no")
                    .HasMaxLength(10);

                entity.Property(e => e.FJishaShiiresakiKubun)
                    .IsRequired()
                    .HasColumnName("f_jisha_shiiresaki_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FMeruSoushinKubun)
                    .IsRequired()
                    .HasColumnName("f_meru_soushin_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FMeruadoresu)
                    .HasColumnName("f_meruadoresu")
                    .HasMaxLength(256);

                entity.Property(e => e.FPasuwado)
                    .IsRequired()
                    .HasColumnName("f_pasuwado")
                    .HasMaxLength(4000);

                entity.Property(e => e.FRotsukuKubun)
                    .IsRequired()
                    .HasColumnName("f_rotsuku_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FSaishuuRoguinNichiji)
                    .HasColumnName("f_saishuu_roguin_nichiji")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShoriModo).HasColumnName("f_shori_modo");

                entity.Property(e => e.FTaimusutanpu)
                    .HasColumnName("f_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FTantoushaMei)
                    .HasColumnName("f_tantousha_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FYuzaBikou)
                    .HasColumnName("f_yuza_bikou")
                    .HasMaxLength(4000);

                entity.Property(e => e.FYuzaId)
                    .IsRequired()
                    .HasColumnName("f_yuza_id")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TtWebShiiresaki>(entity =>
            {
                entity.HasKey(e => e.FEdiShiiresakiId)
                    .HasName("pk_tt_web_shiiresaki");

                entity.ToTable("tt_web_shiiresaki");

                entity.HasIndex(e => e.FShiiresakiCd)
                    .HasName("tt_web_shiiresaki_uix01")
                    .IsUnique();

                entity.Property(e => e.FEdiShiiresakiId)
                    .HasColumnName("f_edi_shiiresaki_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiChuumonshoKingakuhyoujiKubun)
                    .HasColumnName("f_edi_chuumonsho_kingakuhyouji_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FEdiNouhinmeisaiShoukaihyoujiKubun)
                    .HasColumnName("f_edi_nouhinmeisai_shoukaihyouji_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FHatsuchuuEdiSoushinKubun)
                    .HasColumnName("f_hatsuchuu_edi_soushin_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FShiiresakiBikou1)
                    .HasColumnName("f_shiiresaki_bikou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiiresakiBikou2)
                    .HasColumnName("f_shiiresaki_bikou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiiresakiMei)
                    .HasColumnName("f_shiiresaki_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FToiawaseFax)
                    .HasColumnName("f_toiawase_fax")
                    .HasMaxLength(20);

                entity.Property(e => e.FToiawaseTantoushaMei)
                    .HasColumnName("f_toiawase_tantousha_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FToiawaseTel)
                    .HasColumnName("f_toiawase_tel")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TtWebShiiresakiRireki>(entity =>
            {
                entity.HasKey(e => e.FRirekiNo)
                    .HasName("pk_tt_web_shiiresaki_rireki");

                entity.ToTable("tt_web_shiiresaki_rireki");

                entity.Property(e => e.FRirekiNo)
                    .HasColumnName("f_rireki_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.FBajon).HasColumnName("f_bajon");

                entity.Property(e => e.FEdiChuumonshoKingakuhyoujiKubun)
                    .HasColumnName("f_edi_chuumonsho_kingakuhyouji_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FEdiNouhinmeisaiShoukaihyoujiKubun)
                    .HasColumnName("f_edi_nouhinmeisai_shoukaihyouji_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FEdiShiiresakiId).HasColumnName("f_edi_shiiresaki_id");

                entity.Property(e => e.FHatsuchuuEdiSoushinKubun)
                    .HasColumnName("f_hatsuchuu_edi_soushin_kubun")
                    .HasMaxLength(2);

                entity.Property(e => e.FKoushinKinouId)
                    .IsRequired()
                    .HasColumnName("f_koushin_kinou_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKonpyutaMei)
                    .IsRequired()
                    .HasColumnName("f_koushin_konpyuta_mei")
                    .HasMaxLength(256);

                entity.Property(e => e.FKoushinKontororuNo).HasColumnName("f_koushin_kontororu_no");

                entity.Property(e => e.FKoushinTaimusutanpu)
                    .HasColumnName("f_koushin_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FKoushinYuzaId)
                    .IsRequired()
                    .HasColumnName("f_koushin_yuza_id")
                    .HasMaxLength(256);

                entity.Property(e => e.FShiiresakiBikou1)
                    .HasColumnName("f_shiiresaki_bikou1")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiiresakiBikou2)
                    .HasColumnName("f_shiiresaki_bikou2")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShiiresakiCd)
                    .IsRequired()
                    .HasColumnName("f_shiiresaki_cd")
                    .HasMaxLength(10);

                entity.Property(e => e.FShiiresakiMei)
                    .HasColumnName("f_shiiresaki_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FShoriModo).HasColumnName("f_shori_modo");

                entity.Property(e => e.FTaimusutanpu)
                    .HasColumnName("f_taimusutanpu")
                    .HasColumnType("timestamp(3) without time zone");

                entity.Property(e => e.FToiawaseFax)
                    .HasColumnName("f_toiawase_fax")
                    .HasMaxLength(20);

                entity.Property(e => e.FToiawaseTantoushaMei)
                    .HasColumnName("f_toiawase_tantousha_mei")
                    .HasMaxLength(4000);

                entity.Property(e => e.FToiawaseTel)
                    .HasColumnName("f_toiawase_tel")
                    .HasMaxLength(20);
            });

            modelBuilder.HasSequence("s_f_edi_hatsuchuumeisai_id");
        }
    }
}
