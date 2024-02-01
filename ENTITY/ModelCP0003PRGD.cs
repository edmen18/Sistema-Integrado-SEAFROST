namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCP0003PRGD : DbContext
    {
        public ModelCP0003PRGD()
            : base("name=ModelCP0003PRGD")
        {
        }

        public virtual DbSet<CP0003PRGD> CP0003PRGD { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
