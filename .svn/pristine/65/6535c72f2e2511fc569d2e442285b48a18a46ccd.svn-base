namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20tabla_oer : DbContext
    {
        public Model20tabla_oer()
            : base("name=tabla_oer")
        {
        }
       public virtual DbSet<tabla_oer> tabla_oer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.ORDEN_NUMERO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.COD_SOLICITANTE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.SOLICITANTE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.COD_BANCO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.BANCO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.NUMERO_CUENTA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.MOTIVO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.APROB1)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.APROB2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.APROB3)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.MONEDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_oer>()
                .Property(e => e.USUMOD)
                .IsUnicode(false);
        }
    }
}
