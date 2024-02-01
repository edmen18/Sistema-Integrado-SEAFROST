namespace ENTITY
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model20jjjj : DbContext
    {
        public Model20jjjj()
            : base("name=Model20jjjj")
        {
        }

        public virtual DbSet<PersonalLabores> PersonalLabores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalLabores>()
                .Property(e => e.sie)
                .IsUnicode(false);
        }
    }
}
