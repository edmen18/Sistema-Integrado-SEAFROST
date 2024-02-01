namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SM : DbContext
    {
        public SM()
            : base("name=SM")
        {
        }

        public virtual DbSet<tabla_stockminimo> tabla_stockminimo { get; set; }

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
        }
    }
}
