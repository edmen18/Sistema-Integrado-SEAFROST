namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model12 : DbContext
    {
        public Model12()
            : base("name=Model121")
        {
        }

        public virtual DbSet<T_Tarea> T_Tarea { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Tarea>()
                .Property(e => e.codt)
                .IsUnicode(false);

            modelBuilder.Entity<T_Tarea>()
                .Property(e => e.codcon)
                .IsUnicode(false);

            modelBuilder.Entity<T_Tarea>()
                .Property(e => e.codconhor)
                .IsUnicode(false);
        }
    }
}
