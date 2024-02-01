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

    public  class VISTA_AL0003REQD
    {
        public string RD_CITEM { get; set; }
        public string RD_CCODIGO { get; set; }
        public string RD_CDESCRI { get; set; }
        public string RD_CUNID { get; set; }
        public decimal? RD_NQPEDI { get; set; }
        public string RD_COBS { get; set; }
        public string RD_CCENCOS { get; set; }

        public string CCENCOSDESCRIP { get; set; }
        public string SOLICITANTE { get; set; }
        public string RD_CUSRCOM { get; set; }


    }
        public partial class AL0003REQD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string RD_CNROREQ { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string RD_CITEM { get; set; }

        [Required]
        [StringLength(25)]
        public string RD_CCODIGO { get; set; }

        [StringLength(50)]
        public string RD_CDESCRI { get; set; }

        [StringLength(3)]
        public string RD_CUNID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RD_NQPEDI { get; set; }

        [StringLength(6)]
        public string RD_CCENCOS { get; set; }

       
        [StringLength(40)]
        public string RD_COBS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RD_NQATEN { get; set; }

        [StringLength(1)]
        public string RD_CSITUA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RD_NQINGALM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RD_NQDESPA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NCANAPR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NPRUNMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NPRUNUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NPRU2MN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NPRU2US { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NTOTMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NTOTUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NDSCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NDESCTO { get; set; }

       
        [StringLength(5)]
        public string RD_CUSRAPR { get; set; }

        public DateTime? RD_DFUSAPR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RD_NCANALM { get; set; }

        [Required]
        [StringLength(1)]
        public string RD_CTR { get; set; }

        public DateTime? RD_DFECASG { get; set; }

        [Required]
        [StringLength(2)]
        public string RD_CCODCOM { get; set; }

        [Required]
        [StringLength(1)]
        public string RD_CFLGASG { get; set; }

        [Required]
        [StringLength(5)]
        public string RD_CUSRCOM { get; set; }



        public static List<AL0003REQD> obtenerRequerimientoPorNumeroYCodigo(string RD_CNROREQ,string RD_CCODIGO)
        {
            var alumnos = new List<AL0003REQD>();
            using (var ctx = new RSFACAR())
            {
                alumnos = ctx.AL0003REQD.Where(x => x.RD_CNROREQ == RD_CNROREQ && x.RD_CCODIGO== RD_CCODIGO).ToList();
            }

            return alumnos;
        }



        public static Boolean desapruebaRequerimiento(AL0003REQD alumno)
        {
            Boolean band = true;
            var cliente = new AL0003REQD { RD_CNROREQ = alumno.RD_CNROREQ, RD_CITEM = alumno.RD_CITEM };
            try
            {

                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQD.Attach(cliente);
                    cliente.RD_CSITUA = alumno.RD_CSITUA;

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
        public static Boolean apruebaRequerimiento(AL0003REQD alumno)
        {
            Boolean band = true;
            var cliente = new AL0003REQD { RD_CNROREQ = alumno.RD_CNROREQ ,RD_CITEM = alumno.RD_CITEM  };
            try
            {
                
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQD.Attach(cliente);
                    cliente.RD_CSITUA = alumno.RD_CSITUA;
                    
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

        public static Boolean apruebaRequerimientoAtendido(AL0003REQD alumno)
        {
            Boolean band = true;
            var cliente = new AL0003REQD { RD_CNROREQ = alumno.RD_CNROREQ, RD_CITEM = alumno.RD_CITEM };
            try
            {

                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQD.Attach(cliente);
                    cliente.RD_CSITUA = alumno.RD_CSITUA;
                    cliente.RD_NQATEN = alumno.RD_NQATEN;
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
        public static int CuentaDetalleReq(string numero)
        {
            int cuenta = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    cuenta =Convert.ToInt32 (  ctx.AL0003REQD.Where(x => x.RD_CNROREQ == numero).Max(x=>x.RD_CITEM));
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cuenta+1;
        }
        public static List<VISTA_AL0003REQD> ListarRequerimientosPorCodigo(AL0003REQD req)
        {
            var alumnos = new List<VISTA_AL0003REQD>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos =( from x in ctx.AL0003REQD.Where(x=> x.RD_CNROREQ==req.RD_CNROREQ).OrderBy(x=>x.RD_CITEM)
                        select new

                        {
                          RD_CITEM =x.RD_CITEM,
                          RD_CCODIGO=x.RD_CCODIGO,
                          RD_CDESCRI =x.RD_CDESCRI,
                          RD_CUNID=x.RD_CUNID,
                          RD_NQPEDI =x.RD_NQPEDI,
                          RD_COBS= x.RD_COBS,
                          COSTO =x.RD_CCENCOS,
                            DESCRIPCOSTO = ((from b in ctx.AL0003TABL
                                            where
                                              b.TG_CCOD == "10" && b.TG_CCLAVE== x.RD_CCENCOS
                                             select new
                                            {
                                                b.TG_CDESCRI
                                            }).FirstOrDefault().TG_CDESCRI),
                           SOLICITANTE = ((from b in ctx.AL0003TABL
                                           where
                                             b.TG_CCOD == "12" && b.TG_CCLAVE == x.RD_CUSRCOM
                                           select new
                                           {
                                               b.TG_CDESCRI
                                           }).FirstOrDefault().TG_CDESCRI),
                         codsolicitante= x.RD_CUSRCOM
                        }).ToList()
                        .Select(c => new VISTA_AL0003REQD()
                        {
                            RD_CITEM = c.RD_CITEM,
                            RD_CCODIGO = c.RD_CCODIGO,
                            RD_CDESCRI = c.RD_CDESCRI,
                            RD_CUNID = c.RD_CUNID,
                            RD_NQPEDI = c.RD_NQPEDI,
                            RD_COBS=c.RD_COBS,
                            RD_CCENCOS=c.COSTO,
                            CCENCOSDESCRIP = c.DESCRIPCOSTO ,
                            SOLICITANTE=c.SOLICITANTE,
                            RD_CUSRCOM = c.codsolicitante
                            
                        }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static Boolean EliminarDetalleRequerimientoTotal(AL0003REQD req)
        {

            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(new AL0003REQD { RD_CNROREQ = req.RD_CNROREQ }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
                //throw;
            }
            return band;
        }

        public static Boolean EliminarDetalleRequerimiento(AL0003REQD req)
        {

            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(new AL0003REQD { RD_CNROREQ = req.RD_CNROREQ, RD_CITEM= req.RD_CITEM }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
                //throw;
            }
            return band;
        }
        public static Boolean insertaRequerimiento(AL0003REQD alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(alumno).State = EntityState.Added;
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

        public static Boolean modificarRequerimiento(AL0003REQD alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(alumno).State = EntityState.Modified;
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
