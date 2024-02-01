namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_parametros
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string AF_COD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string AF_CCLAVE { get; set; }

        [Required]
        [StringLength(100)]
        public string AF_TDESCRI1 { get; set; }

        [StringLength(100)]
        public string AF_TDESCRI2 { get; set; }

        [StringLength(100)]
        public string AF_TDESCRI3 { get; set; }

        [StringLength(10)]
        public string AF_CUSUCRE { get; set; }

        public DateTime? AF_DFECCRE { get; set; }

        [StringLength(10)]
        public string AF_CUSUMOD { get; set; }

        public DateTime? AF_DFECMOD { get; set; }

        [StringLength(2)]
        public string AF_ESTADO { get; set; }

        public static List<tabla_parametros> ListarParametro(tabla_parametros PDATA)
        {
            var data = new List<tabla_parametros>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    data = ctx.tabla_parametros.Where(x => x.AF_COD==PDATA.AF_COD && x.AF_ESTADO == "A").OrderBy(x=>x.AF_TDESCRI1).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }
    }
}
