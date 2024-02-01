namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20 : DbContext
    {
        public Model20()
            : base("name=Model20")
        {
        }

        public virtual DbSet<tabla_bahias> tabla_bahias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_NOMBRES)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_APELLIDOS)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_TEL_CONTACTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_CEL_CONTACTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_GLOSA1)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_GLOSA2)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_USUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_bahias>()
                .Property(e => e.B_USUMOD)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
