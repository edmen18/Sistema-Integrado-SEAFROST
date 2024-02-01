namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20CP0003LOG2 : DbContext
    {
        public Model20CP0003LOG2()
            : base("name=CP0003LOG2")
        {
        }

        public virtual DbSet<CP0003LOG2> CP0003LOG2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CNUMOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CTIPTRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CORIGEN)
                .IsUnicode(false);

            modelBuilder.Entity<CP0003LOG2>()
                .Property(e => e.L2_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
