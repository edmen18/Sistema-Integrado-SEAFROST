namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model160603 : DbContext
    {
        public Model160603()
            : base("name=CP0003TABL")
        {
        }

        public virtual DbSet<CP0003TABL> CP0003TABL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
