namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model30 : DbContext
    {
        public Model30()
            : base("name=Model301")
        {
        }

        public virtual DbSet<tabla_d_solicitud> tabla_d_solicitud { get; set; }
        public virtual DbSet<tabla_solicitud> tabla_solicitud { get; set; }
        public virtual DbSet<tabla_stockxsoli> tabla_stockxsoli { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_d_solicitud>()
                .Property(e => e.DS_CCODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_d_solicitud>()
                .Property(e => e.DS_SOLSALDO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_solicitud>()
                .Property(e => e.SM_IDSOLI)
                .IsFixedLength();

            modelBuilder.Entity<tabla_solicitud>()
                .Property(e => e.SM_GLOSA)
                .IsFixedLength();

            modelBuilder.Entity<tabla_solicitud>()
                .Property(e => e.SM_AREA)
                .IsFixedLength();

            modelBuilder.Entity<tabla_stockxsoli>()
                .Property(e => e.SS_CCODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_stockxsoli>()
                .Property(e => e.SS_ALMACEN)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_stockxsoli>()
                .Property(e => e.SS_SOLICITAN)
                .IsFixedLength();

            modelBuilder.Entity<tabla_stockxsoli>()
                .Property(e => e.SS_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_stockxsoli>()
                .Property(e => e.SS_SOLICORIGEN)
                .IsUnicode(false);
        }
    }
}
