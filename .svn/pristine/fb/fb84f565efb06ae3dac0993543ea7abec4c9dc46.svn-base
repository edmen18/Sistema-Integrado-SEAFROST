namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RRHHCONSERVAS : DbContext
    {
        public RRHHCONSERVAS()
            : base("name=RRHHCONSERVAS")
        {
        }

        public virtual DbSet<tabla_services> tabla_services { get; set; }
        public virtual DbSet<T_Planilla> T_Planilla { get; set; }
        public virtual DbSet<DetPlanilla> DetPlanilla { get; set; }
        public virtual DbSet<T_TarGral> T_TarGral { get; set; }
        public virtual DbSet<T_Producto> T_Producto { get; set; }
        public virtual DbSet<T_Presentacion> T_Presentacion { get; set; }
        public virtual DbSet<T_Tarea> T_Tarea { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tabla_services>()
           .Property(e => e.codtra)
           .IsUnicode(false);

            modelBuilder.Entity<tabla_services>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tabla_services>()
                .Property(e => e.dni)
                .IsUnicode(false);

            //planilla cabecera
            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.codp)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.codt)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.hora)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.responsable)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.confirmacion)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.turno)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.Sala)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.codturno)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
                .Property(e => e.codsala)
                .IsUnicode(false);

            modelBuilder.Entity<T_Planilla>()
              .Property(e => e.guia)
              .IsUnicode(false);

            //planilla detalle

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.codtra)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.kilos)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.codp)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.codt)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.detalleTrabajador)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.horas)
                .HasPrecision(11, 3);

            modelBuilder.Entity<DetPlanilla>()
                .Property(e => e.codtra1)
                .IsUnicode(false);
            //producto
            modelBuilder.Entity<T_Producto>()
              .Property(e => e.codp)
              .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.desp)
                .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.sw)
                .IsUnicode(false);

            modelBuilder.Entity<T_Producto>()
                .Property(e => e.idespecie)
                .IsUnicode(false);
            //tarifa general 
            modelBuilder.Entity<T_TarGral>()
                       .Property(e => e.codp)
                       .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codpr)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codt)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.und)
                .IsUnicode(false);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.tar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_TarGral>()
                .Property(e => e.codsofcom)
                .IsUnicode(false);

            //descrip

            modelBuilder.Entity<T_Presentacion>()
                    .Property(e => e.codpr)
                    .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.despr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Presentacion>()
                .Property(e => e.idgrupo)
                .IsUnicode(false);

            //tarea
            modelBuilder.Entity<T_Tarea>()
                 .Property(e => e.codt)
                 .IsUnicode(false);

            modelBuilder.Entity<T_Tarea>()
                .Property(e => e.dest)
                .IsUnicode(false);

            modelBuilder.Entity<T_Tarea>()
                .Property(e => e.codcon)
                .IsUnicode(false);

            modelBuilder.Entity<T_Tarea>()
                .Property(e => e.codconhor)
                .IsUnicode(false);
        }
    }
}
