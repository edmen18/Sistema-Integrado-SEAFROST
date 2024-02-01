namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    public partial class tabla_embarcaciones
    {
        [Key]
        [StringLength(20)]
        public string E_MATRIC { get; set; }

        [Required]
        [StringLength(50)]
        public string E_NOMBRE { get; set; }

        [Required]
        [StringLength(150)]
        public string E_RESOLU { get; set; }

        [Required]
        [StringLength(10)]
        public string E_PERPES { get; set; }

        [Required]
        [StringLength(10)]
        public string E_PERZAR { get; set; }

        [StringLength(60)]
        public string E_ESPCHD { get; set; }

        public decimal? E_CABOM3 { get; set; }

        public decimal? E_CABOTM { get; set; }

        [Required]
        [StringLength(5)]
        public string E_USUCRE { get; set; }

        public DateTime E_FECCRE { get; set; }

        [StringLength(5)]
        public string E_USUMOD { get; set; }

        public DateTime? E_FECMOD { get; set; }

        [Required]
        [StringLength(2)]
        public string E_ESTADO { get; set; }

        public static string ListarEID(string ID)
        {
            string codID;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    codID = ctx.tabla_embarcaciones.Where(x => x.E_MATRIC==ID && x.E_PERPES == "VIGENTE" && x.E_PERZAR == "VIGENTE").Select(y=>y.E_NOMBRE+" "+y.E_MATRIC).FirstOrDefault().ToString();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return codID;
        }
        public static List<tabla_embarcaciones> ListarEmbarcacionid(tabla_embarcaciones EDATA)
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    listaE = ctx.tabla_embarcaciones.Where(x => x.E_MATRIC.Contains(EDATA.E_MATRIC) && x.E_PERPES=="VIGENTE" && x.E_PERZAR=="VIGENTE").ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
        public static List<tabla_embarcaciones> ListarEmbarcacion(tabla_embarcaciones EDATA)
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    listaE = ctx.tabla_embarcaciones.Where(x => x.E_PERPES == "VIGENTE" && x.E_PERZAR == "VIGENTE" && SqlFunctions.PatIndex(EDATA.E_NOMBRE, x.E_NOMBRE) > 0 || SqlFunctions.PatIndex(EDATA.E_NOMBRE,x.E_MATRIC)>0).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
    }
}
