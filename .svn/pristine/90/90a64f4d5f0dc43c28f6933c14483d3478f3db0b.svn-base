namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_EXPOR : DbContext
    {
        public DB_EXPOR()
            : base("name=DB_EXPOR")
        {
        }

        public virtual DbSet<FACTURA_CABECERA> FACTURA_CABECERA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.IDFACTURA)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.SERIE)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.TIPODOC)
                .IsFixedLength();

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.VAPOR)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.BL)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.REGIS)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.CANTIDADES)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.CANTIDADUS)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.PEMB)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.PDEST)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.CFR)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.PTOCFR)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.TIMCOTERM)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.DIROPCION)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.CONSIGNATARIO)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.DIRCONSIG)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.UNIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.UNIDADPB)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.CLIENTEOPC)
                .IsUnicode(false);

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.IDPDEST)
                .IsFixedLength();

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.IDPTOCFR)
                .IsFixedLength();

            modelBuilder.Entity<FACTURA_CABECERA>()
                .Property(e => e.DOCREF)
                .IsUnicode(false);
        }
    }
}
