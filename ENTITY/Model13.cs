namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model13 : DbContext
    {
        public Model13()
            : base("name=Model131")
        {
        }

        public virtual DbSet<tabla_services> tabla_services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_services>()
                .Property(e => e.codtra)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_services>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_services>()
                .Property(e => e.dni)
                .IsUnicode(false);
        }
    }
}
