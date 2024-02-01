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
    using System.Data.SqlClient;
    public partial class CP0003PAGO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string PG_CVANEXO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string PG_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string PG_CTIPDOC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string PG_CNUMDOC { get; set; }

        // [Key] necesario para realizar la eliminacion del cheque // edgar
        [Column(Order = 4)]
        [StringLength(14)]
        public string PG_CORDKEY { get; set; }

        [Required]
        [StringLength(1)]
        public string PG_CDEBHAB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PG_NIMPOMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PG_NIMPOUS { get; set; }

        [Required]
        [StringLength(6)]
        public string PG_CFECCOM { get; set; }

        [Required]
        [StringLength(4)]
        public string PG_CSUBDIA { get; set; }

        [Required]
        [StringLength(6)]
        public string PG_CNUMCOM { get; set; }

        [Required]
        [StringLength(40)]
        public string PG_CGLOSA { get; set; }


        [StringLength(12)]
        public string PG_CCOGAST { get; set; }

        [Required]
        [StringLength(2)]
        public string PG_CORIGEN { get; set; }

        [Required]
        [StringLength(5)]
        public string PG_CUSUARI { get; set; }

        [Required]
        [StringLength(2)]
        public string PG_CCODMON { get; set; }

        public DateTime? PG_DFECCOM { get; set; }

        public static Boolean insertaCabecera(CP0003PAGO datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSCONCAR())
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

        /// <summary>
        /// Correlativo del pago
        /// Creado 15/04/2016
        /// Actualizacion:--/--/----
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static String correlativoPG(CP0003PAGO DATA)
        {
            int cuenta = 0; string codID;
            try
            {
                using (var ctx = new RSCONCAR())
                {

                    cuenta = ctx.CP0003PAGO.Where(x => x.PG_CVANEXO == DATA.PG_CVANEXO && x.PG_CTIPDOC == DATA.PG_CTIPDOC && x.PG_CCODIGO == DATA.PG_CCODIGO && x.PG_DFECCOM.Value.Month == DATA.PG_DFECCOM.Value.Month).Count();

                }
            }
            catch (Exception)
            {

                throw;
            }

            cuenta = cuenta + 1;
            codID = DATA.PG_CFECCOM + "" + cuenta.ToString("D8");
            return codID;
        }
        /// <summary>
        /// Correlativo Pagos
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static String correlativoPG1(CP0003PAGO DATA)
        {
            int cuenta = 0; string codID;
            try
            {
                using (var ctx = new RSCONCAR())
                {

                    cuenta = ctx.CP0003PAGO.Where(x => x.PG_CVANEXO == DATA.PG_CVANEXO && x.PG_CTIPDOC == DATA.PG_CTIPDOC && x.PG_CCODIGO == DATA.PG_CCODIGO && x.PG_DFECCOM.Value.Month == DATA.PG_DFECCOM.Value.Month).Count();

                }
            }
            catch (Exception)
            {

                throw;
            }
            //YYYYMMDD -->20160809043407
            cuenta = cuenta + 1;
            codID = DATA.PG_CFECCOM + "" + cuenta.ToString("D6");
            return codID;
        }
        /// <summary>
        /// ELIMINA CHEQUES SUB23
        /// Autor:Edgar
        /// </summary>
        /// <param name="CCAB"></param>
        public static void Elimina(CP0003PAGO CCAB)
        {
            var ctx = new RSCONCAR();
            var sql = "Delete CP0003PAGO  where PG_CVANEXO = @PG_CVANEXO and PG_CCODIGO = @PG_CCODIGO and PG_CTIPDOC = @PG_CTIPDOC and PG_CNUMDOC = @PG_CNUMDOC and PG_CORDKEY = @PG_CORDKEY and PG_CSUBDIA = @PG_CSUBDIA";

            ctx.Database.ExecuteSqlCommand(sql,
              new SqlParameter("PG_CVANEXO", CCAB.PG_CVANEXO),
              new SqlParameter("PG_CCODIGO", CCAB.PG_CCODIGO),
              new SqlParameter("PG_CTIPDOC", CCAB.PG_CTIPDOC),
              new SqlParameter("PG_CNUMDOC", CCAB.PG_CNUMDOC),
              new SqlParameter("PG_CORDKEY", CCAB.PG_CORDKEY),
              new SqlParameter("PG_CSUBDIA", CCAB.PG_CSUBDIA));
        }
        /// <summary>
        /// TXT PAGOS TELEMATICOS
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<vista_pago> cabeceraTxt(vista_pago DATA)
        {
            var proveedor = new CP0003MAES();
            proveedor.AC_CVANEXO = DATA.PG_CVANEXO;
            proveedor.AC_CCODIGO = DATA.PG_CCODIGO;
            proveedor.AC_CABREVI = DATA.CT_BANCO;//NOMBRE DEL BANCO

            var detalleComp = new CT0003COMD16();
            detalleComp.DSUBDIA = DATA.PG_CSUBDIA;
            detalleComp.DCOMPRO = DATA.PG_CNUMCOM;
            detalleComp.DCODANE = DATA.CT_CNUMCTA;
            //detalleComp.DTIPDOC = "WI";

            var miCompCH = new CP0003VARI();
            miCompCH.CH_CNUMCTA = DATA.CT_CNUMCTA;
            miCompCH.CH_CNUMCHE = CT0003COMD16.listadetalle_le(detalleComp).Select(x => x.DNUMDOC).FirstOrDefault().ToString().Trim();
            miCompCH.CH_CFECCHE = CT0003COMD16.listadetalle_le(detalleComp).Select(x => x.DFECCOM).FirstOrDefault().ToString().Trim();


            var BASE_BANCO = (DATA.CT_BANCO == "CREDITO" ? "B0" : (DATA.CT_BANCO == "BBVA" || DATA.CT_BANCO == "CONTINENTA" ? "B1" : (DATA.CT_BANCO == "INTERBANK" ? "B2" : (DATA.CT_BANCO == "SCOTIABANK" ? "B1" : ""))));
            var lista = new List<vista_pago>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from a in ctx.CP0003PAGO.Where(x => (x.PG_CVANEXO == DATA.PG_CVANEXO
                             && x.PG_CCODIGO == DATA.PG_CCODIGO && x.PG_CSUBDIA == DATA.PG_CSUBDIA && x.PG_CNUMCOM == DATA.PG_CNUMCOM))
                             group new { a } by new
                             {
                                 a.PG_CCODIGO,
                                 a.PG_CSUBDIA,
                                 a.PG_CNUMCOM,
                                 a.PG_CCODMON,
                                 a.PG_DFECCOM
                             } into g
                             select new
                             {
                                 codigo = g.Key.PG_CCODIGO,
                                 subdia = g.Key.PG_CSUBDIA,
                                 compro = g.Key.PG_CNUMCOM,
                                 moneda = g.Key.PG_CCODMON,
                                 fecpro = g.Key.PG_DFECCOM,
                                 importeT = (g.Key.PG_CCODMON == "MN" ? (decimal)g.Sum(p => p.a.PG_NIMPOMN) : (decimal)g.Sum(p => p.a.PG_NIMPOMN)),
                             }).ToList()
                           .Select(c => new vista_pago()
                           {   //CAMBIAR 700 PARAMETROS
                               BA_TIPREG = tabla_parametros.ListarParametroID2(BASE_BANCO, "TIPREG").AF_TDESCRI2,//1
                               AC_CTIPPRO = (BASE_BANCO == "B0" ?
                                                CP0003MAES.listarMaestroxunID(proveedor).AC_CTIPPRO.Trim() : 
                                                (BASE_BANCO == "B1" ? tabla_parametros.ListarParametroID2(BASE_BANCO, "TIPCCA").AF_TDESCRI2 : "")),/*Tipo de Proceso BBVA NUEVO*/
                               PG_CANTABO = ctx.CP0003PAGO.Where(y => y.PG_CCODIGO == DATA.PG_CCODIGO
                                            && y.PG_CSUBDIA == DATA.PG_CSUBDIA
                                            && y.PG_CNUMCOM == DATA.PG_CNUMCOM).Count().ToString("D" + tabla_parametros.ListarParametroID2(BASE_BANCO, "CANABO").AF_TDESCRI2),
                               PG_CFECCOM2 = (BASE_BANCO == "B1" ? (tabla_parametros.ListarParametroID2(BASE_BANCO, "TIPCCA").AF_TDESCRI2 == "F" ? Convert.ToString(c.fecpro) : string.Empty.PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "FECPRO").AF_TDESCRI2), ' ')) : String.Format("{0:yyyyMMdd}", c.fecpro)),//OPCIONAL BBVA
                               PG_HORPRO = "",//SI ES H:HORA<-AC_CTIPPRO
                               PG_CCODMON = (BASE_BANCO == "B0" ? (c.moneda == "MN" ? "0001" : 
                                                (c.moneda == "US" ? "1001" : "")) : (BASE_BANCO == "B1" ? (c.moneda == "MN" ? "PEN" : (c.moneda == "US" ? "USD" : "")) : "")),//CODIGO MONEDA
                               PG_CTACORR = CP0003CUBA.ListarDatosBancoIDC(DATA.CT_CNUMCTA).PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "NUMCAR").AF_TDESCRI2), ' '),//
                               PG_NIMPORT = (BASE_BANCO=="B0"? Convert.ToString(CP0003VARI.listarUnRegistro(miCompCH).CH_NIMPOCH).PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "MONTOT").AF_TDESCRI2), '0'): Convert.ToString(CP0003VARI.listarUnRegistro(miCompCH).CH_NIMPOCH).Replace(".", "").PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "MONTOT").AF_TDESCRI2), '0')), //: (c.importeT).ToString().PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "MONTOT").AF_TDESCRI2), '0')),//(c.moneda == "MN" ? DATA.PG_NIMPOMN: DATA.PG_NIMPOMN),
                               PG_DESCRIP = (BASE_BANCO == "B1" ? /*Pago Prooved. FECHA PROCESO*/
                                            (tabla_parametros.ListarParametroID2(BASE_BANCO, "REFPLA").AF_TDESCRI3.Trim() + " " + String.Format("{0:dd-MM-yy}", c.fecpro)).PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "REFPLA").AF_TDESCRI2)) :
                                            CP0003MAES.listarMaestroxunID(proveedor).AC_CNOMBRE.ToString().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "REFPLA").AF_TDESCRI2), ' ')),
                               PG_CSUBDIA = c.subdia,/*22*/
                               PG_CNUMCOM = c.compro,/*NUMERO*/
                               CT_CTCARGO = CP0003MAES.obtiene_banco_cuenta2(proveedor, c.moneda).First().CT_CTCARGO,//tabla_parametros.ListarParametroID("",""),//PROVEEDOR
                               CT_CTOTAL = (BASE_BANCO.Trim() == "B1" ? "" : Convert.ToString(Convert.ToInt64(CP0003CUBA.ListarDatosBancoIDC(DATA.CT_CNUMCTA)) + Convert.ToInt64(CP0003MAES.obtiene_banco_cuenta2(proveedor, c.moneda).First().CT_CTCARGO)).PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "TOTCON").AF_TDESCRI2), '0')),
                               PG_FLAG = tabla_parametros.ListarParametroID2(BASE_BANCO, "FLAEXO").AF_TDESCRI2 /*BBVA:S ->FLAG*/
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return lista;
        }
        /// <summary>
        /// Pagos Telematicos Detalle 
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<vista_pago> detalleTxt(vista_pago DATA)
        {

            var proveedor = new CP0003MAES();
            proveedor.AC_CVANEXO = DATA.PG_CVANEXO;
            proveedor.AC_CCODIGO = DATA.PG_CCODIGO;
            proveedor.AC_CABREVI = DATA.CT_BANCO;
            var BASE_BANCO = (DATA.CT_BANCO == "CREDITO" ? "B0" : (DATA.CT_BANCO == "BBVA" || DATA.CT_BANCO == "CONTINENTA" ? "B1" : (DATA.CT_BANCO == "INTERBANK" ? "B2" : (DATA.CT_BANCO == "SCOTIABANK" ? "B3" : ""))));

            var lista = new List<vista_pago>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from a in ctx.CP0003PAGO.Where(x => (x.PG_CVANEXO == DATA.PG_CVANEXO
                             && x.PG_CCODIGO == DATA.PG_CCODIGO && x.PG_CSUBDIA == DATA.PG_CSUBDIA && x.PG_CNUMCOM == DATA.PG_CNUMCOM))
                             select new
                             {
                                 PG_CCODMON = a.PG_CCODMON,
                                 PG_CTIPDOC = a.PG_CTIPDOC,
                                 PG_MINUDOC = a.PG_CNUMDOC.Replace("-", "0"),
                                 PG_CNUMDOC = (BASE_BANCO=="B3"? a.PG_CTIPDOC+"/"+a.PG_CNUMDOC:(BASE_BANCO == "B1" || BASE_BANCO=="B2" ? "" : a.PG_CTIPDOC + "") + a.PG_CNUMDOC),/*VALIDACION DE BANCO BBVA*/
                                 PG_CNUMDOC1 = a.PG_CNUMDOC,
                                 PG_NIMPORT = (a.PG_CCODMON == "MN" ? a.PG_NIMPOMN : a.PG_NIMPOUS),
                                 /*PG_IMRCOMD = ctx.CT0003COMD16.Where(y => y.DSUBDIA == DATA.PG_CSUBDIA
                                            && y.DCOMPRO == DATA.PG_CNUMCOM
                                            && y.DCUENTA == "421142").Select(m => m.DIMPORT).FirstOrDefault()*/
                             }).ToList().Select(c => new vista_pago()
                             {
                                 BA_TIPREG = (BASE_BANCO=="B3"? 
                                                string.Empty.PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "TIPREG").AF_TDESCRI2),' ') 
                                                :Convert.ToString(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "TIPREG").AF_TDESCRI2) + 1)),/*BCP-BBVA*/
                                 BA_TIPREG1 = Convert.ToString(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "TIPREG").AF_TDESCRI2) + 2),/*BCP-BBVA*/
                                 BA_TIPREG2 = tabla_parametros.ListarParametroID2(BASE_BANCO, "DTIREG").AF_TDESCRI2.PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DTIREG").AF_TDESCRI3), '0'),
                                 AC_CTIPPRO = (BASE_BANCO=="B3"? CP0003MAES.listarMaestroxunID(proveedor).AC_CTIPPAG.Trim():/*3:cuenta de ahorros - .PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DTICAB").AF_TDESCRI2), ' ')*/
                                                (BASE_BANCO=="B2"? CP0003MAES.listarMaestroxunID(proveedor).AC_CTIPPRK.Trim():(BASE_BANCO == "B1" ? CP0003MAES.listarMaestroxunID(proveedor).AC_CFORPG7.Trim() : 
                                                    CP0003MAES.listarMaestroxunID(proveedor).AC_CTIPPRO.Trim()))),/*DTICAB:TIPO CUENTA ABONO|002*/
                                 PG_CTIPDOC = (c.PG_CTIPDOC == "FT" ? "F" : ""),/*DDTDPA*/
                                 PG_NDOCPAG = c.PG_MINUDOC.Trim().PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DDNDPA").AF_TDESCRI2), '0'),/*NUMERO DOCUMENTO A PAGAR*/
                                 DFECVEN2 = (BASE_BANCO=="B3"?/*FECHA VENCIMIENTO*/
                                            String.Format("{0:yyyyMMdd}", (ctx.CT0003COMD16.Where(y => y.DSUBDIA.Trim() == DATA.PG_CSUBDIA.Trim()
                                            && y.DCOMPRO.Trim() == DATA.PG_CNUMCOM.Trim() && y.DNUMDOC.Trim() == c.PG_CNUMDOC1.Trim()
                                            ).Select(m => m.DFECCOM2).FirstOrDefault())).PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "FECPRO").AF_TDESCRI2), ' ')
                                            : String.Format("{0:yyyyMMdd}", (ctx.CT0003COMD16.Where(y => y.DSUBDIA.Trim() == DATA.PG_CSUBDIA.Trim()
                                            && y.DCOMPRO.Trim() == DATA.PG_CNUMCOM.Trim() && y.DNUMDOC.Trim() == c.PG_CNUMDOC1.Trim()
                                            ).Select(m => m.DFECVEN2).FirstOrDefault()))),
                                 CT_CTCARGO = (BASE_BANCO=="B3"?CP0003MAES.obtiene_banco_cuenta2(proveedor, c.PG_CCODMON).First().CT_CTCARGO.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "NUMCAR").AF_TDESCRI2), ' ') :
                                                (BASE_BANCO=="B2"? CP0003MAES.obtiene_banco_cuenta2(proveedor, c.PG_CCODMON).First().CT_CTCARGO.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DNUCTA").AF_TDESCRI2), ' ') :
                                                    CP0003MAES.obtiene_banco_cuenta2(proveedor, c.PG_CCODMON).First().CT_CTCARGO.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DNUCTA").AF_TDESCRI2), ' '))),
                                 AU_MODPAG = (BASE_BANCO=="B2"? CP0003MAES.listarMaestroxunID(proveedor).AC_CTIPABK.Trim() : tabla_parametros.ListarParametroID2(BASE_BANCO, "DMOPAG").AF_TDESCRI2),//PUEDE VARIA 1o2
                                 AV_CDOCIDE = (BASE_BANCO == "B1" ? /*R-RUC:11 digitos|L-DNI/LE:8 digitos*/
                                                    (CP0003MAES.listarMaestroxunID(proveedor).AV_CDOCIDE.Trim() == "6" ? "R" : "") :
                                                    (CP0003MAES.listarMaestroxunID(proveedor).AV_CDOCIDE.Trim())), /*DOCUMENTO  - RUC*/
                                 AC_CCODIGO = CP0003MAES.listarMaestroxunID(proveedor).AC_CCODIGO.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DNDPRO").AF_TDESCRI2), ' '), /*DOCUMENTO  - RUC*/
                                 AC_CODOPRO = string.Empty.PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DCODPR").AF_TDESCRI2), ' '),//ESPACIOS EN BLANCO SI NO ES MENOR DE EDAD
                                 AC_CNOMBRE = (BASE_BANCO=="B2"? CapaNegocio.Cls_Utilidades.miFuncionRS(CP0003MAES.listarMaestroxunID(proveedor).AC_CNOMBRE.Trim(),Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DNOPRO").AF_TDESCRI2)) :
                                                CP0003MAES.listarMaestroxunID(proveedor).AC_CNOMBRE.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DNOPRO").AF_TDESCRI2), ' ')),
                                 AV_CTIPTRA = CP0003MAES.listarMaestroxunID(proveedor).AV_CTIPTRA.Trim(),/*B2:TIPO TRABAJADOR*/
                                 PG_REFEREN = c.PG_CNUMDOC.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DREBEN").AF_TDESCRI2), ' '),/*DREEMP*/
                                 PG_REFEREN1 =(BASE_BANCO=="B3"? CapaNegocio.Cls_Utilidades.miCadenaLimite(CP0003MAES.listarMaestroxunID(proveedor).AC_CNOMBRE.Trim(),30).PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DREEMP").AF_TDESCRI2), ' ') : 
                                               (BASE_BANCO=="B2"? CP0003MAES.listarMaestroxunID(proveedor).AC_CCODIGO.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DREEMP").AF_TDESCRI2), ' ') :
                                                c.PG_CNUMDOC.Trim().PadRight(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DREEMP").AF_TDESCRI2), ' '))),
                                 PG_CCODMON = (BASE_BANCO=="B2"?(c.PG_CCODMON=="MN"?"01":"10"):(c.PG_CCODMON == "MN" ? "0001" : (c.PG_CCODMON == "US" ? "1001" : ""))),
                                 PG_NIMPORT = (BASE_BANCO=="B2" || BASE_BANCO=="B3"?
                                                Convert.ToString(c.PG_NIMPORT - (ctx.CT0003COMD16.Where(y => y.DSUBDIA.Trim() == DATA.PG_CSUBDIA.Trim() && y.DCOMPRO.Trim() == DATA.PG_CNUMCOM.Trim() && y.DNUMDOC.Trim() == c.PG_CNUMDOC1.Trim()
                                                                              && y.DCUENTA.Trim() == "401142").Select(m => m.DIMPORT).FirstOrDefault())).Replace(".", "").PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DIMPAB").AF_TDESCRI2), '0'):
                                                Convert.ToString(c.PG_NIMPORT- (ctx.CT0003COMD16.Where(y => y.DSUBDIA.Trim() == DATA.PG_CSUBDIA.Trim() && y.DCOMPRO.Trim() == DATA.PG_CNUMCOM.Trim() && y.DNUMDOC.Trim()==c.PG_CNUMDOC1.Trim()
                                                                             && y.DCUENTA.Trim() == "401142").Select(m => m.DIMPORT).FirstOrDefault())).PadLeft(Convert.ToInt32(tabla_parametros.ListarParametroID2(BASE_BANCO, "DIMPAB").AF_TDESCRI2), '0')),
                                 PG_NIMPORTR = Convert.ToString("0"),
                                 AC_CVALRUT = (CP0003MAES.listarMaestroxunID(proveedor).AC_CVALRUT.Trim() == "1" ? "S" : "N"),/*S = Si desea validar IDC vs Cuenta*/
                                 PG_FLAG = tabla_parametros.ListarParametroID2(BASE_BANCO, "FLAEXO").AF_TDESCRI2
                             }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return lista;

        }
    }
}
