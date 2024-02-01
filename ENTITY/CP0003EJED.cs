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
    using System.Data;


    public partial class CP0003EJED
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string GD_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string GD_CNUMOPE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string GD_CSECUE { get; set; }

       
        [StringLength(1)]
        public string GD_CVANEXO { get; set; }

       
        [StringLength(18)]
        public string GD_CCODIGO { get; set; }

       
        [StringLength(2)]
        public string GD_CTIPDOC { get; set; }

       
        [StringLength(20)]
        public string GD_CNUMDOC { get; set; }

        public DateTime? GD_DFECPRO { get; set; }

        public DateTime? GD_DFECDOC { get; set; }

        public DateTime? GD_DFECVEN { get; set; }

      
        [StringLength(2)]
        public string GD_CMONCAR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NORPROG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NTIPCAM { get; set; }

      
        [StringLength(2)]
        public string GD_CCODMON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NUSPROG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NMNPROG { get; set; }

       
        [StringLength(1)]
        public string GD_CTIPCTA { get; set; }

      
        [StringLength(8)]
        public string GD_CTIPPRO { get; set; }

       
        [StringLength(20)]
        public string GD_CNUMCTA { get; set; }

      
        [StringLength(4)]
        public string GD_CSUBDIA { get; set; }

       
        [StringLength(6)]
        public string GD_CCOMPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NMNRETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NUSRETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NORRETE { get; set; }

       
        [StringLength(1)]
        public string GD_CRETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NPORRE { get; set; }

       
        [StringLength(8)]
        public string GD_CTASDET { get; set; }

      
        [StringLength(4)]
        public string GD_CSUBCOM { get; set; }

       
        [StringLength(6)]
        public string GD_CNUMCOM { get; set; }

      
        [StringLength(6)]
        public string GD_CSECCOM { get; set; }

      
        [StringLength(2)]
        public string GD_CTDREF { get; set; }

      
        [StringLength(20)]
        public string GD_CNDREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GD_NTCORI { get; set; }

      
        [StringLength(20)]
        public string GD_CNOCONS { get; set; }

        public static Boolean insertar(CP0003EJED DATA)
        {
            Boolean band = true;
        var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(DATA).State = EntityState.Added;
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

        public static List<CP0003EJED> LISTARTTODOS(string dato) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003EJED>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJED
                               where a.GD_CNUMOPE.Trim() == dato.Trim()
                               select new
                               {
                                   GD_CVANEXO = a.GD_CVANEXO,
                                   GD_CCODIGO = a.GD_CCODIGO,
                                   GD_CTIPDOC = a.GD_CTIPDOC,
                                   GD_CNUMDOC = a.GD_CNUMDOC,
                                   GD_DFECDOC = a.GD_DFECDOC,
                                   GD_DFECVEN = a.GD_DFECVEN,
                                   GD_CMONCAR = a.GD_CMONCAR,
                                   GD_NORPROG = a.GD_NORPROG,
                                   GD_NORRETE = a.GD_NORRETE,
                                   GD_CRETE = a.GD_CRETE,
                                   GD_NMNPROG = a.GD_NMNPROG,
                                   GD_CTASDET = a.GD_CTASDET,
                                   GD_CSUBDIA=a.GD_CSUBDIA,
                                   GD_CCOMPRO=a.GD_CCOMPRO,
                                   GD_CNUMCOM=a.GD_CNUMCOM,
                                   GD_CSUBCOM=a.GD_CSUBCOM,
                                   GD_CNOPEDE=a.GD_CNOCONS,
                                   PROVEEDOR = ((from b in ctx.CP0003MAES
                                                 where b.AC_CCODIGO.Trim() == a.GD_CCODIGO.Trim()
                                                 select new { b.AC_CNOMBRE }).FirstOrDefault().AC_CNOMBRE),
                                   GD_CSECUE = a.GD_CSECUE,
                                   orden= ((from b in ctx.CP0003CART
                                            where b.CP_CNUMDOC.Trim() == a.GD_CNDREF.Trim() && b.CP_CVANEXO.Trim()==a.GD_CVANEXO.Trim()
                                            && b.CP_CCODIGO.Trim()==a.GD_CCODIGO.Trim()
                                            select new { b.CP_CNDOCRE }).FirstOrDefault().CP_CNDOCRE),

                               }).ToList()
                           .Select(c => new CP0003EJED()
                           {
                               GD_CVANEXO = c.GD_CVANEXO,
                               GD_CCODIGO = c.GD_CCODIGO,
                               GD_CNDREF = c.PROVEEDOR,
                               GD_CTIPDOC = c.GD_CTIPDOC,
                               GD_CNUMDOC = c.GD_CNUMDOC,
                               GD_DFECDOC = c.GD_DFECDOC,
                               GD_DFECVEN = c.GD_DFECVEN,
                               GD_CMONCAR = c.GD_CMONCAR,
                               GD_NORPROG = c.GD_NORPROG,
                               GD_NORRETE = c.GD_NORRETE,
                               GD_CRETE = c.GD_CRETE,
                               GD_NMNPROG = c.GD_NMNPROG,
                               GD_CTASDET = c.GD_CTASDET + "-" + ctx.CT0003TAGE.Where(x => x.TCLAVE.Trim() == c.GD_CTASDET.Trim() && x.TCOD.Trim() == "28").Select(x => x.TDESCRI.Trim()).FirstOrDefault(),
                               GD_CSECUE = c.GD_CSECUE,
                               GD_CSUBDIA = c.GD_CSUBDIA,
                               GD_CCOMPRO = c.GD_CCOMPRO,
                               GD_CNUMCOM = c.GD_CNUMCOM,
                               GD_CSUBCOM = c.GD_CSUBCOM,
                               GD_CNOCONS = c.GD_CNOPEDE,
                               GD_CCODAGE=c.orden,

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }
        // PARA ACTUALIZAR LA CONSTANCIA EMITIDA POR LA SUNAT
        public static void ActualizaConstancia(CP0003EJED COM)
        {
            var orden = new CP0003EJED { GD_CCODAGE = COM.GD_CCODAGE, GD_CNUMOPE=COM.GD_CNUMOPE, GD_CSECUE=COM.GD_CSECUE };

            using (var ctx = new RSCONCAR())
            {
                ctx.CP0003EJED.Attach(orden);
                orden.GD_CNOCONS = COM.GD_CNOCONS;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
               
            }
        }

        public static List<CP0003EJED> LISTARTTODOSCONST(string dato) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003EJED>();
          
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJED
                               where a.GD_CNUMOPE.Trim() == dato.Trim() && (a.GD_CNOCONS.Trim() == "" || a.GD_CNOCONS.Trim() == "-")
                               orderby a.GD_CNUMDOC
                               select new
                               {
                                   GD_CVANEXO = a.GD_CVANEXO,
                                   GD_CCODIGO = a.GD_CCODIGO,
                                   GD_CTIPDOC = a.GD_CTIPDOC,
                                   GD_CNUMDOC = a.GD_CNUMDOC,
                                   GD_DFECDOC = a.GD_DFECDOC,
                                   GD_DFECVEN = a.GD_DFECVEN,
                                   GD_CMONCAR = a.GD_CMONCAR,
                                   GD_NORPROG = a.GD_NORPROG,
                                   GD_NORRETE = a.GD_NORRETE,
                                   GD_CRETE = a.GD_CRETE,
                                   GD_NMNPROG = a.GD_NMNPROG,
                                   GD_CTASDET = a.GD_CTASDET,
                                   GD_CSUBDIA = a.GD_CSUBDIA,
                                   GD_CCOMPRO = a.GD_CCOMPRO,
                                  
                                   PROVEEDOR = ((from b in ctx.CP0003MAES
                                                 where b.AC_CCODIGO.Trim() == a.GD_CCODIGO.Trim()
                                                 select new { b.AC_CNOMBRE }).FirstOrDefault().AC_CNOMBRE),
                                   GD_CSECUE = a.GD_CSECUE,
                                 
                               }).ToList()
                           .Select(c => new CP0003EJED()
                           {
                               GD_CVANEXO = c.GD_CVANEXO,
                               GD_CCODIGO = c.GD_CCODIGO,
                               GD_CTIPDOC = c.GD_CTIPDOC,
                               GD_CNUMDOC = c.GD_CNUMDOC,
                               GD_DFECDOC = c.GD_DFECDOC,
                               GD_DFECVEN = c.GD_DFECVEN,
                               GD_CMONCAR = c.GD_CMONCAR,
                               GD_NORPROG = c.GD_NORPROG,
                               GD_NORRETE = c.GD_NORRETE,
                               GD_CRETE = c.GD_CRETE,
                               GD_NMNPROG = c.GD_NMNPROG,
                               GD_CTASDET = c.GD_CTASDET,
                               GD_CNDREF = c.PROVEEDOR,
                               GD_CSECUE = c.GD_CSECUE,
                               GD_CSUBDIA = c.GD_CSUBDIA,
                               GD_CCOMPRO = c.GD_CCOMPRO,
                           
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<vista_txt> TXT(string dato) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_txt>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJED
                               where a.GD_CNUMOPE.Trim() == dato.Trim()
                               orderby a.GD_CNUMDOC
                               select new
                               {
                                   //GD_CVANEXO = a.GD_CVANEXO,
                                   GD_CCODIGO = a.GD_CCODIGO,
                                   //GD_CTIPDOC = a.GD_CTIPDOC,
                                   GD_CNUMDOC = a.GD_CNUMDOC,
                                   GD_DFECDOC = a.GD_DFECDOC,
                                   //GD_DFECVEN = a.GD_DFECVEN,
                                   //GD_CMONCAR = a.GD_CMONCAR,
                                   //GD_NORPROG = a.GD_NORPROG,
                                   //GD_NORRETE = a.GD_NORRETE,
                                   //GD_CRETE = a.GD_CRETE,
                                   GD_NMNPROG = a.GD_NMNPROG,
                                   GD_CTASDET = a.GD_CTASDET,

                                   PROVEEDOR = ((from b in ctx.CP0003MAES
                                                 where b.AC_CCODIGO.Trim() == a.GD_CCODIGO.Trim() && b.AC_CVANEXO.Trim()=="P"
                                                 select new { b.AC_CCTADET }).FirstOrDefault().AC_CCTADET),
                                   //GD_CSECUE = a.GD_CSECUE,

                               }).ToList()
                           .Select(c => new vista_txt()
                           {
                               tipoidentidad = "6",
                               ruc = c.GD_CCODIGO,
                               completado = "000000000",
                               tipobienservicio = c.GD_CTASDET.Substring(0, 3),
                               cuentadetraccion = c.PROVEEDOR,
                               montoentero =Convert.ToString(Convert.ToInt32(c.GD_NMNPROG)), // formato 11 digito)s
                               montodecimal = "00",
                               codigo15 = (c.GD_CTASDET.Substring(0, 3) != "035" ? "01" : "05"),
                               anniomes = Convert.ToString(c.GD_DFECDOC.Value.Year) + "" + (c.GD_DFECDOC.Value.Month<10? "0"+""+Convert.ToString(c.GD_DFECDOC.Value.Month): Convert.ToString(c.GD_DFECDOC.Value.Month)),
                               tipodoc = "01",
                               seriefactura = (c.GD_CNUMDOC.Trim().Substring(0, c.GD_CNUMDOC.Trim().Length-2)).Substring(0,c.GD_CNUMDOC.IndexOf("-")),
                               factura= (c.GD_CNUMDOC.Trim().Substring(0, c.GD_CNUMDOC.Trim().Length - 2)).Substring(c.GD_CNUMDOC.IndexOf("-") + 1,(c.GD_CNUMDOC.Trim().Length - 2) -(c.GD_CNUMDOC.IndexOf("-")+1)),
                             
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

    }
}
