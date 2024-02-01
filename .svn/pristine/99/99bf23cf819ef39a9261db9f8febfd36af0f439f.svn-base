namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model18 : DbContext
    {
        public Model18()
            : base("name=Model181")
        {
        }

        public virtual DbSet<tabla_tipo_despacho> tabla_tipo_despacho { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_tipo_despacho>()
                .Property(e => e.TD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_tipo_despacho>()
                .Property(e => e.TD_DESC)
                .IsUnicode(false);
        }
    }
}
