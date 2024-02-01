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
    using System.Data.Entity.SqlServer;
    public partial class CP0003VARI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(18)]
        public string CH_CNUMCTA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string CH_CNUMCHE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string CH_CFECCHE { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(40)]
        public string CH_CNOMCHE { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(6)]
        public string CH_CFECCOM { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string CH_CSUBDIA { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(6)]
        public string CH_CNUMCOM { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal CH_NIMPOCH { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(2)]
        public string CH_CCODMON { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(1)]
        public string CH_CVANEXO { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(18)]
        public string CH_CCODIGO { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(1)]
        public string CH_CESTADO { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(6)]
        public string CH_CFECEST { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(5)]
        public string CH_CUSUARI { get; set; }

        public DateTime? CH_DFECHA { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(6)]
        public string CH_CHORA { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(12)]
        public string CH_CCTACON { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(1)]
        public string CH_CSITUAC { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(2)]
        public string CH_DOCREFT { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(10)]
        public string CH_DOCREFN { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(12)]
        public string CH_CCOGAST { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(50)]
        public string CH_CCONCEP { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(6)]
        public string CH_CFECDIF { get; set; }

        [Key]
        [Column(Order = 22, TypeName = "numeric")]
        public decimal CH_NTIPCAM { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(20)]
        public string CH_CCTACTE { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(20)]
        public string CH_CFORPAG { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(1)]
        public string CH_CTIPPAG { get; set; }

        public DateTime? CH_DFECCHE { get; set; }

        public DateTime? CH_DFECCOM { get; set; }

        public DateTime? CH_DFECEST { get; set; }

        public DateTime? CH_DFECDIF { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(1)]
        public string CH_CPAGTEL { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(10)]
        public string CH_CNUMLIQ { get; set; }

        /// <summary>
        /// Registro FORMA CHEQUE
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static Boolean insertar(CP0003VARI DATA)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(DATA).State = EntityState.Added;
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

        public static CP0003VARI listarUnRegistro(CP0003VARI DATA)
        {
            var lista = new CP0003VARI();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003VARI.Where(x => x.CH_CNUMCTA==DATA.CH_CNUMCTA 
                                                //&& x.CH_CSUBDIA==DATA.CH_CSUBDIA 
                                                //&& x.CH_CNUMCOM==DATA.CH_CNUMCOM
                                                && x.CH_CNUMCHE==DATA.CH_CNUMCHE 
                                                && x.CH_CFECCHE==DATA.CH_CFECCHE).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }            
            return lista;
        }
    }
}
