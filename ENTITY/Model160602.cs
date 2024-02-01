namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model160602 : DbContext
    {
        public Model160602()
            : base("name=CP0003COPR")
        {
        }

        public virtual DbSet<CP0003COPR> CP0003COPR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
