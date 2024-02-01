namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model37 : DbContext
    {
        public Model37()
            : base("name=Model37")
        {
        }

        public virtual DbSet<TABLCONSUCTA> TABLCONSUCTA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_CCUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_NCANTID)
                .HasPrecision(38, 3);

            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_NUSIMPO)
                .HasPrecision(38, 2);

            modelBuilder.Entity<TABLCONSUCTA>()
                .Property(e => e.C6_NMNIMPO)
                .HasPrecision(38, 2);
        }
    }
}
