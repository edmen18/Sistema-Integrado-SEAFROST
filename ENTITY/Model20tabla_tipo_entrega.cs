namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20tabla_tipo_entrega : DbContext
    {
        public Model20tabla_tipo_entrega()
            : base("name=tabla_tipo_entrega")
        {
        }

        public virtual DbSet<tabla_tipo_entrega> tabla_tipo_entrega { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_tipo_entrega>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_tipo_entrega>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
