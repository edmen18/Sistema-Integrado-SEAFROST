namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_d_solicitud
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DS_IDSOLIC { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string DS_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string DS_TIPOS { get; set; }

        

        [Column(TypeName = "numeric")]
        public decimal? DS_CANTID { get; set; }

        [StringLength(2)]
        public string DS_SOLSALDO { get; set; }

        [StringLength(50)]
        public string DS_ALMACEN { get; set; }

        [StringLength(2)]
        public string DS_MONEDA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DS_PRECIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DS_STOTALMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DS_STOTALUS { get; set; }

        [StringLength(25)]
        public string DS_LOTE { get; set; }
        




        public static void InsertaSolicitudD(tabla_d_solicitud ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {

                ctx.Entry(ADDMC).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }


        public static void eliminaSolicitudD(tabla_d_solicitud ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {

                ctx.tabla_d_solicitud.RemoveRange(ctx.tabla_d_solicitud.Where(d => d.DS_IDSOLIC == ADDMC.DS_IDSOLIC));
                ctx.SaveChanges();
            }
        }


        public static List<tabla_d_solicitud> CantidadsolicitadaAp(string estad, string codig, string idalmacen)
        {
            var inf = new List<tabla_d_solicitud>();
            using (var ctx = new ANEXO_RSFACAR()) 
            {
                inf = (from c in ctx.tabla_solicitud join d in ctx.tabla_d_solicitud on c.SM_ID equals d.DS_IDSOLIC
                           where (c.SM_ESTADO== "7" || c.SM_ESTADO == "1")  && d.DS_CCODIGO == codig && d.DS_ALMACEN == idalmacen && d.DS_TIPOS=="SO" select d 
                           ).ToList();
                
            }
            return inf ;
        }

        public static List<tabla_d_solicitud> ListarDetalleSolid(int codig,string DS_TIPOS)
        {
            var inf = new List<tabla_d_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                inf = (from c in ctx.tabla_d_solicitud
                       where c.DS_IDSOLIC == codig && c.DS_TIPOS == DS_TIPOS
                       select c).ToList();
            }
            return inf;
        }

        public static List<vista_d_soli> ListaDetalleVale(int codig, string SM_TIPOS)
        {
            var inf = new List<vista_d_soli>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                inf = (from c in ctx.tabla_d_solicitud
                       where c.DS_IDSOLIC == codig  && c.DS_TIPOS== SM_TIPOS
                       select new {
                           data1=c.DS_IDSOLIC,
                           data2=c.DS_CCODIGO,
                           data3 = c.DS_CANTID,
                           data4 = c.DS_ALMACEN
                       }
                       ).ToList().Select(x=>new vista_d_soli() { 
                           VSO_IDSOLITD = x.data1,
                           VSO_IDPROD = x.data2,
                           VSO_DESPROD = AL0003ARTI.obtenerArticuloPorID(x.data2).AR_CDESCRI,
                           VSO_UND = AL0003ARTI.obtenerArticuloPorID(x.data2).AR_CUNIDAD,
                           VSO_CANTID = Convert.ToDecimal( x.data3),
                           VSO_IDALMA = x.data4,
                       }).ToList();
            }
            return inf;
        }

        //CODIGO EDGAR
        public static List<vista_detalle_oc_req> detallesolicitud(tabla_d_solicitud DING)
        {
           List<vista_detalle_oc_req> datos = new List<vista_detalle_oc_req>();
            try
            {
                var cty = new RSFACAR();
                using (var ctx = new ANEXO_RSFACAR())
                {
                    datos = (from t in ctx.tabla_d_solicitud
                             where
                               DING.DS_IDSOLIC == t.DS_IDSOLIC
                             select new
                             {
                                 ITEM = t.DS_IDSOLIC,
                                 DESCRIPCIOM = t.DS_CCODIGO,
                                 //DESCRIPCIOM = ((from b in cty.AL0003ARTI
                                 //                              where
                                 //                                b.AR_CCODIGO == t.DS_CCODIGO
                                 //                              select new
                                 //                              {
                                 //                                  b.AR_CDESCRI
                                 //                              }).FirstOrDefault().AR_CDESCRI),

                                 UNIDAD = t.DS_MONEDA,
                                 CANTIDAD = t.DS_CANTID,
                                 PRECIOSOLES = t.DS_PRECIO,
                                 TOTALD = t.DS_STOTALUS,
                                 TOTALS = t.DS_STOTALMN,

                             }
                            ).ToList().Select(g => new vista_detalle_oc_req()
                            {
                                ITEM = Convert.ToString(g.ITEM),
                                DESCRIPCION = cty.AL0003ARTI.Where(x => x.AR_CCODIGO.Trim() == g.DESCRIPCIOM.Trim()).Select(x => x.AR_CDESCRI).FirstOrDefault(),
                                UNIDAD = g.UNIDAD,
                                CANTIDAD = Convert.ToDecimal(g.CANTIDAD),
                                PRECIOSOLES = Convert.ToDecimal(g.PRECIOSOLES),
                                TOTALD = Convert.ToDecimal(g.TOTALD),
                                TOTALS = Convert.ToDecimal(g.TOTALS),

                            }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }


    }
}
