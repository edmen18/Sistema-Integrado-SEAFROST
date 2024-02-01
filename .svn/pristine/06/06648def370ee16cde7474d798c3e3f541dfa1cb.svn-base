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

    public class vista_consultaStock
    {
        public string SK_CALMA { get; set; }
        public string SK_CCODIGO { get; set; }
        public string AR_CDESCRI { get; set; }
        public string AR_CUNIDAD { get; set; }
        public decimal SK_NSKDIS { get; set; }

        public decimal? stock_minimo { get; set; }
        public decimal? eoq { get; set; }

        public decimal? AR_NMARGE1 { get; set; }
        public decimal? AR_NMARGE2 { get; set; }


    }


    public partial class AL0003STOC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string SK_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string SK_CCODIGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSKDIS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSKCOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSKMIN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSKMAX { get; set; }

        [StringLength(4)]
        public string SK_CMESPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NPREUNI { get; set; }

        public DateTime? SK_DFECMOV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSKMES { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSKVAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NPUNREP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NSEMREP { get; set; }

        [StringLength(1)]
        public string SK_CTIPREP { get; set; }

        [StringLength(10)]
        public string SK_CUBIALM { get; set; }

        [StringLength(10)]
        public string SK_CUBIAL2 { get; set; }

        [StringLength(10)]
        public string SK_CUBIAL3 { get; set; }

        [StringLength(10)]
        public string SK_CUBIAL4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SK_NLOTCOM { get; set; }

        [StringLength(3)]
        public string SK_CTIPCOM { get; set; }

        public static List<AL0003STOC> ListarStockID(string AL, string COD, string TR)
        {   //TR:TIPO REGISTRO->E|S
            List<AL0003STOC> listaA = new List<AL0003STOC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listaA = ctx.AL0003STOC.Where(x => x.SK_CALMA == AL && x.SK_CCODIGO == COD && (TR == "E" ? x.SK_NSKDIS >= 0 : x.SK_NSKDIS != 0)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }

        public static List<vista_consultaStock> retornaListaConsultaStock(AL0003STOC TOC)
        {

            using (var ctx = new RSFACAR())
            {


                var data =
                       (
                      from A in ctx.AL0003STOC
                      join B in ctx.AL0003ARTI on new { SK_CCODIGO = A.SK_CCODIGO } equals new { SK_CCODIGO = B.AR_CCODIGO }
                      where
                        A.SK_CALMA == TOC.SK_CALMA
                         && 
                      ( TOC.SK_CCODIGO != string.Empty ? A.SK_CCODIGO == TOC.SK_CCODIGO : A.SK_CCODIGO != TOC.SK_CCODIGO)
                      &&
                      (TOC.SK_CTIPREP =="2"? A.SK_NSKDIS >0 : A.SK_NSKDIS>=0)
                      orderby
                        B.AR_CDESCRI.Trim()
                      select new
                      {
                        a=  A.SK_CALMA,
                        b=  A.SK_CCODIGO,
                        c=  B.AR_CDESCRI,
                        d=  B.AR_CUNIDAD,
                        e=  A.SK_NSKDIS,
                        f=B.AR_NMARGE1,
                        g=B.AR_NMARGE2
                      }

                       ).ToList()
                       .Select(c => new vista_consultaStock()
                       {
                           SK_CALMA = c.a,
                           SK_CCODIGO = c.b,
                           AR_CDESCRI = c.c,
                           AR_CUNIDAD = c.d,
                           SK_NSKDIS = c.e,
                           AR_NMARGE1=c.f,
                           AR_NMARGE2=c.g
                           //  stock_minimo = tabla_stockminimo.retornaStockMinimo(c.b.Trim() ).stock_minimo//,
                           // eoq= tabla_stockminimo.retornaStockMinimo(c.b.Trim()).eoq

                       }).ToList();

                return data;

            }



        }
        public static Boolean actualizaStock(AL0003STOC datos,string op)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var NALM = new AL0003ALMA();
            var data = new AL0003STOC { SK_CALMA = datos.SK_CALMA, SK_CCODIGO= datos.SK_CCODIGO.Trim() };
            var NSTOCK = new AL0003STOC();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    NSTOCK = ctx.AL0003STOC.Where(x => x.SK_CALMA == datos.SK_CALMA && x.SK_CCODIGO == datos.SK_CCODIGO.Trim()).FirstOrDefault();
                    if (NSTOCK == null)
                    {
                        ingresaStock(datos);
                    }
                    else
                    {
                        ctx.AL0003STOC.Attach(data);
                        if (op == "1")
                        {
                            data.SK_NSKDIS = Convert.ToDecimal(NSTOCK.SK_NSKDIS) + datos.SK_NSKDIS;
                            
                        }
                        else
                        {
                            data.SK_NSKDIS = Convert.ToDecimal(NSTOCK.SK_NSKDIS) - datos.SK_NSKDIS;
                        }
                        data.SK_DFECMOV = fechaA;
                        //ctx.Entry(data).State = EntityState.Modified;
                        ctx.Configuration.ValidateOnSaveEnabled = false;
                        ctx.SaveChanges();
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
                band = false;
            }
            return band;
        }

        //NUEVO
        public static Boolean ingresaStock(AL0003STOC SDATA)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(SDATA).State = EntityState.Added;
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
    }
}
