namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model11 : DbContext
    {
        public Model11()
            : base("name=Model114")
        {
        }

        public virtual DbSet<T_Presentacion> T_Presentacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.despr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.idgrupo)
                .IsUnicode(false);
        }
    }
}
