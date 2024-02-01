namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PERSONALCONTEXT : DbContext
    {
        public PERSONALCONTEXT()
            : base("name=PERSONALCONTEXT")
        {
        }
       
        public virtual DbSet<tabla_configuracion_correo> tabla_configuracion_correo { get; set; }

        public virtual DbSet<tabla_turno> tabla_turno { get; set; }
        public virtual DbSet<vista_personalGeneral> vista_personalGeneral { get; set; }
        public virtual DbSet<tabla_tipoPermiso> tabla_tipoPermiso { get; set; }
        public virtual DbSet<tabla_permisos> tabla_permisos { get; set; }
        public virtual DbSet<tabla_tipoHorarios> tabla_tipoHorarios { get; set; }
        public virtual DbSet<PersonalEmpresa> PersonalEmpresa { get; set; }
        public virtual DbSet<tabla_Horarios> tabla_Horarios { get; set; }
        public virtual DbSet<Ccosto> Ccosto { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<PersonalCategorias> PersonalCategorias { get; set; }
        public virtual DbSet<PersonalConfiguracion> PersonalConfiguracion { get; set; }

        public virtual DbSet<vista_personalGeneralFoto> vista_personalGeneralFoto { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabla_configuracion_correo>()
             .Property(e => e.servidor_salida)
             .IsUnicode(false);

            modelBuilder.Entity<tabla_configuracion_correo>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_configuracion_correo>()
                .Property(e => e.pass)
                .IsUnicode(false);

            //modelBuilder.Entity<PersonalLabores>()
            //   .Property(e => e.sie)
            //   .IsUnicode(false);

            modelBuilder.Entity<tabla_turno>()
               .Property(e => e.cod)
               .IsUnicode(false);

            modelBuilder.Entity<tabla_turno>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneralFoto>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneralFoto>()
                .Property(e => e.AsignacionFamiliar)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneralFoto>()
                .Property(e => e.fechaingreso)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneralFoto>()
                .Property(e => e.fechanacimiento)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneralFoto>()
                .Property(e => e.Activo)
                .IsUnicode(false);
            modelBuilder.Entity<vista_personalGeneral>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneral>()
                .Property(e => e.AsignacionFamiliar)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneral>()
                .Property(e => e.fechaingreso)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneral>()
                .Property(e => e.fechanacimiento)
                .IsUnicode(false);

            modelBuilder.Entity<vista_personalGeneral>()
                .Property(e => e.Activo)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_tipoPermiso>()
               .Property(e => e.cod)
               .IsUnicode(false);

            modelBuilder.Entity<tabla_tipoPermiso>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_permisos>()
               .Property(e => e.codper)
               .IsUnicode(false);

            modelBuilder.Entity<tabla_permisos>()
                .Property(e => e.motivo)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_permisos>()
                .Property(e => e.codtipopermiso)
                .IsUnicode(false);
            modelBuilder.Entity<PersonalCategorias>()
                .Property(e => e.idCategoria)
                .IsFixedLength();

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

            modelBuilder.Entity<tabla_Horarios>()
                .Property(e => e.descripcion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_Horarios>()
                .Property(e => e.codcosto)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tabla_tipoHorarios>()
               .Property(e => e.cod)
               .IsFixedLength()
               .IsUnicode(false);

            modelBuilder.Entity<tabla_tipoHorarios>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ccosto>()
               .Property(e => e.Tipocco)
               .IsFixedLength();

            modelBuilder.Entity<Ccosto>()
                .Property(e => e.Codusu)
                .IsFixedLength();

            modelBuilder.Entity<Ccosto>()
                .Property(e => e.codPer)
                .IsUnicode(false);

            modelBuilder.Entity<Ccosto>()
                .Property(e => e.concar)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
               .Property(e => e.nivel)
               .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.userAutorizaP)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.codusu2)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalConfiguracion>()
               .Property(e => e.Basico)
               .HasPrecision(10, 2);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.HorasTrabajadas)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.Ing_AsignacionFamiliar)
                .HasPrecision(8, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.Desc_EsSaludVida)
                .HasPrecision(8, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.Desc_SNP)
                .HasPrecision(8, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.Aport_EsSalud)
                .HasPrecision(8, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.Aport_Senati)
                .HasPrecision(8, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.TopeSeguroAFP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.uit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.porcentajequincena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PersonalConfiguracion>()
                .Property(e => e.porcentajemensual)
                .HasPrecision(19, 4);
        }
    }
}
