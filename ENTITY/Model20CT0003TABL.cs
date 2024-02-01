namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20CT0003TABL : DbContext
    {
        public Model20CT0003TABL()
            : base("name=CT0003TABL")
        {
        }

        public virtual DbSet<CT0003TABL> CT0003TABL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.TCOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.TCLAVE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.TDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CT0003TABL>()
                .Property(e => e.THORA)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
