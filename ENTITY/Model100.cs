namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model100 : DbContext
    {
        public Model100()
            : base("name=tabla_modpresupuesto")
        {
        }

        public virtual DbSet<tabla_modpresupuesto> tabla_modpresupuesto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_modpresupuesto>()
                .Property(e => e.USU_APRO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_modpresupuesto>()
                .Property(e => e.TR_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
