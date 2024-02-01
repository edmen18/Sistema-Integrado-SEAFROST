namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model74 : DbContext
    {
        public Model74()
            : base("name=Model74")
        {
        }

        public virtual DbSet<tabla_ccalidad> tabla_ccalidad { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_IDORDEN)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_IDCERTIF)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_DESCERTIF)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_IDDEST)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_DESDEST)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_IDPROD)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_DESPROD)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_IDSOLI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_DESSOLI)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_PRODMUE)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_ccalidad>()
                .Property(e => e.CA_AADIC)
                .IsUnicode(false);
        }
    }
}
