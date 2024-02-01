namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class AL0003TABM
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string TM_CTIPMOV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string TM_CCODMOV { get; set; }

        [Required]
        [StringLength(30)]
        public string TM_CDESCRI { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFPROV { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFDOC { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFSOLI { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFCCOS { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFGLOS { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFALMA { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFORDEN { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CVANEXO { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CCODANE { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CORDCOM { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFSTOCK { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CTIPCOS { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CPRIVAL { get; set; }

        [Required]
        [StringLength(5)]
        public string TM_CUSUCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string TM_CUSUMOD { get; set; }

        public DateTime? TM_DFECCRE { get; set; }

        public DateTime? TM_DFECMOD { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CTIPANE { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFCONSU { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM01 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM02 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM03 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM04 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM05 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM06 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM07 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM08 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM09 { get; set; }

        [Required]
        [StringLength(10)]
        public string TM_CREPM10 { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFCTACO { get; set; }

        [Required]
        [StringLength(2)]
        public string TM_CCODSNT { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFLGCVE { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFLGCOT { get; set; }

        [Required]
        [StringLength(1)]
        public string TM_CFLGCSM { get; set; }

        public static AL0003TABM obtenerCDisponible(string CM, string TM)
        {
            //string CM, string TM
            var orden = new AL0003TABM();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    orden = ctx.AL0003TABM.Where(x => x.TM_CTIPMOV == CM && x.TM_CCODMOV == TM).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return orden;
        }
        public static List<AL0003TABM> ListarMovimientos(string texto, string tipo)
        {
            List<AL0003TABM> listaA = new List<AL0003TABM>();
            try
            {
                using (var ctx = new RSFACAR())
                {

                    listaA = ctx.AL0003TABM.Where(x => x.TM_CDESCRI.Contains(texto) && x.TM_CTIPMOV == tipo).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }

        public static List<AL0003TABM> ListarMovimientosID(string texto, string tipo)
        {
            List<AL0003TABM> listaA = new List<AL0003TABM>();
            try
            {
                using (var ctx = new RSFACAR())
                {

                    listaA = ctx.AL0003TABM.Where(x => x.TM_CCODMOV == texto && x.TM_CTIPMOV == tipo).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }

        public static List<AL0003TABM> ListaTipo()
        {
            List<AL0003TABM> listT = new List<AL0003TABM>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    List<string> filtro = new List<string>() { "E", "S" };
                    //listT = ctx.AL0003TABM.Where(x => filtro.Contains(x.TM_CTIPMOV)).Distinct().ToList();
                    //listT = ctx.AL0003TABM.Where(x => filtro.Contains(x.TM_CTIPMOV)).Select(x => new { x.TM_CTIPMOV }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return listT;
        }

        //CODIGO EDGAR
        public static List<AL0003TABM> ListarMovimientos(AL0003TABM TABL)

        {
            var alumnos = new List<AL0003TABM>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = (from c in ctx.AL0003TABM.Where(x => x.TM_CTIPMOV.Trim() == TABL.TM_CTIPMOV)
                               select new
                               {
                                   TM_CTIPMOV = c.TM_CTIPMOV,
                                   TM_CCODMOV = c.TM_CCODMOV,
                                   TM_CDESCRI = c.TM_CDESCRI,
                                   // ch = true,


                               }

                        ).ToList().Select(c => new AL0003TABM()
                        {
                            TM_CTIPMOV = c.TM_CTIPMOV.Trim(),
                            TM_CCODMOV = c.TM_CCODMOV.Trim(),
                            TM_CDESCRI = c.TM_CDESCRI.Trim(),
                            //ch = true,

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }
        public static List<AL0003TABM> ListarMovimientosTodos()
        {
            var alumnos = new List<AL0003TABM>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = (from c in ctx.AL0003TABM
                               select new
                               {
                                   TM_CTIPMOV = c.TM_CTIPMOV,
                                   TM_CCODMOV = c.TM_CCODMOV,
                                   TM_CDESCRI = c.TM_CDESCRI,
                                   // ch = true,


                               }

                        ).ToList().Select(c => new AL0003TABM()
                        {
                            TM_CTIPMOV = c.TM_CTIPMOV.Trim(),
                            TM_CCODMOV = c.TM_CCODMOV.Trim(),
                            TM_CDESCRI = c.TM_CDESCRI.Trim(),
                            //ch = true,

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }

    }
}
