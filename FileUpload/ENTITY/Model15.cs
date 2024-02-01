namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model15 : DbContext
    {
        public Model15()
            : base("name=Model151")
        {
        }

        public virtual DbSet<tabla_plan_ord> tabla_plan_ord { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
