namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20cheque : DbContext
    {
        public Model20cheque()
            : base("name=CP0003CHEQ")
        {
        }

        public virtual DbSet<CP0003CHEQ> CP0003CHEQ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
