namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2024 : DbContext
    {
        public Model2024()
            : base("name=tabla_equipo")
        {
        }

        public virtual DbSet<tabla_equipo> T_EQUIPO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_equipo>()
                .Property(e => e.EQ_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_equipo>()
                .Property(e => e.EQ_DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_equipo>()
                .Property(e => e.EQ_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
