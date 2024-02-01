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
    public partial class tabla_stockminimo
    {
        [Key]
        [StringLength(50)]
        public string codigo { get; set; }

        [Column(TypeName = "money")]
        public decimal? stock_minimo { get; set; }

        [Column(TypeName = "money")]
        public decimal? eoq { get; set; }

        public static tabla_stockminimo retornaStockMinimo(string  codigo)
        {
            tabla_stockminimo stock = new tabla_stockminimo()
            {
                codigo= codigo,
                stock_minimo=0,
                eoq=0
            };
            using (var ctx = new ANEXO_RSFACAR())
            {
                var data = ctx.tabla_stockminimo.Where(x => x.codigo.Trim() == codigo.Trim()).FirstOrDefault();
                if (data == null)
                    data = stock;
                return data;
            }
        }

    }
}
