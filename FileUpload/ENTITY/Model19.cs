namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model19 : DbContext
    {
        public Model19()
            : base("name=Model191")
        {
        }

        public virtual DbSet<AL0003ASER> AL0003ASER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CLOCALI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CSERIE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_NCANTID)
                .HasPrecision(12, 3);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CITEREQ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_CNUMCEL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003ASER>()
                .Property(e => e.C6_NCANRPE)
                .HasPrecision(13, 3);
        }
    }
}
