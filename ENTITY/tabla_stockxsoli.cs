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
    public partial class tabla_stockxsoli
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string SS_CCODIGO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string SS_ALMACEN { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string SS_SOLICITAN { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string SS_LOTES { get; set; }


        public decimal SS_CANTID { get; set; }

        [StringLength(2)]
        public string SS_ESTADO { get; set; }

        [StringLength(10)]
        public string SS_SOLICORIGEN { get; set; }

        [StringLength(5)]
        public string SS_ALMAORIG { get; set; }

        public static decimal Stockxsolicitante(tabla_stockxsoli tss)
        {
            decimal stocxsoli = 0;
            var sumasolap = tabla_d_solicitud.CantidadsolicitadaAp("7", tss.SS_CCODIGO, tss.SS_ALMACEN).Sum(a => a.DS_CANTID);
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    stocxsoli = ctx.tabla_stockxsoli.Where(a => a.SS_CCODIGO == tss.SS_CCODIGO && a.SS_SOLICITAN == tss.SS_SOLICITAN && a.SS_ALMACEN == tss.SS_ALMACEN).ToList().Sum(rr => rr.SS_CANTID);
                    //AL0003STOC.ListarStockID(tss.SS_ESTADO, tss.SS_CCODIGO, "S").First().SK_NSKDIS;
                    //stocxsoli = stocxsoli - Convert.ToDecimal(sumasolap);
                }
            }
            catch
            {
                stocxsoli = 0;
            }

            if (stocxsoli == 0)
            {
                try
                {
                    var StockFinal = AL0003STOC.ListarStockID(tss.SS_ESTADO, tss.SS_CCODIGO, "S").First().SK_NSKDIS;

                    stocxsoli = StockFinal - Convert.ToDecimal(sumasolap);
                }
                catch
                {
                    stocxsoli = 0;
                }
            }

            return stocxsoli;
        }


        public static decimal Stockxsol(tabla_stockxsoli tss)
        {
            decimal stocxsoli = 0;decimal stockfsol = 0;
            var sumasolap = tabla_d_solicitud.CantidadsolicitadaAp("7", tss.SS_CCODIGO, tss.SS_ALMACEN).Sum(a => a.DS_CANTID);
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    stocxsoli = ctx.tabla_stockxsoli.Where(a => a.SS_CCODIGO == tss.SS_CCODIGO && a.SS_SOLICITAN == tss.SS_SOLICITAN && a.SS_CANTID> 0 && a.SS_ALMACEN == tss.SS_ALMACEN ).ToList().Sum(rr => rr.SS_CANTID);
                    //AL0003STOC.ListarStockID(tss.SS_ESTADO, tss.SS_CCODIGO, "S").First().SK_NSKDIS;
                    if (stocxsoli == 0)
                    {
                        stockfsol = 0;
                    }
                    else
                    {
                        stockfsol = stocxsoli - Convert.ToDecimal(sumasolap);
                    }
                }
            }
            catch
            {
                stockfsol = 0;
            }

            return stockfsol;
        }


        public static decimal StockxGeneral(tabla_stockxsoli tss)
        {
            decimal stocxsoli = 0;
            var sumasolap = tabla_d_solicitud.CantidadsolicitadaAp("7", tss.SS_CCODIGO, tss.SS_ALMACEN).Sum(a => a.DS_CANTID);
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    stocxsoli = AL0003STOC.ListarStockID(tss.SS_ESTADO, tss.SS_CCODIGO, "S").First().SK_NSKDIS;
                    stocxsoli = stocxsoli - Convert.ToDecimal(sumasolap);
                }
            }
            catch
            {
                stocxsoli = 0;
            }


            return stocxsoli;
        }



        public static decimal StockGeneral(tabla_stockxsoli tss)
        {
            decimal stocxsoli = 0;
            try
            {
                var StockFinal = AL0003STOC.ListarStockID(tss.SS_ESTADO, tss.SS_CCODIGO, "S").First().SK_NSKDIS;
                stocxsoli = StockFinal;
            }
            catch
            {
                stocxsoli = 0;
            }
            return stocxsoli;
        }


        public static void InsertaStockxSolic(tabla_stockxsoli ADDMC)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                //using (var ctxM = new ANEXO_RSFACAR())
                //{
                //    ctxM.Entry(ADDMC).State = EntityState.Modified;
                //    ctxM.SaveChanges();
                //}
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        public static void ActulizarStockxSolic(tabla_stockxsoli ADDMC, string OP)
        {
            var extraer = new tabla_stockxsoli { SS_ALMACEN = ADDMC.SS_ALMACEN, SS_CCODIGO = ADDMC.SS_CCODIGO, SS_LOTES = ADDMC.SS_LOTES.Trim(), SS_SOLICITAN = ADDMC.SS_SOLICITAN };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    var DAC = new tabla_stockxsoli();
                    DAC = (from c in ctx.tabla_stockxsoli where c.SS_ALMACEN == ADDMC.SS_ALMACEN && c.SS_CCODIGO == ADDMC.SS_CCODIGO && c.SS_LOTES.Trim() == ADDMC.SS_LOTES.Trim() && c.SS_SOLICITAN.Trim() == ADDMC.SS_SOLICITAN.Trim() select c).FirstOrDefault();
                    if (DAC == null)
                    {
                        ctx.Entry(ADDMC).State = EntityState.Added;
                        ctx.SaveChanges();
                        //try
                        //{
                    }
                    else
                    {
                        ctx.tabla_stockxsoli.Attach(DAC);
                        if (OP == "1")
                        {
                            DAC.SS_CANTID = DAC.SS_CANTID + ADDMC.SS_CANTID;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            DAC.SS_CANTID = DAC.SS_CANTID - ADDMC.SS_CANTID;
                            ctx.SaveChanges();
                        }
                        //}
                        //catch (DbEntityValidationException dbEx)
                        //{
                        //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                        //    {
                        //        foreach (var validationError in validationErrors.ValidationErrors)
                        //        {
                        //            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        //        }
                        //    }
                        //}
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }







        public static List<tabla_stockxsoli> ValidaStockxsoli(string almacen, string codprod, string solict, string lote)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {

                return (from c in ctx.tabla_stockxsoli where c.SS_ALMACEN == almacen && c.SS_CCODIGO == codprod && c.SS_SOLICITAN == solict && c.SS_LOTES == lote  && c.SS_ESTADO=="N" select c).ToList();
            }
        }



        public static List<vista_stockxs> ListaStockxAlmacen(vista_stockxs almacen)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                tabla_d_ususol prmm = new tabla_d_ususol();
                prmm.SU_USUA = almacen.SS_SOLICITAN;
                var narea = tabla_d_ususol.ListaDetalleus(prmm);
                int contt = 0;
                string[] filtroxsolusua = new string[narea.Count()];
                foreach (var c in narea)
                {
                    filtroxsolusua[contt] = c.SU_SOLIC.ToString();
                    contt++;
                }

                return (from c in ctx.tabla_stockxsoli
                        where c.SS_ALMACEN == almacen.SS_ALMACEN //&& filtroxsolusua.Contains(c.SS_SOLICITAN)
                        select new
                        {
                            data1 = c.SS_ALMACEN,
                            data2 = c.SS_SOLICITAN,
                            data3 = c.SS_LOTES,
                            data4 = c.SS_CANTID,
                            data5 = c.SS_ESTADO,
                            data6 = c.SS_CCODIGO

                        }
                ).ToList().Select(f => new vista_stockxs()
                {
                    SS_CCODIGO = f.data6,
                    SS_ALMACEN = AL0003ALMA.VerunAlmacen(f.data1).A1_CDESCRI,
                    SS_SOLICITAN = AL0003TABL.Registrouno(f.data2, "12"),
                    SS_LOTES = f.data3,
                    SS_CANTID = f.data4,
                    SS_ESTADO = f.data5,
                    SS_DESPROD = AL0003ARTI.obtenerArticuloPorID(f.data6).AR_CDESCRI,
                    SS_CODSOLICITAN = f.data2,
                    SS_CODALMACEN = f.data1
                }
                ).ToList();
            }
        }


        public static void InsActStockxSolic(tabla_stockxsoli ADDMC)
        {
            //try
            //{


            using (var ctx = new ANEXO_RSFACAR())
            {
                var nregist = (from c in ctx.tabla_stockxsoli
                               where c.SS_ALMACEN == ADDMC.SS_ALMACEN && c.SS_CCODIGO == ADDMC.SS_CCODIGO && c.SS_LOTES == ADDMC.SS_LOTES && c.SS_SOLICITAN == ADDMC.SS_SOLICITAN
                               select c).FirstOrDefault();
                if (nregist == null)
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
                else
                {
                    var cantant = nregist.SS_CANTID;
                    ctx.Entry(nregist).State = EntityState.Modified;
                    nregist.SS_CANTID = ADDMC.SS_CANTID + cantant;
                    ctx.SaveChanges();
                }


            }
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //        }
            //    }
            //}
        }

        public static void ActualizaStockS(tabla_stockxsoli ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {

                var regtistrodesc = (from c in ctx.tabla_stockxsoli
                                     where c.SS_ALMACEN == ADDMC.SS_ALMACEN && c.SS_CCODIGO == ADDMC.SS_CCODIGO && c.SS_LOTES == ADDMC.SS_LOTES && c.SS_SOLICITAN == ADDMC.SS_SOLICITAN
                                     select c).FirstOrDefault();
                ctx.Entry(regtistrodesc).State = EntityState.Modified;
                regtistrodesc.SS_CANTID = ADDMC.SS_CANTID;
                ctx.SaveChanges();
            }
        }

    }
}
