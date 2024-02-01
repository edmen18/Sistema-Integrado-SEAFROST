namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20TABLA_CAJAS : DbContext
    {
        public Model20TABLA_CAJAS()
            : base("name=tabla_cajas")
        {
        }

        public virtual DbSet<tabla_cajas> tabla_cajas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_cajas>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_cajas>()
                .Property(e => e.PROPIETARIO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_cajas>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
