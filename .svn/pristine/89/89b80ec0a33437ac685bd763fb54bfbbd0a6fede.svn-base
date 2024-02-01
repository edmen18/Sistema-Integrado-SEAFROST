namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model209 : DbContext
    {
        public Model209()
            : base("name=tabla_tipo_doc")
        {
        }

        public virtual DbSet<tabla_tipo_doc> tabla_tipo_doc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_tipo_doc>()
                .Property(e => e.TD_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
