namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2045 : DbContext
    {
        public Model2045()
            : base("name=tabla_avances")
        {
        }

        public virtual DbSet<tabla_avances> tabla_avances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_avances>()
                .Property(e => e.TR_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
