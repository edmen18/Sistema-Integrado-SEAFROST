namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class FT0003CTAE
    {
        [Key]
        [StringLength(12)]
        public string TC_CEXISTE { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CVENTAS { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CDEVOLU { get; set; }

        [Required]
        [StringLength(18)]
        public string TC_CANEXO { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CFLETES { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CDSCTOS { get; set; }

        public DateTime? TC_DFECCRE { get; set; }

        public DateTime? TC_DFECMOD { get; set; }

        [Required]
        [StringLength(5)]
        public string TC_CUSUCRE { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CPROMO { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCOSVEN { get; set; }

        [Required]
        [StringLength(40)]
        public string TC_CDESCRI { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCOMPRA { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCONSUM { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CVENTAD { get; set; }

        [Required]
        [StringLength(6)]
        public string TC_CCENCOS { get; set; }

        [Required]
        [StringLength(10)]
        public string TC_CEXPORT { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCOMTRA { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CVARTRA { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CGASCOM { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCTAPEP { get; set; }

        public static List<FT0003CTAE> ListarCtaE(string texto)
        {
            var info = new List<FT0003CTAE>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.FT0003CTAE.Where(w=>w.TC_CDESCRI.Contains(texto)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static string RegistrounCta( string codig)
        {
            var info = "";
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.FT0003CTAE.Where(x => x.TC_CEXISTE.Trim() == codig.Trim()).Select(aw => aw.TC_CDESCRI).First().ToString();
                }
            }
            catch (Exception)
            {
                info = "";
            }
            return info;
        }

        /// <summary>
        /// Consulta cuentas x existencia
        /// Uso:Contabilizacion documentos con orden compra
        /// Filtro: x cuenta (arreglo)
        /// Creado:28.05.16|Autor:William|-
        /// Actualizacion:-|-|-|
        /// </summary>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        public static List<FT0003CTAE> cuenta_asiento(string[] cuentas)
        {
            var m_data = new List<FT0003CTAE>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    m_data = (from x in ctx.FT0003CTAE
                              where (cuentas).Contains(x.TC_CEXISTE)
                               select new
                               {
                                   TC_CEXISTE = x.TC_CEXISTE,
                                   TC_CVENTAS = x.TC_CVENTAS,
                                   TC_CDEVOLU = x.TC_CDEVOLU,
                                   TC_CANEXO = x.TC_CANEXO,
                                   TC_CFLETES = x.TC_CFLETES,
                                   TC_CDSCTOS = x.TC_CDSCTOS,
                                   TC_DFECCRE = x.TC_DFECCRE,
                                   TC_DFECMOD = x.TC_DFECMOD,
                                   TC_CUSUCRE = x.TC_CUSUCRE,
                                   TC_CPROMO = x.TC_CPROMO,
                                   TC_CCOSVEN = x.TC_CCOSVEN,
                                   TC_CDESCRI = x.TC_CDESCRI,
                                   TC_CCOMPRA = x.TC_CCOMPRA,
                                   TC_CCONSUM = x.TC_CCONSUM,
                                   TC_CVENTAD = x.TC_CVENTAD,
                                   TC_CCENCOS = x.TC_CCENCOS,
                                   TC_CEXPORT = x.TC_CEXPORT,
                                   TC_CCOMTRA= x.TC_CCOMTRA,
                                   TC_CVARTRA = x.TC_CVARTRA,
                                   TC_CGASCOM = x.TC_CGASCOM,
                                   TC_CCTAPEP=x.TC_CCTAPEP
                               }).ToList().Select(c => new FT0003CTAE
                               {
                                   TC_CEXISTE = c.TC_CEXISTE,
                                   TC_CVENTAS = c.TC_CVENTAS,
                                   TC_CDEVOLU = c.TC_CDEVOLU,
                                   TC_CANEXO = c.TC_CANEXO,
                                   TC_CFLETES = c.TC_CFLETES,
                                   TC_CDSCTOS = c.TC_CDSCTOS,
                                   TC_DFECCRE = c.TC_DFECCRE,
                                   TC_DFECMOD = c.TC_DFECMOD,
                                   TC_CUSUCRE = c.TC_CUSUCRE,
                                   TC_CPROMO = c.TC_CPROMO,
                                   TC_CCOSVEN = c.TC_CCOSVEN,
                                   TC_CDESCRI = c.TC_CDESCRI,
                                   TC_CCOMPRA = c.TC_CCOMPRA,
                                   TC_CCONSUM = c.TC_CCONSUM,
                                   TC_CVENTAD = c.TC_CVENTAD,
                                   TC_CCENCOS = c.TC_CCENCOS,
                                   TC_CEXPORT = c.TC_CEXPORT,
                                   TC_CCOMTRA = c.TC_CCOMTRA,
                                   TC_CVARTRA = c.TC_CVARTRA,
                                   TC_CGASCOM = c.TC_CGASCOM,
                                   TC_CCTAPEP = c.TC_CCTAPEP
                               }
                        ).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return m_data;
        }

    }
}
