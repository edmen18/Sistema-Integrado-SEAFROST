namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20tabla_detalle_oer : DbContext
    {
        public Model20tabla_detalle_oer()
            : base("name=tabla_detalle_oer")
        {
        }

        public virtual DbSet<tabla_detalle_oer> tabla_detalle_oer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.ORDEN_NUMERO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.CODIGO_PROVEEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.PROVEEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.RUC)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.TIPO_DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.NUM_DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.GLOSA_COMPROBANTE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.GLOSA_MOVIMIENTO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.CUENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.AREA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.ANEXO_REFERENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.CENCOS)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.ANEXO_REF2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle_oer>()
                .Property(e => e.MEDIOPAG)
                .IsUnicode(false);
        }
    }
}
