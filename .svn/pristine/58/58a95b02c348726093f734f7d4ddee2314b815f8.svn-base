namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2023 : DbContext
    {
        public Model2023()
            : base("name=tabla_planta")
        {
        }

        public virtual DbSet<tabla_planta> T_PLANTA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_planta>()
                .Property(e => e.PL_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_planta>()
                .Property(e => e.PL_DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_planta>()
                .Property(e => e.PL_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
