namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model40 : DbContext
    {
        public Model40()
            : base("name=Model403")
        {
        }

        public virtual DbSet<tabla_d_ususol> tabla_d_ususol { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_d_ususol>()
                .Property(e => e.SU_USUA)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_d_ususol>()
                .Property(e => e.SU_SOLIC)
                .IsUnicode(false);
        }
    }
}
