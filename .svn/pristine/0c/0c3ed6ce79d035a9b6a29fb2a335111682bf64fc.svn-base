namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2016 : DbContext
    {
        public Model2016()
            : base("name=T_CALIDAD_TIPO_CERTIFICADO")
        {
        }

        public virtual DbSet<T_CALIDAD_TIPO_CERTIFICADO> T_CALIDAD_TIPO_CERTIFICADO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_CALIDAD_TIPO_CERTIFICADO>()
                .Property(e => e.TC_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
