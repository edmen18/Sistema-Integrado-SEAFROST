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
    public partial class CT0003PLEM
    {
        [Key]
        [StringLength(12)]
        public string PCUENTA { get; set; }

        [Required]
        [StringLength(50)]
        public string PDESCRI { get; set; }

        [Required]
        [StringLength(1)]
        public string PVANEXO { get; set; }

        [Required]
        [StringLength(1)]
        public string PVNIVEL { get; set; }

        [Required]
        [StringLength(1)]
        public string PVDOCREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PLDOC { get; set; }

        [Required]
        [StringLength(1)]
        public string PVFECVEN { get; set; }

        [Required]
        [StringLength(2)]
        public string PMONREF { get; set; }

        [Required]
        [StringLength(12)]
        public string PCTACAR { get; set; }

        [Required]
        [StringLength(12)]
        public string PCTAABO { get; set; }

        [Required]
        [StringLength(1)]
        public string PVCENCOS { get; set; }

        [Required]
        [StringLength(1)]
        public string PVREGCTA { get; set; }

        [Required]
        [StringLength(1)]
        public string PVTIPCTA { get; set; }

        [Required]
        [StringLength(1)]
        public string PVCTAAJU { get; set; }

        [Required]
        [StringLength(1)]
        public string PVAREA { get; set; }

        [Required]
        [StringLength(1)]
        public string PVCONBAN { get; set; }

        [Required]
        [StringLength(4)]
        public string PFORBAL { get; set; }

        [Required]
        [StringLength(4)]
        public string PFORGYP { get; set; }

        [Required]
        [StringLength(1)]
        public string PLINGYP { get; set; }

        [Required]
        [StringLength(4)]
        public string PFORGNA { get; set; }

        [Required]
        [StringLength(4)]
        public string PFORRE1 { get; set; }

        [Required]
        [StringLength(1)]
        public string PESTADO { get; set; }

        public DateTime? PDATE { get; set; }

        [Required]
        [StringLength(6)]
        public string PHORA { get; set; }

        [Required]
        [StringLength(5)]
        public string PUSER { get; set; }

        [Required]
        [StringLength(4)]
        public string PFOR01 { get; set; }

        [Required]
        [StringLength(4)]
        public string PFOR02 { get; set; }

        [Required]
        [StringLength(4)]
        public string PFOR03 { get; set; }

        [Required]
        [StringLength(4)]
        public string PFOR04 { get; set; }

        [Required]
        [StringLength(4)]
        public string PFOR05 { get; set; }

        [Required]
        [StringLength(1)]
        public string PVACTFIJ { get; set; }

        [Required]
        [StringLength(1)]
        public string PVGLODET { get; set; }

        [Required]
        [StringLength(1)]
        public string PVANEXO2 { get; set; }

        [Required]
        [StringLength(12)]
        public string PCTAEXT { get; set; }

        [Required]
        [StringLength(1)]
        public string PVDOCRE2 { get; set; }

        [Required]
        [StringLength(1)]
        public string PTASA { get; set; }

        [Required]
        [StringLength(1)]
        public string PINGEGR { get; set; }

        [Required]
        [StringLength(1)]
        public string PVMEDPAG { get; set; }
        /// <summary>
        /// Registra en el plan contable
        /// </summary>
        /// <param name="datos">OBJETO</param>
        /// <returns>Boolean</returns>
        public static Boolean insertaRegistro(CT0003PLEM datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
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
        /// Consulta el plan de cuentas
        /// Opciones : x nivel
        /// CREADO: 05/04/2016
        /// ACTUALIZACION: --/--/----
        /// </summary>
        /// <param name="PDATA">OBJETO</param>
        /// <returns>lista</returns>
        public static List<CT0003PLEM> ListaPlanID(CT0003PLEM PDATA)
        {
            var lista = new List<CT0003PLEM>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CT0003PLEM.Where(x => (PDATA.PCUENTA!=null?x.PCUENTA == PDATA.PCUENTA:x.PCUENTA!= PDATA.PCUENTA) && 
                                                (PDATA.PVNIVEL!=null?x.PVNIVEL==PDATA.PVNIVEL:x.PVNIVEL!=PDATA.PVNIVEL) &&
                                                x.PESTADO=="V").OrderBy(x => x.PCUENTA).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }


        public static string RegistrounCta(string codig)
        {
            var info = "";
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CT0003PLEM.Where(x => x.PCUENTA.Trim() == codig.Trim() && x.PESTADO == "V").Select(aw => aw.PDESCRI).First().ToString();
                }
            }
            catch (Exception)
            {
                info = "";
            }
            return info;
        }

        public static List<CT0003PLEM> ListarCtaE(string texto)
        {
            var info = new List<CT0003PLEM>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CT0003PLEM.Where(w => w.PDESCRI.Contains(texto) && w.PESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        // CODIGO EDGAR 
        /// <summary>
        /// PARA EL AUTOCOMPLETE DE CHEQUES
        /// </summary> CREADO EL 04/08/2016
        /// <param name="PDATA"></param>
        /// <returns></returns>
        public static List<CT0003PLEM> ListaPlanIDE(string PDATA)
        {
            var lista = new List<CT0003PLEM>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CT0003PLEM.Where(x => ( x.PCUENTA.Contains(PDATA) && x.PESTADO == "V")).OrderBy(x => x.PCUENTA).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
        public static List<CT0003PLEM> ListarCtaE1(string descri,string anexo, string moneda)
        {
            var info = new List<CT0003PLEM>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CT0003PLEM.Where(w =>(w.PDESCRI.Contains(descri) || w.PCUENTA.Contains(descri))&& w.PVANEXO.Trim()==anexo.Trim() && w.PESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static List<CT0003PLEM> ListarCtaE11(string descri, string moneda)
        {
            var info = new List<CT0003PLEM>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CT0003PLEM.Where(w => (w.PDESCRI.Contains(descri) || w.PCUENTA.Contains(descri)) && w.PESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static List<CT0003PLEM> ConsultaUnaCuenta(string descri)
        {
            var info = new List<CT0003PLEM>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CT0003PLEM.Where(w => w.PCUENTA==descri && w.PESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }


        public static CT0003PLEM InfCtaOBJ(string codig)
        {
            var info = new CT0003PLEM();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CT0003PLEM.Where(x => x.PCUENTA.Trim() == codig.Trim() && x.PESTADO == "V").First();
                }
            }
            catch (Exception)
            {
                info = null;
            }
            return info;
        }

    }
}
