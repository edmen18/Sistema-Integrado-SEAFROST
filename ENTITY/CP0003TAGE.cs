namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class CP0003TAGE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TG_INDICE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string TG_CODIGO { get; set; }

        [Required]
        [StringLength(60)]
        public string TG_DESCRI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TG_NUMERO { get; set; }

        [Required]
        [StringLength(6)]
        public string TG_FECCRE { get; set; }

        [Required]
        [StringLength(6)]
        public string TG_FECACT { get; set; }

        [Required]
        [StringLength(5)]
        public string TG_USUARI { get; set; }

        public static List<CP0003TAGE> C_ListarTablaGePorCodigo(string codigo)
        {
            var info = new List<CP0003TAGE>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CP0003TAGE.Where(x => x.TG_INDICE == codigo).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }
        
        public static List<CP0003TAGE> C_ListarTablaG(CP0003TAGE TABL)
        {
            var tablag = new List<CP0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CP0003TAGE.Where(x => x.TG_INDICE == TABL.TG_INDICE)
                              orderby x.TG_NUMERO
                              select new
                        {
                            TG_INDICE=x.TG_INDICE,
                            TG_CODIGO=x.TG_CODIGO,
                            TG_DESCRI=x.TG_DESCRI
                        }).ToList().Select(x=> new CP0003TAGE {

                            TG_INDICE = x.TG_INDICE.Trim(),
                            TG_CODIGO = x.TG_CODIGO.Trim(),
                            TG_DESCRI = x.TG_DESCRI.Trim()
                        } ).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        public static List<CP0003TAGE> C_ListarTablaGedita(string codigo,string texto)
        {
            var info = new List<CP0003TAGE>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    info = ctx.CP0003TAGE.Where(x => x.TG_DESCRI.Contains(texto) && x.TG_INDICE == codigo).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static List<CP0003TAGE> ListarTG(CP0003TAGE TABL)
        {
            var tablag = new List<CP0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CP0003TAGE.Where(x => x.TG_INDICE == TABL.TG_INDICE && 
                                    (TABL.TG_CODIGO!=null?x.TG_CODIGO == TABL.TG_CODIGO: x.TG_CODIGO != TABL.TG_CODIGO))
                              select new
                              {
                                  TG_INDICE = x.TG_INDICE,
                                  TG_CODIGO = x.TG_CODIGO,
                                  TG_DESCRI = x.TG_DESCRI
                              }).ToList().Select(x => new CP0003TAGE
                              {

                                  TG_INDICE = x.TG_INDICE.Trim(),
                                  TG_CODIGO = x.TG_CODIGO.Trim(),
                                  TG_DESCRI = x.TG_DESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        public static CP0003TAGE ListarTGID(CP0003TAGE TG)
        {   //METODO PARA LIQ-04/04/2016
            var data = new CP0003TAGE();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    data = ctx.CP0003TAGE.Where(x => x.TG_INDICE == TG.TG_INDICE && x.TG_CODIGO == TG.TG_CODIGO).FirstOrDefault();
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
