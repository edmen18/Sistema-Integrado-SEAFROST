namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.Data.SqlClient;
    using System.Data.Entity.Validation;
    using System.Diagnostics;


    public partial class CP0003CHEQ
    {
      
        [Column(Order = 0)]
        [StringLength(18)]
        public string CH_CNUMCTA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CH_CNUMCHE { get; set; }

        [Column(Order = 2)]
        [StringLength(6)]
        public string CH_CFECCHE { get; set; }

      
        [Column(Order = 3)]
        [StringLength(40)]
        public string CH_CNOMCHE { get; set; }

        
        [Column(Order = 4)]
        [StringLength(6)]
        public string CH_CFECCOM { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string CH_CSUBDIA { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(6)]
        public string CH_CNUMCOM { get; set; }

      
        [Column(Order = 7, TypeName = "numeric")]
        public decimal CH_NIMPOCH { get; set; }

        
        [Column(Order = 8)]
        [StringLength(2)]
        public string CH_CCODMON { get; set; }

      
        [Column(Order = 9)]
        [StringLength(1)]
        public string CH_CVANEXO { get; set; }

      
        [Column(Order = 10)]
        [StringLength(18)]
        public string CH_CCODIGO { get; set; }

      
        [Column(Order = 11)]
        [StringLength(1)]
        public string CH_CESTADO { get; set; }

      
        [Column(Order = 12)]
        [StringLength(6)]
        public string CH_CFECEST { get; set; }

       
        [Column(Order = 13)]
        [StringLength(5)]
        public string CH_CUSUARI { get; set; }

        public DateTime? CH_DFECHA { get; set; }

        
        [Column(Order = 14)]
        [StringLength(6)]
        public string CH_CHORA { get; set; }

      
        [Column(Order = 15)]
        [StringLength(12)]
        public string CH_CCTACON { get; set; }

      
        [Column(Order = 16)]
        [StringLength(1)]
        public string CH_CSITUAC { get; set; }

      
        [Column(Order = 17)]
        [StringLength(2)]
        public string CH_DOCREFT { get; set; }

      
        [Column(Order = 18)]
        [StringLength(20)]
        public string CH_DOCREFN { get; set; }

      
        [Column(Order = 19)]
        [StringLength(8)]
        public string CH_CCOGAST { get; set; }

       
        [Column(Order = 20)]
        [StringLength(50)]
        public string CH_CCONCEP { get; set; }

      
        [Column(Order = 21)]
        [StringLength(6)]
        public string CH_CFECDIF { get; set; }

       
        [Column(Order = 22, TypeName = "numeric")]
        public decimal CH_NTIPCAM { get; set; }

        public DateTime? CH_DFECCHE { get; set; }

        public DateTime? CH_DFECCOM { get; set; }

        public DateTime? CH_DFECEST { get; set; }

        public DateTime? CH_DFECDIF { get; set; }

        [StringLength(100)]
        public string CH_CNOMCH2 { get; set; }

       
        [Column(Order = 23)]
        [StringLength(30)]
        public string CH_CNOMFR1 { get; set; }

       
        [Column(Order = 24)]
        [StringLength(30)]
        public string CH_CNOMFR2 { get; set; }

      
        [Column(Order = 25)]
        [StringLength(1)]
        public string CH_CFLGNEG { get; set; }

        /// <summary> EDGAR MENDOZA MENDIVES
        /// PARA LA INSERCION EN LA TABLA CHEQUE
        /// </summary> CREADA EL 06/08/2016 A LAS 11:25 AM.
        /// <param name="datos"></param>
        /// <returns></returns>
        public static Boolean insertaCabecera(CP0003CHEQ datos)
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


        public static List<VIST_CHEQUE> IMPRESIONCHEQUE(CP0003CHEQ COM)
        {
            var Listarep = new List<VIST_CHEQUE>();
            using (var ctx = new RSCONCAR())
            {
                Listarep = (from a in ctx.CP0003CHEQ
                            join la in ctx.CT0003COMD16
                            on a.CH_CNUMCOM.Trim() equals la.DCOMPRO.Trim()                         
                            where
                              a.CH_CNUMCHE.Trim() == COM.CH_CNUMCHE.Trim() && a.CH_CSUBDIA.Trim()== COM.CH_CSUBDIA.Trim() && a.CH_CNUMCOM.Trim()== COM.CH_CNUMCOM.Trim()
                               && la.DSUBDIA.Trim() == COM.CH_CSUBDIA.Trim() && la.DCOMPRO.Trim() == COM.CH_CNUMCOM.Trim()
                            select new
                            {
                                data1 = a.CH_CNUMCTA,
                                data2 = a.CH_CNOMCH2,
                                data3 = a.CH_CNOMCHE,
                                data4 = a.CH_CSUBDIA,
                                data5 = a.CH_CNUMCOM,
                                data6 = a.CH_CNUMCHE,
                                data7 = a.CH_DFECCHE,
                                data8 = a.CH_DFECDIF,
                                data9 = a.CH_CCODMON,
                                data10 = a.CH_NTIPCAM,
                                data11 = a.CH_NIMPOCH,
                                data12 = a.CH_CCONCEP,
                                DATA13 = a.CH_DFECCOM,
                                data20 = la.DCUENTA,
                                data14 = la.DCODANE,
                                data15 = la.DTIPDOC,//
                                data16 = la.DAREA,
                                data17 = la.DXGLOSA,
                                data18 = la.DIMPORT,
                                data19 = la.DDH,
                                data21= la.DNUMDOC,
                                data22=la.DSECUE,
                                data23= la.DVANEXO,
                                data24= la.DCENCOS,
                                data25=a.CH_CUSUARI,

                            }).ToList().
                 Select(c => new VIST_CHEQUE()
                 {
                     CH_CNUMCTA = ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA.Trim() == c.data1.Trim()).Select(x => x.CT_CDESCTA).FirstOrDefault(),
                     ANOMBREDE = c.data2,
                     PROVEEDOR = c.data3,
                     VOU = c.data4,
                     CHER = c.data5,
                     NUMCHEQUE = c.data6,
                     GIRADO = Convert.ToString(c.data7).Substring(0, 10),
                     DIFERIDO = (Convert.ToString(c.data8).Trim()!=""? Convert.ToString(c.data8).Substring(0, 10): Convert.ToString(c.data8)),
                     MONEDA = c.data9,
                     TIPODACAMBIO = Convert.ToString(c.data10),
                     MONTOCHEQUE = Convert.ToString(c.data11),
                     CONCEPTO = c.data12,
                     FECHACOMPROBANTE = Convert.ToString(c.DATA13).Substring(0,10),
                     DCUENTA = c.data20,
                     DCODANE = c.data14,
                     DOCUMENTO = c.data15 + "-" + c.data21,
                     DAREA = c.data16,
                     DXGLOSA = c.data17,
                     DMIMPORT = Convert.ToString(c.data18),
                     DDH = c.data19,
                     ADICIONAL = ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA.Trim() == c.data1.Trim()).Select(x => x.CT_CNOMBAN).FirstOrDefault(),
                     MONTOVOUCHER=Convert.ToString(ctx.CT0003COMC16.Where(x=>x.CCOMPRO==c.data5 && x.CSUBDIA==c.data4).Select(x=>x.CTOTAL).FirstOrDefault()),
                     secuencia= c.data22,
                     ANEXO=c.data25,
                     CENCOS=c.data24,
                     son= CapaNegocio.Cls_Utilidades.NumeroLetras((c.data11), c.data9)

                 }).OrderBy(X=>X.secuencia).ToList();

            }
            return Listarep;
        }
        /// <summary>
        /// consulta un cheque
        /// </summary>
        /// <param name="CCAB"></param>
        /// 
        public static List<CP0003CHEQ> ConsultaCheque(CP0003CHEQ COM)
        {
            var Listarep = new List<CP0003CHEQ>();
            using (var ctx = new RSCONCAR())
            {
                Listarep = ctx.CP0003CHEQ.Where( a =>
                             a.CH_CNUMCHE.Trim() == COM.CH_CNUMCHE.Trim() && a.CH_CSUBDIA.Trim() == COM.CH_CSUBDIA.Trim() && a.CH_CNUMCTA.Trim() == COM.CH_CNUMCTA.Trim()
                       ).ToList();
            }
            return Listarep;
        }
        /// <summary>
        /// EDGAR MENDOZA MENDIVES 
        /// </summary>FILTRO PARA CONSULTAR CHEQUES
        /// <param name="COM"></param>
        /// <returns></returns>
     
        public static List<CP0003CHEQ> ConsultaChequeParametros(CP0003CHEQ COM)
        {
            var alumnos = new List<CP0003CHEQ>();

            try
            {
                using (var ctx = new RSCONCAR())
                {

                    alumnos = ctx.Database.SqlQuery<CP0003CHEQ>("select * from  CP0003CHEQ  where (CH_CNUMCHE between @cod1 and @cod2) and CH_CSUBDIA=@subdiario and CH_CNUMCTA=@nuncta order by CH_DFECHA desc ",
                           new SqlParameter("cod1", COM.CH_CNUMCHE), new SqlParameter("cod2", COM.CH_CNOMCHE), new SqlParameter("subdiario", COM.CH_CSUBDIA), new SqlParameter("nuncta", COM.CH_CNUMCTA)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<CP0003CHEQ> CONSULTATODOS(CP0003CHEQ COM)
        {
            var Listarep = new List<CP0003CHEQ>();
            using (var ctx = new RSCONCAR())
            {
                Listarep = ctx.CP0003CHEQ.Where(a =>
                            a.CH_CSUBDIA.Trim() == COM.CH_CSUBDIA.Trim() ).ToList();
            }
            return Listarep;
        }

        public static void Elimina(CP0003CHEQ CCAB)
        {
            using (var ctx = new RSCONCAR())
            {
                ctx.Entry(new CP0003CHEQ { CH_CNUMCHE = CCAB.CH_CNUMCHE, CH_CSUBDIA = CCAB.CH_CSUBDIA, CH_CNUMCOM= CCAB.CH_CNUMCOM }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

    }
}
