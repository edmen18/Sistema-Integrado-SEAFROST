namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_ordenped
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string IDPEDIDO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDORDEN { get; set; }


        public static List<listpedos> ListaPedos(string norden)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                var sinf = (from c in ctx.tabla_ordenped
                            where c.IDORDEN == norden
                            select new
                            {
                                IDPEDIDO = c.IDPEDIDO,
                                IDORDEN = c.IDORDEN
                            }).ToList().Select(x => new listpedos()
                            {
                                IDPEDIDO = x.IDPEDIDO,
                                IDORDEN = x.IDORDEN
                            }
                ).ToList();
                string[] ds =new string[1];
                foreach (var sa  in sinf)
                {
                    ds[0] = ds[0] + sa.IDPEDIDO+" | ";
                }

                List<listpedos> Asa = new List<listpedos>();
                if (ds[0] != null)
                {
                    foreach (var c in ds)
                    {
                        Asa.AddRange(new List<listpedos>(){ new listpedos(){
                       IDPEDIDO = c.ToString().Trim()
                        }
                    });
                    }
                }
                else
                {
                    Asa.AddRange(new List<listpedos>(){ new listpedos(){
                       IDPEDIDO = null }
                    });
                }
                
                return Asa;
            }
        }
    }
}
