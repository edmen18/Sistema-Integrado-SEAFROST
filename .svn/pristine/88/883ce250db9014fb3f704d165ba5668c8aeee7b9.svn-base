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
    using System.Data.Entity.SqlServer;

    public partial class tabla_parametros
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string AF_COD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string AF_CCLAVE { get; set; }

        [Required]
        [StringLength(100)]
        public string AF_TDESCRI1 { get; set; }

        [StringLength(100)]
        public string AF_TDESCRI2 { get; set; }

        [StringLength(100)]
        public string AF_TDESCRI3 { get; set; }

        [StringLength(10)]
        public string AF_CUSUCRE { get; set; }

        public DateTime? AF_DFECCRE { get; set; }

        [StringLength(10)]
        public string AF_CUSUMOD { get; set; }

        public DateTime? AF_DFECMOD { get; set; }

        [StringLength(2)]
        public string AF_ESTADO { get; set; }

        public static List<tabla_parametros> ListarParametro(tabla_parametros PDATA)
        {
            var data = new List<tabla_parametros>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    data = ctx.tabla_parametros.Where(x => x.AF_COD==PDATA.AF_COD && x.AF_ESTADO == "A").OrderBy(x=>x.AF_TDESCRI1).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }

        /// <summary>
        /// Listado auxiliar
        /// --referencia:conservas barcos
        /// </summary>
        /// <param name="PDATA"></param>
        /// <returns></returns>
        public static List<tabla_parametros> ListarParametroX(tabla_parametros DATA)
        {
            var data = new List<tabla_parametros>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    data = ctx.tabla_parametros.Where(x => x.AF_COD == DATA.AF_COD && x.AF_ESTADO == "A"
                           && SqlFunctions.PatIndex(DATA.AF_TDESCRI2, x.AF_TDESCRI2) > 0).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }

        /// <summary>
        /// Consulta unica
        /// </summary>
        /// <param name="PDATA"></param>
        /// <returns></returns>
        public static string ListarParametroID(string COD, string KEY)
        {
            string data;

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    data = ctx.tabla_parametros.Where(x => x.AF_COD == COD && x.AF_CCLAVE.Trim() == KEY.Trim() && x.AF_ESTADO == "A").Select(y => y.AF_TDESCRI1).FirstOrDefault().ToString();
                }
            }
            catch (Exception)
            {

                data="";
            }

            return data;
        }


        public static string ListarParametroDescr2(string COD, string KEY)
        {
            string data;

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    data = ctx.tabla_parametros.Where(x => x.AF_COD == COD && x.AF_TDESCRI2.Trim() == KEY.Trim() && x.AF_ESTADO == "A").Select(y => y.AF_TDESCRI1).FirstOrDefault().ToString();
                }
            }
            catch (Exception)
            {

                data="";
            }

            return data;
        }

        public static string ListarParametroDescr1(string COD, string KEY)
        {
            string data;

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    data = ctx.tabla_parametros.Where(x => x.AF_COD == COD && x.AF_TDESCRI1.Trim() == KEY.Trim() && x.AF_ESTADO == "A").Select(y => y.AF_TDESCRI2).FirstOrDefault().ToString();
                }
            }
            catch (Exception)
            {

                data = "";
            }

            return data;
        }

        public static tabla_parametros ListarParametroID2(string COD, string KEY)
        {
            var par = new tabla_parametros();
            par.AF_COD = COD;
            par.AF_CCLAVE = KEY;

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    par = ctx.tabla_parametros.Where(x => x.AF_COD.Trim() == par.AF_COD.Trim() && x.AF_CCLAVE.Trim() == par.AF_CCLAVE.Trim() && x.AF_ESTADO == "A").FirstOrDefault();
                }
            }
            catch (Exception)
            {

                return null;
            }

            return par;
        }

        /// <summary>
        /// Consulta parametros OBJECT
        /// </summary>
        /// <param name="COD"></param>
        /// <param name="KEY"></param>
        /// <returns></returns>
        public static tabla_parametros ListarParametroID3(tabla_parametros DATA)
        {
            var par = new tabla_parametros();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    par = ctx.tabla_parametros.Where(x => x.AF_COD == DATA.AF_COD &&
                                                    x.AF_CCLAVE.Trim() == DATA.AF_CCLAVE.Trim() &&
                                                    (x.AF_TDESCRI1 != null ? x.AF_TDESCRI1 == DATA.AF_TDESCRI1 : x.AF_TDESCRI1 != DATA.AF_TDESCRI1) &&
                                                    x.AF_ESTADO == "A").FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return par;
        }
        // CODIGO EDGAR
        //INICIO DE CABECERAS
        public static List<tabla_parametros> ListarEmbarcacionestodos()
        {
            List<tabla_parametros> listaE = new List<tabla_parametros>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_parametros.Where(x => x.AF_COD == "PA").OrderByDescending(X => X.AF_DFECCRE).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
        public static List<tabla_parametros> ListarEmbarcacionParametros(tabla_parametros data)
        {
            List<tabla_parametros> listaE = new List<tabla_parametros>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_parametros.Where(x => (x.AF_COD.Trim() == data.AF_COD.Trim()) && (x.AF_CCLAVE.Trim() == data.AF_CCLAVE.Trim())).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
        //public static int generarClave(tabla_parametros data)
        //{
        //    var listaE = 0;
        //    try
        //    {
        //        using (var ctx = new ANEXO_RSFACAR())
        //        {
        //            listaE = ctx.tabla_parametros.Where(x => (x.AF_COD.Trim() == data.AF_COD.Trim())).Count();
        //            listaE = listaE + 1;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return listaE;
        //}
        public static List<tabla_parametros> ListarEmbarcacionAut(string texto)
        {
            List<tabla_parametros> listaE = new List<tabla_parametros>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_parametros.Where(x => (x.AF_COD.Contains(texto) || x.AF_CCLAVE.Contains(texto) || x.AF_TDESCRI1.Contains(texto)) && x.AF_COD=="PA").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }

        public static Boolean insertaBahia(tabla_parametros datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
                    ctx.SaveChanges();
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
                band = false;
            }
            return band;
        }

        public static Boolean actualizaBahia(tabla_parametros datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new tabla_parametros { AF_COD = datos.AF_COD, AF_CCLAVE = datos.AF_CCLAVE };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_parametros.Attach(data);
                    data.AF_COD = datos.AF_COD;
                    data.AF_CCLAVE = datos.AF_CCLAVE;
                    data.AF_CUSUMOD = datos.AF_CUSUMOD;
                    data.AF_DFECMOD = fechaA;
                    data.AF_ESTADO = "A";
                    data.AF_TDESCRI1 = datos.AF_TDESCRI1;
                    data.AF_TDESCRI2 = datos.AF_TDESCRI2;
                    data.AF_TDESCRI3 = datos.AF_TDESCRI3;
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.SaveChanges();

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
                band = false;
            }
            return band;
        }
        // FIN DE CABECERAS
        // INICIO DE DETALLES
        public static List<tabla_parametros> ListarDetalles(tabla_parametros data)
        {
            List<tabla_parametros> listaE = new List<tabla_parametros>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_parametros.Where(x => x.AF_COD.Trim() == data.AF_CCLAVE.Trim()).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaE;
        }

        public static List<tabla_parametros> Listaxalmac(tabla_parametros PDATA)
        {
            var data = new List<tabla_parametros>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    data = ctx.tabla_parametros.Where(x => x.AF_COD == PDATA.AF_COD && x.AF_TDESCRI3==PDATA.AF_TDESCRI3 && x.AF_ESTADO == "A").OrderBy(x => x.AF_TDESCRI1).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }


        public static List<tabla_parametros> ListaxDescri2(tabla_parametros PDATA)
        {
            var data = new List<tabla_parametros>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    data = (from x in ctx.tabla_parametros
                            where x.AF_COD == PDATA.AF_COD && x.AF_TDESCRI2 == PDATA.AF_TDESCRI2 && x.AF_ESTADO == "A"
                            orderby  x.AF_TDESCRI1 select new
                            {
                                AF_CCLAVE = x.AF_CCLAVE,
                                AF_TDESCRI1=x.AF_TDESCRI1,
                                AF_TDESCRI2 =x.AF_TDESCRI2,
                                AF_TDESCRI3 = x.AF_TDESCRI3,
                                AF_ESTADO=x.AF_ESTADO
                            }
                            ).ToList().Select(d=>new tabla_parametros()
                            {
                                AF_CCLAVE = d.AF_CCLAVE.Trim(),
                                AF_TDESCRI1 = d.AF_TDESCRI1.Trim(),
                                AF_TDESCRI2 = d.AF_TDESCRI2.Trim(),
                                AF_TDESCRI3 = d.AF_TDESCRI3.Trim(),
                                AF_ESTADO = d.AF_ESTADO.Trim()

                            }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }

        public static List<tabla_parametros> ListarParametroCH(tabla_parametros DATA)
        {
            var par = new List<tabla_parametros>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    par = ctx.tabla_parametros.Where(x => x.AF_COD == DATA.AF_COD &&
                                                    x.AF_TDESCRI2 == DATA.AF_TDESCRI2  &&
                                                    x.AF_ESTADO == "A").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return par;
        }
        /// <summary>
        /// listar areas rendiciones
        /// </summary> Edgar Mendoza Mendives.
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<AL0003TABL> areasrendicion(tabla_parametros PDATA)
        {
            var data = new List<AL0003TABL>();
            var cty = new ANEXO_RSFACAR();
            var arreglo = cty.tabla_parametros.Where(x => x.AF_COD.Trim() == PDATA.AF_COD.Trim()).Select(x => x.AF_TDESCRI2).ToList();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    data = (from x in ctx.AL0003TABL
                            where x.TG_CCOD == "10"
                            && arreglo.Contains(x.TG_CCLAVE)
                            select new
                            {
                                CUENTA = x.TG_CCLAVE,
                                DESCRIPCION = x.TG_CDESCRI,

                            }
                            ).ToList().Select(d => new AL0003TABL()
                            {
                                TG_CCLAVE = d.CUENTA,
                                TG_CDESCRI = d.DESCRIPCION,
                               
                            }).Where(x=>x.TG_CDESCRI!="").Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }
        /// <summary>
        /// LISTAR comprobantes
        /// </summary>
        /// <param name="PDATA"></param>
        /// <returns></returns>
        public static List<CT0003TAGE> ComprobantesRendicion(tabla_parametros PDATA)
        {
            var data = new List<CT0003TAGE>();
            var cty = new ANEXO_RSFACAR();
            var ARREGLO = cty.tabla_parametros.Where(x => x.AF_COD.Trim() == PDATA.AF_COD.Trim()).Select(x => x.AF_TDESCRI1).ToList();

            try
            {
               
                using (var ctx = new RSCONCAR())
                {
                    data = (from x in ctx.CT0003TAGE
                            where ARREGLO.Contains(x.TCLAVE) && x.TCOD=="06"
                            orderby x.TDESCRI
                            select new
                            {
                                TCLAVE = x.TCLAVE,
                                TDESCRI = x.TDESCRI,
                               
                            }
                            ).ToList().Select(d => new CT0003TAGE()
                            {
                                TCLAVE = d.TCLAVE,
                                TDESCRI = d.TDESCRI,

                            }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        /// <summary>
        /// listar CUENTAS AREAS
        /// </summary> Edgar Mendoza Mendives.
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<CT0003PLEM> cuentasrendicion(tabla_parametros PDATA)
        {
            var data = new List<CT0003PLEM>();
            var cty = new ANEXO_RSFACAR();
            var arreglo = cty.tabla_parametros.Where(x => x.AF_COD == PDATA.AF_COD && (x.AF_TDESCRI2.Trim() == PDATA.AF_TDESCRI2.Trim() || x.AF_TDESCRI2.Trim() =="")).Select(x=>x.AF_TDESCRI1).ToList();
            try
            {               
                using (var ctx = new RSCONCAR())
                {
                    data = (from x in ctx.CT0003PLEM
                            where (x.PCUENTA.Contains("63") || x.PCUENTA.Contains("65") || x.PCUENTA.Contains("64"))
                            && arreglo.Contains(x.PCUENTA)
                            select new
                            {
                                PCUENTA = x.PCUENTA,
                                PDESCRI = x.PDESCRI,
                                                          }
                            ).ToList().Select(d => new CT0003PLEM()
                            {
                                PCUENTA = d.PCUENTA,
                                PDESCRI = d.PDESCRI,

                            }).Where(x => x.PDESCRI != "").Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public static string  ObtenerSubdiario(tabla_parametros PDATA)
        {
            var data = "";
                      
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                  data =  ctx.tabla_parametros.Where(x => x.AF_COD == PDATA.AF_COD && x.AF_TDESCRI1.Trim() == PDATA.AF_TDESCRI1.Trim()).Select(x => x.AF_TDESCRI2).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }


        public static tabla_parametros ListarParametroID3(string COD, string DES1)
        {
            var par = new tabla_parametros();
            par.AF_COD = COD;
            par.AF_TDESCRI1 = DES1;

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto)
                    par = ctx.tabla_parametros.Where(x => x.AF_COD.Trim() == par.AF_COD.Trim() && x.AF_TDESCRI1.Trim() == par.AF_TDESCRI1.Trim() && x.AF_ESTADO == "A").FirstOrDefault();
                }
            }
            catch (Exception)
            {

                return null;
            }

            return par;
        }


    }
}
