namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model34 : DbContext
    {
        public Model34()
            : base("name=tabla_permiso_presupuesto")
        {
        }

        public virtual DbSet<tabla_permiso_presupuesto> tabla_permiso_presupuesto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_permiso_presupuesto>()
                .Property(e => e.COD_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_permiso_presupuesto>()
                .Property(e => e.PERMISO_PRES)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
