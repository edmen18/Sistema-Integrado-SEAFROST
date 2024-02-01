namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabla_d_areausua
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UA_SUBAREA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string UA_USUA { get; set; }

        [Column(Order = 2)]
        [StringLength(200)]
        public string UA_CORREO { get; set; }

        

        public static void Insertarareausua(tabla_d_areausua ADDMC)
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


        public static void EliminaDetalleua(tabla_d_areausua DDET)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    ctx.tabla_d_areausua.RemoveRange(ctx.tabla_d_areausua.Where(x => x.UA_USUA == DDET.UA_USUA.Trim()));
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<tabla_subareas> Listarsubareasxusua(string usuario)
        {
            var dato = new List<tabla_subareas>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from a in ctx.tabla_d_areausua
                            join b in ctx.tabla_subareas on a.UA_SUBAREA equals b.SA_ID
                            where a.UA_USUA == usuario
                            select new
                            {
                                SA_ID = b.SA_ID,
                                SA_DESC = b.SA_DESC,
                            }).ToList().Select(c => new tabla_subareas()
                            {
                                SA_ID = c.SA_ID,
                                SA_DESC = c.SA_DESC
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





        public static int Listarsubareacceso(string usuario,string subarea)
        {
            //var dato = new List<tabla_d_areausua>();
            int dato = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from a in ctx.tabla_d_areausua
                            where a.UA_USUA == usuario && a.UA_SUBAREA.ToString()==subarea select a).ToList().Count();
                }
            }
            catch
            {
                dato=0;
            }
            return dato;
        }


        public static List<tabla_d_areausua> Listausuarioareaaprob(int idsubarea,string idprodu,int nnivel)
        {
            var dato = new List<tabla_d_areausua>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    var usuanaprob = tabla_d_nivelusua.ListausuaaprobsinF(nnivel);
                    string[] nusuario =new string[usuanaprob.Count()];
                    int contt = 0;
                    foreach(var t in usuanaprob)
                    {
                        nusuario[contt] = t.NU_USUA;
                        contt++;
                    }

                    var nusuaf = UT0030.ListarUsuariosxF();
                    string[] usuaconaprobFin = new string[nusuaf.Count()];
                    int contt2 = 0;
                    foreach (var t in nusuaf)
                    {
                        usuaconaprobFin[contt2] = t.TU_ALIAS;
                        contt2++;
                    }


                    dato = (from a in ctx.tabla_d_areausua
                            where a.UA_SUBAREA == idsubarea && nusuario.Contains(a.UA_USUA)  && !usuaconaprobFin.Contains(a.UA_USUA)  && a.UA_CORREO !=null 
                            select new
                            {
                                UA_CORREO = a.UA_CORREO,
                                UA_USUA = a.UA_USUA,
                            }).ToList().Select(c => new tabla_d_areausua()
                            {
                                UA_CORREO =  c.UA_CORREO,
                                UA_USUA = c.UA_USUA 
                            }
                        ).ToList();
                }
            }
            catch
            {
                dato=null;
            }
            return dato;
        }


    }
}
