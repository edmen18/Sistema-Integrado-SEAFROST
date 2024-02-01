namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2026 : DbContext
    {
        public Model2026()
            : base("name=tabla_tipo_doc")
        {
        }

        public virtual DbSet<tabla_tipo_doc> TB_TIPO_DOC { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_tipo_doc>()
                .Property(e => e.TD_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
