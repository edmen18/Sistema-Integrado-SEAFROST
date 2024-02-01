namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model44 : DbContext
    {
        public Model44()
            : base("name=Model44")
        {
        }

        public virtual DbSet<VISTA_DCABECERA> VISTA_DCABECERA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNROCAJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CCENCOS)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.A1_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.FV_CDESCRI)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CTIPPED)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.VE_CNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.DE_CDIRECC)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CRFTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CRFNSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CRFNDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CGLOSA)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNUMCON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_DFECCON)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_DFECFIJ)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_DFECDOC)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_DFECVEN)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_DFECAPR)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNUMSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CCONTAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNUMBL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CCONEMB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CPUEEMB)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CPUEDES)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CNUMPED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_DFECEMB)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CAPPBAS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CVAPOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CVENDE2)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CCODCLI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CDIRECC)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CRUC)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.CL_CTIPCLI)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CFORVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_NIMPORT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_NTIPCAM)
                .HasPrecision(9, 4);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CDCOS)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.TG_CDESCRIES)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.F5_NIMPIGV)
                .HasPrecision(11, 2);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.DESDIRE)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.DESBROK)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.CONDICP)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.TOLERAN)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.ESPECIA)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.FECHAED)
                .IsUnicode(false);

            modelBuilder.Entity<VISTA_DCABECERA>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);
        }
    }
}
