namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model10 : DbContext
    {
        public Model10()
            : base("name=Model10")
        {
        }

        public virtual DbSet<T_Producto> T_Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
