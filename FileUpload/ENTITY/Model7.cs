namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model7 : DbContext
    {
        public Model7()
            : base("name=Model7")
        {
        }

        public virtual DbSet<tabla_subtipoOC> tabla_subtipoOC { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_subtipoOC>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }
    }
}
