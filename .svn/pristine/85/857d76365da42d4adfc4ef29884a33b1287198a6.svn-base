namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model33 : DbContext
    {
        public Model33()
            : base("name=tabla_porcentaje")
        {
        }

        public virtual DbSet<tabla_porcentaje> tabla_porcentaje { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_porcentaje>()
                .Property(e => e.PORC_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_porcentaje>()
                .Property(e => e.PORC_USU)
                .IsUnicode(false);
        }
    }
}
