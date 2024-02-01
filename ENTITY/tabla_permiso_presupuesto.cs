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

    public partial class tabla_permiso_presupuesto
    {
        [StringLength(6)]
        public string COD_USUARIO { get; set; }

        [StringLength(1)]
        public string PERMISO_PRES { get; set; }

        [Key]
        public int CODIGO { get; set; }

        public static int CuentaAccesoADoc(string user)
        {
            int contador = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    contador = ctx.tabla_permiso_presupuesto.Where(x => x.COD_USUARIO == user && x.PERMISO_PRES == "X").Count();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return contador;
        }
        public static int CuentaAccesovalidar(string user)
        {
            int contador = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    contador = ctx.tabla_permiso_presupuesto.Where(x => x.COD_USUARIO == user && x.PERMISO_PRES == "V").Count();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return contador;
        }
    }

}
