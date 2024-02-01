namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model21 : DbContext
    {
        public Model21()
            : base("name=tabla_trabajo")
        {
        }

        public virtual DbSet<tabla_trabajo> tabla_trabajo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.TR_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.EQ_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.PL_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.CONTRATISTA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.COD_CENCOS)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.CENTRO_COSTO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.CONTROL_ACTIVOS)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.COD_MON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.MONEDA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.USU1)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.USU2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo>()
                .Property(e => e.USU3)
                .IsUnicode(false);
        }
    }
}
