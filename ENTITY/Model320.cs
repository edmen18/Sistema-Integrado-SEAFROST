namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model320 : DbContext
    {
        public Model320()
            : base("name=Model320")
        {
        }

        public virtual DbSet<VISTA_KARDEVAL> VISTA_KARDEVAL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CCODMOV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CRFNDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CCODPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_NMNPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_NUSPRUN)
                .HasPrecision(18, 9);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_NCANTID)
                .HasPrecision(11, 3);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_NMNIMPO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_NUSIMPO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<VISTA_KARDEVAL>()
                .Property(e => e.C6_CGLOSA)
                .IsUnicode(false);
        }
    }
}
