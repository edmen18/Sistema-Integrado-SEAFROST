namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2015 : DbContext
    {
        public Model2015()
            : base("name=T_CALIDAD_PRODUCTO")
        {
        }

        public virtual DbSet<T_CALIDAD_PRODUCTO> T_CALIDAD_PRODUCTO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_CALIDAD_PRODUCTO>()
                .Property(e => e.PR_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
