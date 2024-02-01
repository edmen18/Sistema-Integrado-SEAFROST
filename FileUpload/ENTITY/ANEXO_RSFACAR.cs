namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ANEXO_RSFACAR : DbContext
    {
        public ANEXO_RSFACAR()
            : base("name=ANEXO_RSFACAR")
        {
        }



        public virtual DbSet<tabla_stockminimo> tabla_stockminimo { get; set; }
        public virtual DbSet<tabla_area> tabla_area { get; set; }
        public virtual DbSet<tabla_usuarios> tabla_usuarios { get; set; }
        public virtual DbSet<tabla_periodo> tabla_periodo { get; set; }
        public virtual DbSet<tabla_mes> tabla_mes { get; set; }
        public virtual DbSet<tabla_menuusuarios> tabla_menuusuarios { get; set; }
        //nuevo07032016
        public virtual DbSet<tabla_subtipoOC> tabla_subtipoOC { get; set; }
        public virtual DbSet<tabla_plan_ord> tabla_plan_ord { get; set; }
        public virtual DbSet<tabla_tipo_despacho> tabla_tipo_despacho { get; set; }
        //JIMMY 14-03-2016
        public virtual DbSet<tabla_busquedaRequerimiento> tabla_busquedaRequerimiento { get; set; }

        //edgar
        public virtual DbSet<DETALLE_LIQUIDACION> DETALLE_LIQUIDACION { get; set; }
        public virtual DbSet<TABLA_LIQUIDACION_ANTICIPO> TABLA_LIQUIDACION_ANTICIPO { get; set; }
        public virtual DbSet<tabla_anticipo> tabla_anticipo { get; set; }

        
        //nuevo sergio 17032016
        public virtual DbSet<OT_CO0003MOVC> OT_CO0003MOVC { get; set; }
        public virtual DbSet<OT_CO0003MOVD> OT_CO0003MOVD { get; set; }
        public virtual DbSet<tabla_parametrosbusq> tabla_parametrosbusq { get; set; }
        //nuevo william 28032016
        public virtual DbSet<tabla_bahias> tabla_bahias { get; set; }
        public virtual DbSet<tabla_parametros> tabla_parametros { get; set; }
        public virtual DbSet<tabla_embarcaciones> tabla_embarcaciones { get; set; }

        //nuevo sergio 15042016

        public virtual DbSet<tabla_subareas> tabla_subareas { get; set; }
        public virtual DbSet<tabla_d_areausua> tabla_d_areausua { get; set; }
        public virtual DbSet<tabla_niveledicion> tabla_niveledicion { get; set; }
        public virtual DbSet<tabla_d_nivelusua> tabla_d_nivelusua { get; set; }
        public virtual DbSet<tabla_servicios> tabla_servicios { get; set; }
        public virtual DbSet<tabla_d_usuaprod> tabla_d_usuaprod { get; set; }
        public virtual DbSet<tabla_d_usuaprodedicion> tabla_d_usuaprodedicion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_stockminimo>()
              .Property(e => e.codigo)
              .IsUnicode(false);

            modelBuilder.Entity<tabla_stockminimo>()
                .Property(e => e.stock_minimo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tabla_stockminimo>()
                .Property(e => e.eoq)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tabla_usuarios>()
               .Property(e => e.TU_ALIAS)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<tabla_usuarios>()
                .Property(e => e.TU_NOMUSU)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_usuarios>()
                .Property(e => e.TU_PASSWO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_periodo>()
                .Property(e => e.cod)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_periodo>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_mes>()
              .Property(e => e.cod)
              .IsUnicode(false);

            modelBuilder.Entity<tabla_mes>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            //NUEVO
            modelBuilder.Entity<tabla_menuusuarios>()
            .Property(e => e.USUA)
            .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.NOMMENU)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.NOMITEM)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.orden)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.VEROCULTA)
                .HasPrecision(18, 0);

            //nuevo 07032016
            modelBuilder.Entity<tabla_subtipoOC>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
            //planilla orden
            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_NORD)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_CODIG)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_PLANI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_CANT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_TARIF)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_TOTA)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tabla_plan_ord>()
                .Property(e => e.BK_CODPLAN)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_plan_ord>()
           .Property(e => e.BK_CITEM)
           .IsUnicode(false);
            //tipo despacho
            modelBuilder.Entity<tabla_tipo_despacho>()
               .Property(e => e.TD_ID)
               .IsUnicode(false);

            modelBuilder.Entity<tabla_tipo_despacho>()
                .Property(e => e.TD_DESC)
                .IsUnicode(false);

            //JIMMY 14-03-2016
            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                 .Property(e => e.RC_CNROREQ)
                 .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.RC_DFECREQ)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.TG_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.RD_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.RD_NQPEDI)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.CCOSTO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.RC_CCODSOLI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.RD_CCODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.RD_CCENCOS)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_busquedaRequerimiento>()
                .Property(e => e.IP)
                .IsUnicode(false);

            //edagra 15032016
            modelBuilder.Entity<DETALLE_LIQUIDACION>()
                   .Property(e => e.FACTURA)
                   .IsUnicode(false);

            modelBuilder.Entity<DETALLE_LIQUIDACION>()
                .Property(e => e.LIQ_NUMERO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABLA_LIQUIDACION_ANTICIPO>()
               .Property(e => e.LIQ_NUMERO)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<TABLA_LIQUIDACION_ANTICIPO>()
                .Property(e => e.ANT_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABLA_LIQUIDACION_ANTICIPO>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                 .Property(e => e.ANT_CODIGO)
                 .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.OC_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.OC_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.OC_CRAZSOC)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.OC_CODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.MOTIVO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.OC_CTAPROVEEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.OC_BANCO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.BANCO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.MONEDA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_anticipo>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_area>()
                .Property(e => e.AE_DESC)
                .IsUnicode(false);

            //nuevo sergio 16032016
            modelBuilder.Entity<tabla_area>()
                .Property(e => e.AE_DESC)
                .IsUnicode(false);

            //nuevo sergio 17032016
            modelBuilder.Entity<OT_CO0003MOVC>()
                         .Property(e => e.OC_CNUMORD)
                         .IsFixedLength()
                         .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRAZSOC)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CDIRPRO)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCOTIZA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CFORPA1)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CFORPA2)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CFORPA3)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NTIPCAM)
                .HasPrecision(8, 4);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NPORDES)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCARDES)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPUS)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPMN)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CSOLICT)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CTIPENV)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CLUGENT)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CLUGFAC)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CDETENT)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CSITORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CUSUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CTIPORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRESPER1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRESPER2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRESPER3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRESCARG1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRESCARG2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CRESCARG3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCOPAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CUSEA01)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CUSEA02)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CUSEA03)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CREMITE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CPERATE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCONTA1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCONTA2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCONTA3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CNUMFAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CUNIORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCONVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCONEMB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCONDIC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CTIPENT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CDIAENT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NFLEINT)
                .HasPrecision(10, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NDOCCHA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NFLETE)
                .HasPrecision(10, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NSEGURO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPFAC)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPFOB)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPCF)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPCIF)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CNUMREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CTIPDSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CALMDES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CDISTOC)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CPROVOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCOSTOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CDOCPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CESTPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CMONPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_NIMPPAG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CGLOPAG)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCODSOL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CCODTAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVC>()
                .Property(e => e.OC_CORDTRA)
                .IsFixedLength()
                .IsUnicode(false);

            //detalle ot
            modelBuilder.Entity<OT_CO0003MOVD>()
               .Property(e => e.OC_CNUMORD)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CCODREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CDESREF)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CUNIPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CDEUNPR)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CUNIDAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCANORD)
                .HasPrecision(13, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NPREUNI)
                .HasPrecision(18, 9);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NPREUN2)
                .HasPrecision(18, 9);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDSCPFI)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDESCFI)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDSCPIT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDESCIT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDSCPAD)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDESCAD)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDSCPOR)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NDESCTO)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NIGV)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NIGVPOR)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NISC)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NISCPOR)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCANTEN)
                .HasPrecision(13, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCANSAL)
                .HasPrecision(13, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NTOTUS)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NTOTMN)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_COMENTA)
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_FUNICOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCANREF)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NANCHO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCORTE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CTIPORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CNUMREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CSOLICI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CITEREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CREFCOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CPEDINT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CITEINT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CREFCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CNOMFAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCANEMB)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CITMPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CDSCPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CIGVPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_CISCPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NTOTMO)
                .HasPrecision(12, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NUNXENV)
                .HasPrecision(8, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NNUMENV)
                .HasPrecision(7, 3);

            modelBuilder.Entity<OT_CO0003MOVD>()
                .Property(e => e.OC_NCANFAC)
                .HasPrecision(13, 3);

			 /*BAHIAS*/
            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_NOMBRES)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_APELLIDOS)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_TEL_CONTACTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_CEL_CONTACTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_GLOSA1)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_GLOSA2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_USUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_USUMOD)
                .IsFixedLength()
                .IsUnicode(false);
            //21/03/2016
            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_COD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_CCLAVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_TDESCRI1)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_TDESCRI2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_TDESCRI3)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
            //22/03/2016
            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_MATRIC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_RESOLU)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_PERPES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_PERZAR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_ESPCHD)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_CABOM3)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_CABOTM)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_USUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_USUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            //nuevo sergio 15042016
            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CDESCR2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODIG2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CUNIDAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECI1)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECI2)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECI3)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECI4)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECI5)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECI6)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMONVTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NIGVPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NISCPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCONTRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CTIPDES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NDESCTO)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NDESCT2)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPDIS)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPCOM)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CGRUPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFAMILI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMODELO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CLINEA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPESO)
                .HasPrecision(15, 8);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NVOLUME)
                .HasPrecision(9, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NAREA)
                .HasPrecision(9, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NFACTOR)
                .HasPrecision(9, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NANCHO)
                .HasPrecision(9, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NLARGO)
                .HasPrecision(9, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMONCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECOS)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMONCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPRECOM)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMONFOB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPREFOB)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NMARGE1)
                .HasPrecision(7, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NMARGE2)
                .HasPrecision(7, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCLAART)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CPARARA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CINFTEC)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCATALO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCATEGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CTIPOI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_TOBSERV)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CUNIREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NFACREF)
                .HasPrecision(9, 3);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFUNIRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFDECI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFPRELI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFRESTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFLOTE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFROTAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CUSUCRE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CUSUMOD)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODANT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NDETRA)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMEDIDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CANNO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CGROSOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NIMAGEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFECABC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NLONSER)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFCELU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NLONCEL)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMEDNEU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CINDCAR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CDISENO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPERC1)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NPERC2)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CMARCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CANOFAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CLUGORI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFVEHI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CAYUVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCOLOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CTALLA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CTIPEXI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NMARVTA)
                .HasPrecision(3, 0);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CHORSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NIGVCPR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCUENTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFLGRCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_NTASRCN)
                .HasPrecision(6, 2);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CFORSER)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODAG1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODAG2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODAG3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODAG4)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_CCODAG5)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_servicios>()
                .Property(e => e.AR_PERTOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_subareas>()
               .Property(e => e.SA_DESC)
               .IsUnicode(false);



            //nuevo tabla detalla usuario area
            modelBuilder.Entity<tabla_d_areausua>()
             .Property(e => e.UA_USUA)
             .IsUnicode(false);

            modelBuilder.Entity<tabla_d_areausua>()
             .Property(e => e.UA_CORREO)
             .IsUnicode(false);

            //tabla nivel
            modelBuilder.Entity<tabla_niveledicion>()
               .Property(e => e.NA_NIVEL)
               .IsUnicode(false);

            //tabla detalle nivel usuario
            modelBuilder.Entity<tabla_d_nivelusua>()
              .Property(e => e.NU_USUA)
              .IsUnicode(false);

            //nuevo detalle de aprobacion
            modelBuilder.Entity<tabla_d_usuaprod>()
          .Property(e => e.DA_IDUSUA)
          .IsFixedLength()
          .IsUnicode(false);

            modelBuilder.Entity<tabla_d_usuaprod>()
                .Property(e => e.DA_CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_d_usuaprod>()
                .Property(e => e.DA_HORA)
                .IsUnicode(false);

            //edicion de tarifas
            modelBuilder.Entity<tabla_d_usuaprodedicion>()
               .Property(e => e.DA_IDUSUA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<tabla_d_usuaprodedicion>()
                .Property(e => e.DA_CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_d_usuaprodedicion>()
                .Property(e => e.DA_HORA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_d_usuaprodedicion>()
                .Property(e => e.DA_PRECIO)
                .HasPrecision(18, 4);


        }
    }
}
