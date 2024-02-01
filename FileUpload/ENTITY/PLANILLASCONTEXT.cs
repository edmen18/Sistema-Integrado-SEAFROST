namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PLANILLASCONTEXT : DbContext
    {
        public PLANILLASCONTEXT()
            : base("name=PLANILLASCONTEXT")
        {
        }

        public virtual DbSet<T_CodigoGral> T_CodigoGral { get; set; }
        public virtual DbSet<T_Presentacion> T_Presentacion { get; set; }
        public virtual DbSet<T_Producto> T_Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_CodigoGral>()
                .Property(e => e.codp)
                .IsUnicode(false);

            modelBuilder.Entity<T_CodigoGral>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<T_CodigoGral>()
                .Property(e => e.codgral)
                .IsUnicode(false);

            modelBuilder.Entity<T_CodigoGral>()
                .Property(e => e.descodgral)
                .IsUnicode(false);

            modelBuilder.Entity<T_CodigoGral>()
                .Property(e => e.sw)
                .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.despr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.idgrupo)
                .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.codp)
                .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.desp)
                .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.sw)
                .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.idespecie)
                .IsUnicode(false);
        }

    }
}
