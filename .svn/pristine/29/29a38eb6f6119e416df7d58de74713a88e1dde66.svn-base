namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2012 : DbContext
    {
        public Model2012()
            : base("name=T_CALIDAD_DESTINADO")
        {
        }

        public virtual DbSet<T_CALIDAD_DESTINO> T_CALIDAD_DESTINO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_CALIDAD_DESTINO>()
                .Property(e => e.DST_DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
