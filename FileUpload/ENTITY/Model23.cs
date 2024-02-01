namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model23 : DbContext
    {
        public Model23()
            : base("name=Model231")
        {
        }

        public virtual DbSet<tabla_parametros> tabla_parametros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_COD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_CCLAVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_TDESCRI1)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_TDESCRI2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_TDESCRI3)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_parametros>()
                .Property(e => e.AF_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
