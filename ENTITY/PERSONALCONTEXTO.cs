namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PERSONALCONTEXTO : DbContext
    {
        public PERSONALCONTEXTO()
            : base("name=PERSONALCONTEXTO")
        {
        }

        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<PersonalEmpresa> PersonalEmpresa { get; set; }
        public virtual DbSet<PersonalLabores> PersonalLabores { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personal>()
                .Property(e => e.Basico)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Personal>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.DepositoBancoCuenta)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.CategoriaTrabajador)
                .IsFixedLength();

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.DomicilioNumeroVia)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.DomicilioInterior)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.Basico)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.AsignacionEmpresarialImporte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.IncAFP1023Importe)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.IncAFP300Importe)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.RepresentacionImporte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.MovilidadImporte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.DescJudicialesPorc)
                .HasPrecision(6, 2);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.DescJudicialesImporte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.DescRentaImporte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.AporteEsSaludPorc)
                .HasPrecision(6, 2);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.AporteSenatiPorc)
                .HasPrecision(6, 2);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.ParametroTopeQuincenaImporte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.montoGratificacionExtraordinaria)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.grupo2)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.moneda)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.deposito)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.idSubGrupoTrabajo)
                .IsFixedLength();

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.idTipoComision)
                .IsFixedLength();

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.codturno)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.monedaJornal)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.depositoJornal)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalEmpresa>()
                .Property(e => e.sueldoJornal)
                .HasPrecision(19, 4);


            modelBuilder.Entity<PersonalLabores>()
               .Property(e => e.sie)
               .IsUnicode(false);
        }
    }
}
