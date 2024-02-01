namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modeld0 : DbContext
    {
        public Modeld0()
            : base("name=Modeld0")
        {
        }

        public virtual DbSet<VISTA_MOVG> VISTA_MOVG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VISTA_MOVG>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_MOVG>()
                .Property(e => e.C6_CCENCOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_MOVG>()
                .Property(e => e.C6_CALMA)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
