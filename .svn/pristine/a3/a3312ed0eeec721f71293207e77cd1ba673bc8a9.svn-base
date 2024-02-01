namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class INYCONTEXT : DbContext
    {
        public INYCONTEXT()
            : base("name=GLOBALCONTEXT")
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ccosto> Ccosto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nivel)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.userAutorizaP)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.codusu2)
                .IsUnicode(false);

            modelBuilder.Entity<Ccosto>()
               .Property(e => e.Tipocco)
               .IsFixedLength();

            modelBuilder.Entity<Ccosto>()
                .Property(e => e.Codusu)
                .IsFixedLength();

            modelBuilder.Entity<Ccosto>()
                .Property(e => e.codPer)
                .IsUnicode(false);

            modelBuilder.Entity<Ccosto>()
                .Property(e => e.concar)
                .IsUnicode(false);
        }
    }
}
