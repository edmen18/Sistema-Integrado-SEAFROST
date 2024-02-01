namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;
    using System.Linq;
    public partial class T_PLANTA
    {

        [Key]
        [StringLength(10)]
        public string PL_CODIGO { get; set; }

        public string PL_DESCRIPCION { get; set; }

        [StringLength(1)]
        public string PL_ESTADO { get; set; }


        public static List<T_PLANTA> ListarPLANTA()
        {
            var retorno = new List<T_PLANTA>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.T_PLANTA.ToList();
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
