namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model27 : DbContext
    {
        public Model27()
            : base("name=Model27")
        {
        }

        public virtual DbSet<AL0003FACC> AL0003FACC { get; set; }
        public virtual DbSet<AL0003FACD> AL0003FACD { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CDH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNROCAJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CVANEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCODPRV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNOMBRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CDIRECC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRUC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCHENUM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CSUBDIA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCOMPRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NIMPORT)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NIMPRET)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CFORVEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NSALDO)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NIMPIGV)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NTIPCAM)
                .HasPrecision(11, 4);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCODMON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRFTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRFNUMSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CRFNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNROPED)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CGLOSA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_NDESCTO)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CNUMORD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_TOBSERV)
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CCALIDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CORIGEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CUSUMOD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACC>()
                .Property(e => e.LC_CTIPOPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CCODAGE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CTD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CNUMDOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CITEM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CCODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CDESCRI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NCANTID)
                .HasPrecision(11, 3);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CUNIDAD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NPRECIO)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NPRECI1)
                .HasPrecision(18, 9);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIGVMN)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIGVUS)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIGVPOR)
                .HasPrecision(5, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPUS)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPMN)
                .HasPrecision(13, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPRMN)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_NIMPRUS)
                .HasPrecision(11, 2);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CVENDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CNROCAJ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CALMA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CSTOCK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AL0003FACD>()
                .Property(e => e.LD_CUSUCRE)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
