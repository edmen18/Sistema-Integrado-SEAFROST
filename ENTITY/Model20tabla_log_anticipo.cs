namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20tabla_log_anticipo : DbContext
    {
        public Model20tabla_log_anticipo()
            : base("name=tabla_log_anticipo")
        {
        }

        public virtual DbSet<tabla_log_anticipo> tabla_log_anticipo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.ANT_CODIGOL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CNUMORDL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CCODPROL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CRAZOCL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CODMONL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.MOTIVOL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CTAPROVEEDORL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_BANCOL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.BANCOL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.MONEDAL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.ESTADOL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.APROBADOL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.USER1L)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.USER2L)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.USER3L)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.USER4L)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CCODSOLL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OC_CSOLICTL)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.USUMODL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_log_anticipo>()
                .Property(e => e.OPERACIONL)
                .IsUnicode(false);
        }
    }
}
