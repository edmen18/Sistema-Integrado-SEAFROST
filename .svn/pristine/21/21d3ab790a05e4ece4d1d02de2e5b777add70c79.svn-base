namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_niveledicion
    {
        [Key]
        public int NA_ID { get; set; }

        [StringLength(300)]
        public string NA_NIVEL { get; set; }

        [StringLength(10)]
        public string NA_CODREF { get; set; }

        public static List<tabla_niveledicion> Listarniveles()
        {
            var dato = new List<tabla_niveledicion>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = ctx.tabla_niveledicion.OrderBy(f => f.NA_ID).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dato;
        }



    }
}
