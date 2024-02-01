namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2011 : DbContext
    {
        public Model2011()
            : base("name=Model2011")
        {
        }

        public virtual DbSet<T_CALIDAD_TIPO_ANALISIS> T_CALIDAD_TIPO_ANALISIS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_CALIDAD_TIPO_ANALISIS>()
                .Property(e => e.TA_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
