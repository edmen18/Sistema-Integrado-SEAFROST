namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model54 : DbContext
    {
        public Model54()
            : base("name=Model54")
        {
        }

        public virtual DbSet<tabla_ordenped> tabla_ordenped { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_ordenped>()
                .Property(e => e.IDPEDIDO)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ordenped>()
                .Property(e => e.IDORDEN)
                .IsUnicode(false);
        }
    }
}
