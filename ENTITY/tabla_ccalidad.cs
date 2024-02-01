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
    public partial class tabla_ccalidad
    {
        [Key]
        [StringLength(11)]
        public string CA_IDORDEN { get; set; }

        [StringLength(5)]
        public string CA_IDCERTIF { get; set; }

        [StringLength(100)]
        public string CA_DESCERTIF { get; set; }

        [StringLength(5)]
        public string CA_IDDEST { get; set; }

        [StringLength(100)]
        public string CA_DESDEST { get; set; }

        [StringLength(5)]
        public string CA_IDPROD { get; set; }

        [StringLength(150)]
        public string CA_DESPROD { get; set; }

        [StringLength(5)]
        public string CA_IDSOLI { get; set; }

        [StringLength(120)]
        public string CA_DESSOLI { get; set; }

        [StringLength(3000)]
        public string CA_PRODMUE { get; set; }

        [StringLength(3000)]
        public string CA_AADIC { get; set; }

        public DateTime? CA_FECHAD { get; set; }

        public DateTime? CA_FECHAA { get; set; }

        //[StringLength(11)]
        //public string CA_NPEDIDO { get; set; }

        public static void Insertar_CCalidad(tabla_ccalidad datos)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(datos).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public static tabla_ccalidad ListarCcalidad(string cnumord)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    return (from c in ctx.tabla_ccalidad where c.CA_IDORDEN.Trim() == cnumord.Trim() select c).First();
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
