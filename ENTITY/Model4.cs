namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model4 : DbContext
    {
        public Model4()
            : base("name=Model43")
        {
        }

        public virtual DbSet<tabla_menuusuarios> tabla_menuusuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.USUA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.NOMMENU)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_menuusuarios>()
                .Property(e => e.NOMITEM)
                .IsUnicode(false);
        }
    }
}
