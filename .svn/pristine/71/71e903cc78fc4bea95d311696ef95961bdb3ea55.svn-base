namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_d_nivelusua
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NU_NIVEL { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string NU_USUA { get; set; }




        public static void Insertarnivelusua(tabla_d_nivelusua ADDMC)
        {
            try
            {
                using (ANEXO_RSFACAR ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
                //using (var ctxM = new RSFACAR())
                //{
                //    ctxM.Entry(ADDMC).State = EntityState.Modified;
                //    ctxM.SaveChanges();
                //}
                //foreach (var validationErrors in dbEx.EntityValidationErrors)
                //{
                //    foreach (var validationError in validationErrors.ValidationErrors)
                //    {
                //        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                //    }
                //}
            }
        }


        public static void EliminaDetallena(tabla_d_nivelusua DDET)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    ctx.tabla_d_nivelusua.RemoveRange(ctx.tabla_d_nivelusua.Where(x => x.NU_USUA == DDET.NU_USUA.Trim()));
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<tabla_niveledicion> Listarnivelxusua(string usuario)
        {
            var dato = new List<tabla_niveledicion>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from a in ctx.tabla_d_nivelusua
                            join b in ctx.tabla_niveledicion on a.NU_NIVEL equals b.NA_ID
                            where a.NU_USUA == usuario
                            select new
                            {
                                NA_ID = b.NA_ID,
                                NA_NIVEL = b.NA_NIVEL,

                            }).ToList().Select(c => new tabla_niveledicion()
                            {
                                NA_ID = c.NA_ID,
                                NA_NIVEL = c.NA_NIVEL
                            }
                        ).ToList();
                }
            }
            catch
            {
                throw;
            }
            return dato;
        }


        public static int Validausuanivel(string usuario,int numnivel)
        {
            var dato = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from a in ctx.tabla_d_nivelusua where a.NU_USUA==usuario && a.NU_NIVEL== numnivel select a).ToList().Count();
                }
            }
            catch
            {
                dato = 0;
            }
            return dato;
        }


        public static int Validausuacuenta(string usuario)
        {
            var dato = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from a in ctx.tabla_d_nivelusua where a.NU_USUA == usuario && a.NU_NIVEL == 7 select a).ToList().Count();
                }
            }
            catch
            {
                dato = 0;
            }
            return dato;
        }



        public static List<tabla_d_nivelusua> ListausuaaprobsinF(int nnivel)
        {
            var dato =new  List<tabla_d_nivelusua>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR() )
                {
                    dato = (from a in ctx.tabla_d_nivelusua where a.NU_NIVEL == nnivel select a).ToList();
                }
            }
            catch
            {
                dato = null;
            }
            return dato;
        }


    }
}
