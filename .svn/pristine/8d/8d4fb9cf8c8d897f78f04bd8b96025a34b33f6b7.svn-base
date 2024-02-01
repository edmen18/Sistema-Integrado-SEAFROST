namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model22 : DbContext
    {
        public Model22()
            : base("name=Model222")
        {
        }

        public virtual DbSet<VISTA_PEDIDOS> VISTA_PEDIDOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CNUMPED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_DFECDOC)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_DFECFIJ)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_DFECEMB)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CCODCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.FV_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_NIMPORT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.TG_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.VE_CNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CESTADO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F5_CCVEND2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_PEDIDOS>()
                .Property(e => e.F6_NCANTID)
                .HasPrecision(38, 3);
        }
    }
}
