namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model9 : DbContext
    {
        public Model9()
            : base("name=Model9")
        {
        }

        public virtual DbSet<DetPlanilla> DetPlanilla { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
