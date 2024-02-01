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

    public partial class tabla_transporte_procedencia
    {
       

        [Key]
        [StringLength(3)]
        public string cod { get; set; }

        [StringLength(50)]
        public string procedencia { get; set; }

   
        public static List<tabla_transporte_procedencia> ListaProcedencia()
        {
            var alumnos = new List<tabla_transporte_procedencia>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.tabla_transporte_procedencia.ToList();
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
