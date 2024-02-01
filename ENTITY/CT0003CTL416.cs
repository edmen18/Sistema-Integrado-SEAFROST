namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data;

    public partial class CT0003CTL416
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string LG_CSUBDIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string LG_CCOMPRO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string LG_CSECUEN { get; set; }

        public DateTime? LG_DCOMPRO { get; set; }

        [Required]
        [StringLength(40)]
        public string LG_CGLOSA { get; set; }

        [Required]
        [StringLength(2)]
        public string LG_CCODMON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LG_DIMPORT { get; set; }

        [Required]
        [StringLength(5)]
        public string LG_CUSER { get; set; }

        [Required]
        [StringLength(5)]
        public string LG_CUSUCRE { get; set; }

        public DateTime? LG_DFECELI { get; set; }

        public DateTime? LG_DFECCRE { get; set; }
        public static string GeneraSecuencia(CT0003CTL416 com)
        {
            var codigo = "";
            var valor = "";
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    codigo = ctx.CT0003CTL416.Where(x=>x.LG_CSUBDIA.Trim()==com.LG_CSUBDIA.Trim() && x.LG_CCOMPRO.Trim()==com.LG_CCOMPRO.Trim() ).Select(x => x.LG_CSECUEN).Max();
                    codigo = Convert.ToString(Convert.ToInt32(codigo) + 1);
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        public static Boolean insertaCabecera(CT0003CTL416 datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                band = false;
            }
            return band;
        }
    }
}
