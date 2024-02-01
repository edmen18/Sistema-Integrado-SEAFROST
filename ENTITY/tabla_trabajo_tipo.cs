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
    using System.Globalization;


    public partial class tabla_trabajo_tipo
    {
        [Key]
        [StringLength(3)]
        public string COD { get; set; }

        [StringLength(50)]
        public string TIPO { get; set; }

        public static List<tabla_trabajo_tipo> ListaTipo()
        {
            var alumnos = new List<tabla_trabajo_tipo>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.tabla_trabajo_tipo.ToList();
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
