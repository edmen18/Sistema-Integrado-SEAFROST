namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model8 : DbContext
    {
        public Model8()
            : base("name=Model8")
        {
        }

        public virtual DbSet<T_TarGral> T_TarGral { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codp)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codt)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.und)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.tar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codsofcom)
                .IsUnicode(false);
        }
    }
}
