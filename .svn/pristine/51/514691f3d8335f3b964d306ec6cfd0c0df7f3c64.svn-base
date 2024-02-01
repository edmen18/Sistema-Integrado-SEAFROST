namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RSFACAR : DbContext
    {
        public RSFACAR()
            : base("name=RSFACAR")
        {
        }
        public virtual DbSet<FT0003LINE> FT0003LINE { get; set; }
        public virtual DbSet<VISTA_REQUERIMIENTOS> VISTA_REQUERIMIENTOS { get; set; }
        public virtual DbSet<AL0003REQC> AL0003REQC { get; set; }
        public virtual DbSet<AL0003REQD> AL0003REQD { get; set; }
        public virtual DbSet<AL0003ARTI> AL0003ARTI { get; set; }
        public virtual DbSet<UT0030> UT0030 { get; set; }
        public virtual DbSet<AL0003TABL> AL0003TABL { get; set; } 
        public virtual DbSet<FT0003NUME> FT0003NUME { get; set; }

        public virtual DbSet<CO0003MOVC> CO0003MOVC { get; set; }
        public virtual DbSet<CO0003MOVD> CO0003MOVD { get; set; }
        public virtual DbSet<AL0003ALMA> AL0003ALMA { get; set; }
        public virtual DbSet<ALCIAS> ALCIAS { get; set; }
        public virtual DbSet<CO0003MOVI> CO0003MOVI { get; set; }
        public virtual DbSet<AL0003APRO> AL0003APRO { get; set; }
        public object vista_cocabcera { get; set; }
        public object CO0003MOV { get; set; }
        public virtual DbSet<AL0003STOC> AL0003STOC { get; set; }
        public virtual DbSet<AL0003SERI> AL0003SERI { get; set; }
        public virtual DbSet<FT0003CLIE> FT0003CLIE { get; set; }
        public virtual DbSet<AL0003MOVC> AL0003MOVC { get; set; }
        public virtual DbSet<AL0003MOVD> AL0003MOVD { get; set; }
        public virtual DbSet<AL0003TABM> AL0003TABM { get; set; }
        public virtual DbSet<FT0003TCAJ> FT0003TCAJ { get; set; }
        public virtual DbSet<AL0003CABA> AL0003CABA { get; set; }
        public virtual DbSet<AL0003FACC> AL0003FACC { get; set; }
        public virtual DbSet<AL0003FACD> AL0003FACD { get; set; }
        //NUEVO WILLIAM
        public virtual DbSet<AL0003ASER> AL0003ASER { get; set; }

        //nuevo sergio 26032016
        public virtual DbSet<AL0003LOGC> AL0003LOGC { get; set; }
        public virtual DbSet<AL0003SKNU> AL0003SKNU { get; set; }
        public virtual DbSet<AL0003RESU> AL0003RESU { get; set; }
        public virtual DbSet<AL0003MOVG> AL0003MOVG { get; set; }
        public virtual DbSet<FT0003CTAE> FT0003CTAE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FT0003LINE>()
                .Property(e => e.LI_CCODLIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003LINE>()
                .Property(e => e.LI_CDESLIN)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003LINE>()
                .Property(e => e.LI_COBSER1)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003LINE>()
                .Property(e => e.LI_COBSER2)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003LINE>()
                .Property(e => e.LI_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003LINE>()
                .Property(e => e.LI_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
               .Property(e => e.RC_CNROREQ)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.RC_DFECREQ)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.PROVEEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.APROBAC)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.RC_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.RC_CPRVSUG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.RC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.RC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_REQUERIMIENTOS>()
                .Property(e => e.RC_CTIPREQ)
                .IsFixedLength()
                .IsUnicode(false);
            modelBuilder.Entity<AL0003TABL>()
               .Property(e => e.TG_CCOD)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<AL0003TABL>()
                .Property(e => e.TG_CCLAVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABL>()
                .Property(e => e.TG_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABL>()
                .Property(e => e.TG_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABL>()
                .Property(e => e.TG_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
              .Property(e => e.TN_CCODIGO)
              .IsFixedLength()
              .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CNUMSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_NNUMINI)
                .HasPrecision(7, 0);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_NNUMFIN)
                .HasPrecision(7, 0);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_NNUMERO)
                .HasPrecision(7, 0);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CFORMAT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CESTACI)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CPUERTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CNUMAUT)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CRUTFW)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CRUTFW2)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CPRINTE)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CTIPLET)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CMODIMP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CTIPIMP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003NUME>()
                .Property(e => e.TN_CTIPMAQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
               .Property(e => e.RC_CNROREQ)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CCODSOLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CCODAREA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CPRVSUG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CUSEA01)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CUSEA02)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CUSEA03)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CUNIREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_NIMPMN)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_NIMPUS)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_NTIPCAM)
                .HasPrecision(8, 3);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CAGEOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CNUMOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CORIREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CTIPREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CGLOSA1)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CGLOSA2)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CTIPAPR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CAREARQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQC>()
                .Property(e => e.RC_CNUMCOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CNROREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CDESCRI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CUNID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NQPEDI)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_COBS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NQATEN)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CSITUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NQINGALM)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NQDESPA)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NCANAPR)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NPRUNMN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NPRUNUS)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NPRU2MN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NPRU2US)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NIGV)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NIGVPOR)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NTOTMN)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NTOTUS)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NDSCPOR)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NDESCTO)
                .HasPrecision(12, 2);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CUSRAPR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_NCANALM)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CCODCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CFLGASG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003REQD>()
                .Property(e => e.RD_CUSRCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
              .Property(e => e.TU_ALIAS)
              .IsFixedLength()
              .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_NOMUSU)
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_PASSWO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_LOCEMI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_DPTMTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_TIPUSU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_NROALM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_FORVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_IMPRES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_USUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_USUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CNUMMAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_TELEFONO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CORREO)
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CCODCAJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CAJMN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CAJUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CAPRPD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CAPRRQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CAPROC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CAPRLV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UT0030>()
                .Property(e => e.TU_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CDESCR2)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODIG2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CUNIDAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECI1)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECI2)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECI3)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECI4)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECI5)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECI6)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMONVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NIGVPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NISCPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCONTRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CTIPDES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NDESCTO)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NDESCT2)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPDIS)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPCOM)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CGRUPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFAMILI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMODELO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CLINEA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPESO)
                .HasPrecision(15, 8);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NVOLUME)
                .HasPrecision(9, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NAREA)
                .HasPrecision(9, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NFACTOR)
                .HasPrecision(9, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NANCHO)
                .HasPrecision(9, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NLARGO)
                .HasPrecision(9, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMONCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECOS)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMONCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPRECOM)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMONFOB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPREFOB)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NMARGE1)
                .HasPrecision(7, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NMARGE2)
                .HasPrecision(7, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCLAART)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CPARARA)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CINFTEC)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCATALO)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCATEGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CTIPOI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_TOBSERV)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CUNIREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NFACREF)
                .HasPrecision(9, 3);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFUNIRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFDECI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFPRELI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFRESTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFLOTE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFROTAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CUSUCRE)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CUSUMOD)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODANT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NDETRA)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMEDIDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CANNO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CGROSOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NIMAGEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFECABC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NLONSER)
                .HasPrecision(2, 0);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFCELU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NLONCEL)
                .HasPrecision(2, 0);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMEDNEU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CINDCAR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CDISENO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPERC1)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NPERC2)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CMARCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CANOFAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CLUGORI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFVEHI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CAYUVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCOLOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CTALLA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CTIPEXI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NMARVTA)
                .HasPrecision(3, 0);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CHORSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NIGVCPR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCUENTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFLGRCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_NTASRCN)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CFORSER)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODAG1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODAG2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODAG3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODAG4)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_CCODAG5)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ARTI>()
                .Property(e => e.AR_PERTOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
               .Property(e => e.OC_CNUMORD)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRAZSOC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CDIRPRO)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCOTIZA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CFORPA1)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CFORPA2)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CFORPA3)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NTIPCAM)
                .HasPrecision(8, 4);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NPORDES)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCARDES)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPUS)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPMN)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CSOLICT)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CTIPENV)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CLUGENT)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CLUGFAC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CDETENT)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CSITORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CUSUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CTIPORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRESPER1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRESPER2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRESPER3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRESCARG1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRESCARG2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CRESCARG3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCOPAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CUSEA01)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CUSEA02)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CUSEA03)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CREMITE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CPERATE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCONTA1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCONTA2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCONTA3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CNUMFAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CUNIORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCONVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCONEMB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCONDIC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CTIPENT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CDIAENT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NFLEINT)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NDOCCHA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NFLETE)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NSEGURO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPFAC)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPFOB)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPCF)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPCIF)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CNUMREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CTIPDSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CALMDES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CDISTOC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CPROVOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCOSTOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CDOCPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CESTPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CMONPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_NIMPPAG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CGLOPAG)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCODSOL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CCODTAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVC>()
                .Property(e => e.OC_CORDTRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CCODREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CDESREF)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CUNIPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CDEUNPR)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CUNIDAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCANORD)
                .HasPrecision(13, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NPREUNI)
                .HasPrecision(18, 9);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NPREUN2)
                .HasPrecision(18, 9);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDSCPFI)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDESCFI)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDSCPIT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDESCIT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDSCPAD)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDESCAD)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDSCPOR)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NDESCTO)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NIGV)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NIGVPOR)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NISC)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NISCPOR)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCANTEN)
                .HasPrecision(13, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCANSAL)
                .HasPrecision(13, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NTOTUS)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NTOTMN)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_COMENTA)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_FUNICOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCANREF)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NANCHO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCORTE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CTIPORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CNUMREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CSOLICI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CITEREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CREFCOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CPEDINT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CITEINT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CREFCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CNOMFAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCANEMB)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CITMPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CDSCPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CIGVPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_CISCPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NTOTMO)
                .HasPrecision(12, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NUNXENV)
                .HasPrecision(8, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NNUMENV)
                .HasPrecision(7, 3);

            modelBuilder.Entity<CO0003MOVD>()
                .Property(e => e.OC_NCANFAC)
                .HasPrecision(13, 3);




            //nuevo ALMACEN
            modelBuilder.Entity<AL0003ALMA>()
              .Property(e => e.A1_CALMA)
              .IsFixedLength()
              .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CLOCALI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CDIRECC)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CDISTRI)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CTEL)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CCTLNUM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_NNUMENT)
                .HasPrecision(10, 0);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_NNUMSAL)
                .HasPrecision(10, 0);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_NNUMSER)
                .HasPrecision(10, 0);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_NNUMGUI)
                .HasPrecision(10, 0);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_NNUMFIN)
                .HasPrecision(10, 0);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CPROV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CDEPT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CCODCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CDESCR2)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CDIREC2)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ALMA>()
                .Property(e => e.A1_CCOSTO)
                .IsFixedLength()
                .IsUnicode(false);

            //compania
            modelBuilder.Entity<ALCIAS>()
               .Property(e => e.AC_CCIA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CNOMCIA)
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CDIRCIA)
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CNOMLOC)
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CRUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CMN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_NTIPCAM)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CRUTVEN)
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CRUTPLA)
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CRUTCON)
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CFILE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CCIACON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CPROVIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CPAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CCODARE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CTELEF1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CTELEF2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CFAX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CEMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CCONTAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERSTF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERSOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERSMO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERSLO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CPCGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERSLQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALCIAS>()
                .Property(e => e.AC_CVERSEX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
               .Property(e => e.PM_CCODMAT)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_CTIPMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_NVALOR)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_CCOTIZA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_CORDCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003APRO>()
                .Property(e => e.PM_CUSER)
                .IsFixedLength()
                .IsUnicode(false);

            //movi
            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CNUMORD)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCODPRO)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CSTNOMC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CSTPAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CSTDIRC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CSTTELC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CSTFAXC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CSTPERA)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCTNOMC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCTPAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCTDIRC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCTTELC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCTFAXC)
                .IsUnicode(false);

            modelBuilder.Entity<CO0003MOVI>()
                .Property(e => e.OC_CCTPERA)
                .IsUnicode(false);

            //codigo william
            modelBuilder.Entity<AL0003SERI>()
              .Property(e => e.SR_CALMA)
              .IsFixedLength()
              .IsUnicode(false);

            modelBuilder.Entity<AL0003SERI>()
                .Property(e => e.SR_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003SERI>()
                .Property(e => e.SR_CSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003SERI>()
                .Property(e => e.SR_NSKDIS)
                .HasPrecision(10, 3);

            modelBuilder.Entity<AL0003SERI>()
                .Property(e => e.SR_NSKCOM)
                .HasPrecision(10, 3);

            modelBuilder.Entity<AL0003SERI>()
                .Property(e => e.SR_NPREUNI)
                .HasPrecision(13, 4);

            /*TERMINAR AL0003SERI*/
            /*NUEVO INGRESO*/
            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSKDIS)
                .HasPrecision(12, 3);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSKCOM)
                .HasPrecision(12, 3);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSKMIN)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSKMAX)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CMESPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NPREUNI)
                .HasPrecision(13, 4);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSKMES)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSKVAL)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NPUNREP)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NSEMREP)
                .HasPrecision(3, 0);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CTIPREP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CUBIALM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CUBIAL2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CUBIAL3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CUBIAL4)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_NLOTCOM)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003STOC>()
                .Property(e => e.SK_CTIPCOM)
                .IsFixedLength()
                .IsUnicode(false);

            /**/
            modelBuilder.Entity<FT0003CLIE>()
                            .Property(e => e.CL_CCODCLI)
                            .IsFixedLength()
                            .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODCL2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CNOMCLI)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDIRCLI)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTELEFO)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CNUMFAX)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CNUMRUC)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDISTRI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CPROV)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDEPT)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CPAIS)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDIRENT)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDISTR1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CPROV1)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDEPT1)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CPAIS1)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPPER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CGIRNEG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPPRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPDES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NPORDES)
                .HasPrecision(5, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NPORDE2)
                .HasPrecision(5, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CZONPOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CZONVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CFREVIS)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDIAATE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CHORATE)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPATE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CHOST)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_TCOMENT)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CUBIGEO)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CREPLEG)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CLEREPL)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CNOMCOM)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCADENA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODINT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NDOCVEN)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NDIAVEN)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NMORLET)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NMORFAC)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NCHEDEV)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NLETPRO)
                .HasPrecision(10, 0);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CMONCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NLMCRUS)
                .HasPrecision(19, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NLMCRMN)
                .HasPrecision(19, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NSALDMN)
                .HasPrecision(19, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NSALDUS)
                .HasPrecision(19, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CFLADES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_COBTLOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCLASIF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODANT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODAUX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCATCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CPATERN)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CMATERN)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CPRINOM)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CSEGNOM)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CVENDE2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCTABAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CSEGMEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CFPERCP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NFACPER)
                .HasPrecision(14, 6);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPDNC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CFDETRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CFSELEC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODEAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CFRETEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_NFACRET)
                .HasPrecision(9, 2);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODINQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CAVAL)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTELEF2)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CNUMCEL)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CZONCOB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDIACOB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CZONREG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDIAREG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTDOCID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPPRC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODDPT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODPRV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CTIPRET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CDOCIDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CNUMIDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CLIE>()
                .Property(e => e.CL_CCODIDI)
                .IsFixedLength()
                .IsUnicode(false);
            /*TERMINAR*/
            modelBuilder.Entity<AL0003MOVC>()
              .Property(e => e.C5_CALMA)
              .IsFixedLength()
              .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CLOCALI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSITUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRFTDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRFNDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSOLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRFALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CGLOSA1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CGLOSA2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CGLOSA3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODANE)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNOMCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODCAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODINT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODTRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNOMTRA)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODVEH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPGUI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSITGUI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CGUIFAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CDESTIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CDIRENV)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CGUIDEV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNOMPRO)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCIAS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CFORVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNUMPED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CDIRECC)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NIMPORT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NPORDE1)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NPORDE2)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NFLETE)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODAUT)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRFTDO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRFNDO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CNUMLIQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CORDEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPOGS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCODFER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CGLOSA4)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CVENDE2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CESTDEV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CEXTOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRENOM)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CRERUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CREREF)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CDSNOM)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CDSRUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CLLECIU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CPARCIU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTTRACT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTRASRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTRAREM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CLICCON)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSBNOM)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSBRUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CSBMTC)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CMONPER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NIMPPER)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CFPERCP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CESTFIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CFLGPEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CTIPFOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_NPORPER)
                .HasPrecision(8, 2);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CFLGTRM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CAGETRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVC>()
                .Property(e => e.C5_CCONTAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CLOCALI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANTID)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANTEN)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANFAC)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPREUN1)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPREUNI)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NMNPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NUSPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CSITUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CRFALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTALLA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CORDEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NVALTOT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NMNIMPO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NUSIMPO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPREVTA)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CMONVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NUNXENV)
                .HasPrecision(8, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NNUMENV)
                .HasPrecision(7, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NDEVOL)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CSOLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPRECIO)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPRECI1)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NDESCTO)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIGV)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIGVPOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPORDE1)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPO1)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPORDE2)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPO2)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPORDE3)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPO3)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPORDE4)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPO4)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPORDE5)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NIMPO5)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPORDES)
                .HasPrecision(6, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTIPITM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNUMPAQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODLIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNROTAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNDSCF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNDSCL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNDSCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNDSCB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNFLAT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPESO)
                .HasPrecision(10, 4);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NPRSIGV)
                .HasPrecision(20, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTIPANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODAUX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CITEREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNROREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NTEMPER)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NISCPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NISC)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CITEFAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANRPE)
                .HasPrecision(13, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNUMREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CITERQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODRQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CTIPPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANREQ)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCTACMO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CUMREF)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANDEC)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_NCANREF)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CITEMOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CVANEX2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODAN2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVD>()
                .Property(e => e.C6_CCODEMPQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CTIPMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CCODMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFPROV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFSOLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFCCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFGLOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFORDEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CCODANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CORDCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CTIPCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CPRIVAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CTIPANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFCONSU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM01)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM02)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM03)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM04)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM05)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM06)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM07)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM08)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM09)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CREPM10)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFCTACO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CCODSNT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFLGCVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFLGCOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003TABM>()
                .Property(e => e.TM_CFLGCSM)
                .IsFixedLength()
                .IsUnicode(false);
            /*NUEVO WILLIAM*/
            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CTURNO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CZONA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CNOMENT)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CHORINP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CNDERM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CMATEMB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CNOMEMB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003CABA>()
                .Property(e => e.C8_CNROPLA)
                .IsFixedLength()
                .IsUnicode(false);

            /*NUEVO WILLIAM*/
            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CDH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNROCAJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCODPRV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNOMBRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CDIRECC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCHENUM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NIMPORT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NIMPRET)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CFORVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NSALDO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NIMPIGV)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRFTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRFNUMSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRFNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNROPED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CGLOSA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NDESCTO)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_TOBSERV)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCALIDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CORIGEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTIPOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CDESCRI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NCANTID)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CUNIDAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NPRECIO)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NPRECI1)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIGVMN)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIGVUS)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIGVPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPRMN)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPRUS)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CNROCAJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);
            /*NUEVO WILLIAM*/
            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CLOCALI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_NCANTID)
                .HasPrecision(12, 3);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CITEREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CNUMCEL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_NCANRPE)
                .HasPrecision(13, 3);


            //sergio nuevo 26032016
            modelBuilder.Entity<AL0003LOGC>()
                .Property(e => e.LC_NREGACT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AL0003LOGC>()
                .Property(e => e.LC_CPERIODO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003LOGC>()
                .Property(e => e.LC_CTIPCIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003LOGC>()
                .Property(e => e.LC_CUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003LOGC>()
                .Property(e => e.LC_CTIPCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003LOGC>()
                .Property(e => e.LC_CHORREG)
                .IsFixedLength()
                .IsUnicode(false);

            //nuevo 28032016
            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_NCANANT)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_NCANENT)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_NCANSAL)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_NCANACT)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003SKNU>()
                .Property(e => e.SA_CMESPRO)
                .IsFixedLength()
                .IsUnicode(false);

            //resumen 29.03.2016
            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CLOCALI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CMESPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NUSPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NMNPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NUSPRAN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NMNPRAN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NCANENT)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NCANSAL)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NANTCAN)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NACTCAN)
                .HasPrecision(14, 3);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NMNANVL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NUSANVL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NMNACVL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NUSACVL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NUSENT)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NMNENT)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NUSSAL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_NMNSAL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CGRUPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CFAMILI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CMODELO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CLINEA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CMARCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CLUGORI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CANOFAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003RESU>()
                .Property(e => e.VL_CCUENTR)
                .IsFixedLength()
                .IsUnicode(false);

            //MOVG sergio
            modelBuilder.Entity<AL0003MOVG>()
               .Property(e => e.C6_CALMA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CNUMSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CGRUPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CFAMILI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CMODELO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CLINEA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NCANTID)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NPREUNI)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NMNPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NUSPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CSERIE)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CTIPMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CORDEN)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NVAVTMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NVAVTUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NVALTOT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NMNIMPO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NUSIMPO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CFSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CGUIFAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CPRIVAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CRFTDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CRFNDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CRFALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CTIPORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CSOLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CTIPCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CTIPANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCODANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCTACMO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CMARCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CLUGORI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CANOFAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003MOVG>()
                .Property(e => e.C6_CCUENTR)
                .IsFixedLength()
                .IsUnicode(false);

            //cuentas existencia
            modelBuilder.Entity<FT0003CTAE>()
               .Property(e => e.TC_CEXISTE)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CVENTAS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CDEVOLU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CFLETES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CDSCTOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CPROMO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CCOSVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CCOMPRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CCONSUM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CVENTAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CEXPORT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CCOMTRA)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CVARTRA)
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CGASCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FT0003CTAE>()
                .Property(e => e.TC_CCTAPEP)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
