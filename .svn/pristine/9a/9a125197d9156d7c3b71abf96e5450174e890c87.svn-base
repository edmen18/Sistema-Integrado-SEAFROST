namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;
    using System.Linq;
        public partial class T_EQUIPO
    {
        [Key]
        [StringLength(10)]
        public string EQ_CODIGO { get; set; }

        public string EQ_DESCRIPCION { get; set; }

        [StringLength(1)]
        public string EQ_ESTADO { get; set; }

        public static List<T_EQUIPO> ListarEquipos()
        {
            var retorno = new List<T_EQUIPO>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.T_EQUIPO.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
    }
}
