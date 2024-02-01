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

    public partial class FT0003NUME
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TN_CCODIGO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string TN_CNUMSER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TN_NNUMINI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TN_NNUMFIN { get; set; }

        [Required]
        [StringLength(30)]
        public string TN_CDESCRI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TN_NNUMERO { get; set; }

        [Required]
        [StringLength(5)]
        public string TN_CUSUCRE { get; set; }

        public DateTime? TN_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string TN_CUSUMOD { get; set; }

        public DateTime? TN_DFECMOD { get; set; }

        [Required]
        [StringLength(6)]
        public string TN_CFORMAT { get; set; }

        [Required]
        [StringLength(4)]
        public string TN_CCODAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string TN_CESTACI { get; set; }

        [Required]
        [StringLength(30)]
        public string TN_CPUERTO { get; set; }

        [Required]
        [StringLength(15)]
        public string TN_CNUMAUT { get; set; }

        [Required]
        [StringLength(120)]
        public string TN_CRUTFW { get; set; }

        [Required]
        [StringLength(120)]
        public string TN_CRUTFW2 { get; set; }

        [Required]
        [StringLength(120)]
        public string TN_CPRINTE { get; set; }

        [Required]
        [StringLength(60)]
        public string TN_CTIPLET { get; set; }

        public int TN_NTAMLET { get; set; }

        [Required]
        [StringLength(1)]
        public string TN_CMODIMP { get; set; }

        [Required]
        [StringLength(1)]
        public string TN_CTIPIMP { get; set; }

        [Required]
        [StringLength(1)]
        public string TN_CTIPMAQ { get; set; }

        public int TN_NMARIZQ { get; set; }

        public int TN_NMARSUP { get; set; }

        public static FT0003NUME ListarRequerimientos()
        {
            var alumnos = new FT0003NUME();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.FT0003NUME.Where(x => x.TN_CCODIGO == "RQ" && x.TN_CNUMSER == "001").FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static Boolean actualizaNumeracion(FT0003NUME alumno)
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


        //numeracion actualizar 
        public static void actualizaNumer(FT0003NUME dato)
        {
           
            try
            {

                    var IDNDOC = new FT0003NUME { TN_CCODIGO = dato.TN_CCODIGO,TN_CNUMSER=dato.TN_CNUMSER};
                    using (RSFACAR ctx = new RSFACAR())
                    {
                        ctx.FT0003NUME.Attach(IDNDOC);
                        IDNDOC.TN_NNUMERO = dato.TN_NNUMERO;

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
                
            }
            
        }

        //nuevo jimmy
        public static Boolean actualizaNumeraciónOC(FT0003NUME ft)
        {
            Boolean band = true;
            var cliente = new FT0003NUME { TN_CCODIGO = ft.TN_CCODIGO, TN_CNUMSER = ft.TN_CNUMSER };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.FT0003NUME.Attach(cliente);
                    cliente.TN_NNUMERO = ft.TN_NNUMERO;
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

        /*NUMERACION*/
        public static List<FT0003NUME> ListarNumeracion(FT0003NUME NDATA)
        {
            var data = new List<FT0003NUME>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    data = ctx.FT0003NUME.Where(x => x.TN_CCODIGO == NDATA.TN_CCODIGO && x.TN_CNUMSER == NDATA.TN_CNUMSER).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }
    }
}
