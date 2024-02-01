namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_parametrosbusq
    {
        [Key]
        public int PM_ID { get; set; }

        [StringLength(150)]
        public string PM_DESC { get; set; }

        [StringLength(1)]
        public string PM_CAT { get; set; }

        public static List<tabla_parametrosbusq> ListaParam_af(tabla_parametrosbusq BDMC)
        {
            List<tabla_parametrosbusq> dato = new List<tabla_parametrosbusq>();
            try
            {
               using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from c in ctx.tabla_parametrosbusq where c.PM_CAT == BDMC.PM_CAT select c).ToList();
                }
            }
            catch
            {
                dato = null;

            }
            return dato;
        }

    }
}
