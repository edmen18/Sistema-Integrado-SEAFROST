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

    public partial class tabla_usuarios
    {
        [Key]
        [StringLength(5)]
        public string TU_ALIAS { get; set; }

        [StringLength(40)]
        public string TU_NOMUSU { get; set; }

        [StringLength(8)]
        public string TU_PASSWO { get; set; }

        public static int CuentaUsuariosClave(string user, string clave)
        {
            int cuenta = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    cuenta = ctx.tabla_usuarios.Where(x => x.TU_ALIAS == user && x.TU_PASSWO == clave).Count();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cuenta;
        }
    }
}
