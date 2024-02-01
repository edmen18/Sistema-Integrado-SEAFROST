namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_tipo_despacho
    {
        [Key]
        [StringLength(5)]
        public string TD_ID { get; set; }

        [StringLength(200)]
        public string TD_DESC { get; set; }
        public static List<tabla_tipo_despacho> ListarTipodespa()
        {
            var alumnos = new List<tabla_tipo_despacho>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.tabla_tipo_despacho.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
         
    }
}
