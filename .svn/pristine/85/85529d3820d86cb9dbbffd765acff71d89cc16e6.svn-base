namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2014 : DbContext
    {
        public Model2014()
            : base("name=T_CALIDAD_ENVASE")
        {
        }

        public virtual DbSet<T_CALIDAD_ENVASE> T_CALIDAD_ENVASE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_CALIDAD_ENVASE>()
                .Property(e => e.ENV_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
