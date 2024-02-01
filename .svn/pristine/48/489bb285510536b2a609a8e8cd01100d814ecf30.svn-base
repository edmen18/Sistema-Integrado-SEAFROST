namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    public partial class AL0003FACD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string LD_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string LD_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string LD_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string LD_CITEM { get; set; }

        [Required]
        [StringLength(25)]
        public string LD_CCODIGO { get; set; }

        [Required]
        [StringLength(60)]
        public string LD_CDESCRI { get; set; }

        
        [StringLength(1)]
        public string LD_CTR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NCANTID { get; set; }

        [Required]
        [StringLength(3)]
        public string LD_CUNIDAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NPRECIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NPRECI1 { get; set; }

        public DateTime? LD_DFECDOC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIGVMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIGVUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIMPUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIMPMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIMPRMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LD_NIMPRUS { get; set; }

        
        [StringLength(1)]
        public string LD_CESTADO { get; set; }

        
        [StringLength(5)]
        public string LD_CVENDE { get; set; }

        [Required]
        [StringLength(5)]
        public string LD_CNROCAJ { get; set; }

        [Required]
        [StringLength(4)]
        public string LD_CALMA { get; set; }

        [Required]
        [StringLength(1)]
        public string LD_CSTOCK { get; set; }

        [Required]
        [StringLength(5)]
        public string LD_CUSUCRE { get; set; }

        public DateTime? LD_DFECCRE { get; set; }

        /// <summary>
        /// Lista Detalle Factura
        /// Filtro
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<AL0003FACD> listar(AL0003FACD DATA)
        {
            List<AL0003FACD> lista = new List<AL0003FACD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    lista = ctx.AL0003FACD.Where(x => x.LD_CTD == DATA.LD_CTD && x.LD_CNUMDOC == DATA.LD_CNUMDOC).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static Boolean insertaDetalle(AL0003FACD datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
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
