namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RSCONCAR : DbContext
    {
        public RSCONCAR()
            : base("name=RSCONCAR")
        {
        }
        public virtual DbSet<CP0003PRGD> CP0003PRGD { get; set; }
        public virtual DbSet<CP0003EJEC> CP0003EJEC { get; set; }
        public virtual DbSet<CT0003ANEX> CT0003ANEX { get; set; }
        public virtual DbSet<CP0003TAGE> CP0003TAGE { get; set; }
        public virtual DbSet<CTCAMB> CTCAMB { get; set; }
        public virtual DbSet<CP0003MAEC> CP0003MAEC { get; set; }
        public virtual DbSet<CT0003AGEN> CT0003AGEN { get; set; }
        public virtual DbSet<CT0003TAGE> CT0003TAGE { get; set; }
        //nuevo edgar
      
        public virtual DbSet<CT0003TABL> CT0003TABL { get; set; }
        public virtual DbSet<CP0003LOG1> CP0003LOG1 { get; set; }
        public virtual DbSet<CT0003CTL416> CT0003CTL416 { get; set; }
        public virtual DbSet<CP0003CHEQ> CP0003CHEQ { get; set; }
        public virtual DbSet<CP0003LOG2> CP0003LOG2 { get; set; }
        public virtual DbSet<CP0003EJED> CP0003EJED { get; set; }
        public virtual DbSet<CP0003TABL> CP0003TABL { get; set; }
        public virtual DbSet<CP0003PRGC> CP0003PRGC { get; set; }
        public virtual DbSet<CP0003CUBA> CP0003CUBA { get; set; }
        public virtual DbSet<CP0003PAGO> CP0003PAGO { get; set; }
        public virtual DbSet<CP0003COPR> CP0003COPR { get; set; }
        //NUEVO WILLIAM-02/04/2016
        public virtual DbSet<CT0003COMC16> CT0003COMC16 { get; set; }
        public virtual DbSet<CT0003COMD16> CT0003COMD16 { get; set; }
        //NUEVO WILLIAM 02.04.2016
        public virtual DbSet<CP0003CAGE> CP0003CAGE { get; set; }
        //NUEVO WILLIAM 13/04/2016
        public virtual DbSet<CP0003CART> CP0003CART { get; set; }
        //NUEVO WILLIAM 05.04.2016
        public virtual DbSet<CT0003PLEM> CT0003PLEM { get; set; }
        //NUEVO WILLIAM 20.04.2016
        public virtual DbSet<CP0003MAES> CP0003MAES { get; set; }
        //NUEVO WILLIAM 02/04/2016
        public virtual DbSet<CT0003NUME16> CT0003NUME16 { get; set; }
        //NUEVO WILLIAM 14/04/2016
        public virtual DbSet<CT0003BALH16> CT0003BALH16 { get; set; }
        public virtual DbSet<CT0003CTL316> CT0003CTL316 { get; set; }
        public virtual DbSet<CT0003COST16> CT0003COST16 { get; set; }
        public virtual DbSet<CP0003PAGP> CP0003PAGP { get; set; }
        public virtual DbSet<CP0003SUBP> CP0003SUBP { get; set; }
        public virtual DbSet<CP0003VARI> CP0003VARI { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT0003TABL>()
               .Property(e => e.TCOD)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.TCLAVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.TDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.THORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
               .Property(e => e.CSUBDIA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CSITUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CTIPCAM)
                .HasPrecision(10, 4);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CTOTAL)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CFLAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CFECCAM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CORIG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CFORM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CTIPCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CDPTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CEXTOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CTIPTRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CCOMEN)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CCOMEN2)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CHORA2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG1>()
                .Property(e => e.CUSER2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
               .Property(e => e.LG_CSUBDIA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_CSECUEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_DIMPORT)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_CUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL416>()
                .Property(e => e.LG_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNUMCTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNUMCHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CFECCHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNOMCHE)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNUMCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_NIMPOCH)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CFECEST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CUSUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CCTACON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CSITUAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_DOCREFT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_DOCREFN)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CCOGAST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CCONCEP)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CFECDIF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_NTIPCAM)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNOMCH2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNOMFR1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CNOMFR2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CHEQ>()
                .Property(e => e.CH_CFLGNEG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
               .Property(e => e.L2_CCODAGE)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CNUMOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CTIPTRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CORIGEN)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CNUMOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CSECUE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CMONCAR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NORPROG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NUSPROG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NMNPROG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CTIPCTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CTIPPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CNUMCTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NMNRETE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NUSRETE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NORRETE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CRETE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NPORRE)
                .HasPrecision(7, 3);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CTASDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CSUBCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CNUMCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CSECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CTDREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CNDREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_NTCORI)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CP0003EJED>()
                .Property(e => e.GD_CNOCONS)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CNUMOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CSECUE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CMONCAR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NORPROG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NUSPROG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NMNPROG)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CTIPCTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CTIPPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CNUMCTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NMNRETE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NUSRETE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NORRETE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CRETE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NPORRE)
                .HasPrecision(7, 3);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CTASDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CSUBCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CNUMCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CSECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CTDREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_CNDREF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGD>()
                .Property(e => e.GD_NTCORI)
                .HasPrecision(11, 4);
            modelBuilder.Entity<CP0003EJEC>()
               .Property(e => e.GC_CCODAGE)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CNUMOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CCODCON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CTIPPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CCODBAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CCODDEP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CNUMLOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CTASDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_NMONPRO)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CUSUAPR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CCHQCOR)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CVOUCOR)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CUSUEJE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003EJEC>()
                .Property(e => e.GC_CNOPEDE)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_INDICE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_DESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_NUMERO)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_FECCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_FECACT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TABL>()
                .Property(e => e.TG_USUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CCODCON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CCONCEP)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CFLGMAS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CTIPPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CTIPFLA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CTIPANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CANEINI)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CANEFIN)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003COPR>()
                .Property(e => e.CG_CACRBAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
              .Property(e => e.GC_CCODAGE)
              .IsFixedLength()
              .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CNUMOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CCODCON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CTIPPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CCODBAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CCODDEP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CNUMLOT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CTASDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_NMONPRO)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PRGC>()
                .Property(e => e.GC_CUSUAPR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ACODANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ADESANE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AREFANE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ARUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ACODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.APATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AMATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AFORMSUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATELEFO)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATIPTRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.APROVIN)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ADEPART)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.APAIS)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AZONPOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANOMREP)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ACARREP)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AHOST)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ADOCIDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANUMIDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATIPPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATASDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATASPER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ASTTPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AOBSPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AENTFIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ASEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANACIO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AESSAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ADOMIC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATIPVIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANVVIA)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANUMER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AINTER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATZONA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ANZONA)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AREFER)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AUBIGU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ASITUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATICONV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.AVRETE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.APORRE)
                .HasPrecision(7, 3);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ACODAFP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ATIPCOMAFP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003ANEX>()
                .Property(e => e.ACUSPP)
                .IsFixedLength()
                .IsUnicode(false);


            //NUEVO TABLA GENERAL

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_INDICE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_DESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_NUMERO)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_FECCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_FECACT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003TAGE>()
                .Property(e => e.TG_USUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
               .Property(e => e.CE_CCODAGE)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CTIPACR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CCTACOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CCTALET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CCTAANT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CAGE>()
                .Property(e => e.CE_CCTALIQ)
                .IsFixedLength()
                .IsUnicode(false);

            /*NUEVO WILLIAM:31/03/2016*/
            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CORDKEY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CDEBHAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_NIMPOMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_NIMPOUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CNUMCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CCOGAST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CORIGEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CUSUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            /*NUEVO WILLIAM 13/04/2016*/
            modelBuilder.Entity<CP0003CART>()
               .Property(e => e.CP_CVANEXO)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECREC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CSITUAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CDEBHAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIMPOMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIMPOUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NSALDMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NSALDUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIGVMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIGVUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIMP2MN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIMP2US)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NIMPAJU)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CAREA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECUBI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CTDOCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CNDOCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFDOCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CTDOCCO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CNDOCCO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFDOCCO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFORMPG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCOGAST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NINAFEC)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CTIPSUN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CIMAGEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CVANERF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCODIRF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CFECCAM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CTASDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CSECDET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CCENCOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_CRETE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003CART>()
                .Property(e => e.CP_NPORRE)
                .HasPrecision(7, 3);

            /*WILLIAM-02/04/2016*/
            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CSITUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CTIPCAM)
                .HasPrecision(11, 6);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CTOTAL)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CFLAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CFECCAM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CORIG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CFORM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CTIPCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CEXTOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CMEMO)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CSERCER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMC16>()
                .Property(e => e.CNUMCER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DSECUE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCODANE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DDH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DIMPORT)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DNUMDOC)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DFECDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DFECVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DAREA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DFLAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DXGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DUSIMPOR)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DMNIMPOR)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCODARC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCODANE2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DVANEXO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCANTID)
                .HasPrecision(13, 3);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCTAORI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCIMPORT)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCNUMDOC)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCCONNRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCNUMEST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCIMPORTB)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCANO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTIPDOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DNUMDOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTIPTAS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DIMPTAS)
                .HasPrecision(6, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DIMPBMN)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DIMPBUS)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DMONCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DCOLCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DBASCOM)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DINACOM)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DIGVCOM)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTPCONV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DFLGCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DANECOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTIPACO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DMEDPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DTIPDO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DNUMDO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DRETE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COMD16>()
                .Property(e => e.DPORRE)
                .HasPrecision(7, 3);

            //NUEVO WILLIAM 02/04/2016
            modelBuilder.Entity<CT0003NUME16>()
               .Property(e => e.CTSUBDIA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CT0003NUME16>()
                .Property(e => e.CTANO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003NUME16>()
                .Property(e => e.CTMES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003NUME16>()
                .Property(e => e.CTNUMER)
                .HasPrecision(4, 0);

            /*NUEVO WILLIAM*/
            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BMNSALA)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BMNDEBE)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BMNHABER)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BMNSALN)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BUSSALA)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BUSDEBE)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BUSHABER)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BUSSALN)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BMNSALI)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BUSSALI)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BFECPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BFORBAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BFORGYP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BFORRE1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BCTAAJU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003BALH16>()
                .Property(e => e.BFECPRO2)
                .IsFixedLength()
                .IsUnicode(false);

            // tipo de cambio 
            modelBuilder.Entity<CTCAMB>()
                .Property(e => e.XCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTCAMB>()
                .Property(e => e.XFECCAM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTCAMB>()
                .Property(e => e.XMEIMP)
                .HasPrecision(14, 6);

            modelBuilder.Entity<CTCAMB>()
                .Property(e => e.XMNIMP)
                .HasPrecision(14, 7);

            modelBuilder.Entity<CTCAMB>()
                .Property(e => e.XMEIMP2)
                .HasPrecision(14, 6);

            modelBuilder.Entity<CTCAMB>()
                .Property(e => e.XMNIMP2)
                .HasPrecision(14, 7);

            //contacto 
            modelBuilder.Entity<CP0003MAEC>()
               .Property(e => e.CP_CVANEXO)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CUBIC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CDIRECC)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CTELEFO)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CNUMFAX)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CCARGO)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CDEPCON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CHORARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CCODPOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CPAIS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CDEPART)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CPROVIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CDISDES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CBENIF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003MAEC>()
                .Property(e => e.CP_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);
            /*NUEVO WILLIAM*/
            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CNOMAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CDIRAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CCONAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CTELAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CCORAGE)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_NULTOPE)
                .HasPrecision(11, 0);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003AGEN>()
                .Property(e => e.AG_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            /*NUEVO WILLIAM*/
            modelBuilder.Entity<CT0003TAGE>()
                    .Property(e => e.TCOD)
                    .IsFixedLength()
                    .IsUnicode(false);

            modelBuilder.Entity<CT0003TAGE>()
                .Property(e => e.TCLAVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TAGE>()
                .Property(e => e.TDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TAGE>()
                .Property(e => e.THORA)
                .IsFixedLength()
                .IsUnicode(false);

            /*NUEVO WILLIAM:31/03/2016*/
            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CTIPDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CORDKEY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CDEBHAB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_NIMPOMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_NIMPOUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CNUMCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CCOGAST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CORIGEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CUSUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGO>()
                .Property(e => e.PG_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            /*BLOQUEO MENSUAL CONCAR*/
            modelBuilder.Entity<CT0003CTL316>()
               .Property(e => e.TMES)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL316>()
                .Property(e => e.TLHORA)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL316>()
                .Property(e => e.TUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003CTL316>()
                .Property(e => e.TTIPCONS)
                .IsFixedLength()
                .IsUnicode(false);
            
            /*SERVICIOS*/
            modelBuilder.Entity<CT0003COST16>()
               .Property(e => e.CT_CUENTA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_CENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_USDEBE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_USHABER)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_MNDEBE)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_MNHABER)
                .HasPrecision(14, 2);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_FORCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_FECPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003COST16>()
                .Property(e => e.CT_FECPRO2)
                .IsFixedLength()
                .IsUnicode(false);

            /*CONTROL PAGOS X PROGRAMA*/
            modelBuilder.Entity<CP0003PAGP>()
               .Property(e => e.CP_CPROGRA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGP>()
                .Property(e => e.CP_CMEDPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGP>()
                .Property(e => e.CP_CMODULO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003PAGP>()
                .Property(e => e.CP_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            /*VALIDACION SUBDIARIOS POR PROGRAMA*/
            modelBuilder.Entity<CP0003SUBP>()
                .Property(e => e.CP_CPROGRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003SUBP>()
                .Property(e => e.CP_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003SUBP>()
                .Property(e => e.CP_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            /*VARI*/
            modelBuilder.Entity<CP0003VARI>()
               .Property(e => e.CH_CNUMCTA)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CNUMCHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CFECCHE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CNOMCHE)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CFECCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CNUMCOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_NIMPOCH)
                .HasPrecision(13, 2);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CFECEST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CUSUARI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CHORA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CCTACON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CSITUAC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_DOCREFT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_DOCREFN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CCOGAST)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CCONCEP)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CFECDIF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_NTIPCAM)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CCTACTE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CFORPAG)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CTIPPAG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CPAGTEL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003VARI>()
                .Property(e => e.CH_CNUMLIQ)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
