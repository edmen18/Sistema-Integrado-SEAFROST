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
    public partial class tabla_transporte_turno
    {
      

        [Key]
        [StringLength(3)]
        public string cod { get; set; }

        [StringLength(50)]
        public string turno { get; set; }

      

        public static List<tabla_transporte_turno> ListaTurno()
        {
            var alumnos = new List<tabla_transporte_turno>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.tabla_transporte_turno.ToList();
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
