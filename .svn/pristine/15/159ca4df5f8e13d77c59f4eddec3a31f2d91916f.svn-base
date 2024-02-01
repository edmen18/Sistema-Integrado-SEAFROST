namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20tt : DbContext
    {
        public Model20tt()
            : base("name=Model20tt")
        {
        }

        public virtual DbSet<tabla_trabajo_tipo> tabla_trabajo_tipo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_trabajo_tipo>()
                .Property(e => e.COD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_trabajo_tipo>()
                .Property(e => e.TIPO)
                .IsUnicode(false);
        }
    }
}
