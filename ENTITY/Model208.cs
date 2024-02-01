namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model208 : DbContext
    {
        public Model208()
            : base("name=tabla_detalle")
        {
        }

        public virtual DbSet<tabla_detalle> tabla_detalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_detalle>()
                .Property(e => e.TR_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_detalle>()
                .Property(e => e.NUM_DOC)
                .IsUnicode(false);
        }
    }
}
