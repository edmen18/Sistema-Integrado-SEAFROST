namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model111 : DbContext
    {
        public Model111()
            : base("name=tabla_detalle")
        {
        }

        public virtual DbSet<tabla_detalle> T_DETALLE { get; set; }

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
