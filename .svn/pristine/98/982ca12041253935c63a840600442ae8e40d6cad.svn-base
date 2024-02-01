namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model25 : DbContext
    {
        public Model25()
            : base("name=Model25")
        {
        }

        public virtual DbSet<tabla_embarcaciones> tabla_embarcaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_MATRIC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_RESOLU)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_PERPES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_PERZAR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_ESPCHD)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_CABOM3)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_CABOTM)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_USUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_USUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_embarcaciones>()
                .Property(e => e.E_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
