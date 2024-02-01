namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabla_d_usuaprod
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string DA_IDUSUA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DA_CODIGO { get; set; }

        public DateTime? DA_FECHA { get; set; }

        [StringLength(15)]
        public string DA_HORA { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DA_TIPOCODIGO { get; set; }

     

        public static void Actualizardetup(tabla_d_usuaprod ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR()) 
            {
                ctx.Entry(ADDMC).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public static int NumAprob(tabla_d_usuaprod ADDMC)
        {
            var nreg = 0;
            using (var ctx = new ANEXO_RSFACAR())
            {
                nreg = (from c in ctx.tabla_d_usuaprod where c.DA_IDUSUA == ADDMC.DA_IDUSUA && c.DA_CODIGO.Trim() == ADDMC.DA_CODIGO.Trim() && c.DA_TIPOCODIGO == ADDMC.DA_TIPOCODIGO select c).ToList().Count();
            }
            return nreg;
        }

        public static int NumAprobTotal(tabla_d_usuaprod ADDMC)
        {
            var nreg = 0;
            using (var ctx = new ANEXO_RSFACAR())
            {
                nreg = (from c in ctx.tabla_d_usuaprod where c.DA_CODIGO.Trim() == ADDMC.DA_CODIGO.Trim() && c.DA_TIPOCODIGO == ADDMC.DA_TIPOCODIGO select c).ToList().Count();
            }
            return nreg;
        }

        public static List<tabla_d_usuaprod> NumAprobTotalxusuarioF(string ADDMC)
        {
            var nreg = new List<tabla_d_usuaprod>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                var nusuaf = UT0030.ListarUsuariosxF();
                string[] listausuaf = new string[nusuaf.Count()];
                int contt = 0;
                foreach (var t in nusuaf)
                {
                    listausuaf[0] = t.TU_ALIAS;
                    contt++;
                }

                nreg = (from c in ctx.tabla_d_usuaprod where c.DA_CODIGO.Trim() == ADDMC.Trim() && listausuaf.Contains(c.DA_IDUSUA) select c).ToList();
            }
            return nreg;
        }


        public static int NumRegAprob(tabla_d_usuaprod ADDMC)
        {
            var nreg = 0;
            //var naprobxarea = 0;
            using (var ctx = new ANEXO_RSFACAR())
            {
                nreg = (from c in ctx.tabla_d_usuaprod where c.DA_IDUSUA == ADDMC.DA_IDUSUA && c.DA_CODIGO.Trim() == ADDMC.DA_CODIGO.Trim() && c.DA_TIPOCODIGO == ADDMC.DA_TIPOCODIGO select c).ToList().Count();

            }
            return nreg;
        }

        public static void DesapruebaTarifa(tabla_d_usuaprod ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_d_usuaprod.RemoveRange(ctx.tabla_d_usuaprod.Where(x => x.DA_CODIGO == ADDMC.DA_CODIGO.Trim() && x.DA_TIPOCODIGO == ADDMC.DA_TIPOCODIGO));
                ctx.SaveChanges();
            }
        }


        public static List<tabla_d_usuaprod> AprobacionxProducto(string ADDMC, int tdoc)
        {
            var nreg = new List<tabla_d_usuaprod>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                nreg = (from c in ctx.tabla_d_usuaprod where c.DA_CODIGO.Trim() == ADDMC.Trim() && c.DA_TIPOCODIGO == tdoc select c).ToList();
            }
            return nreg;
        }

        public static List<tabla_d_usuaprod> AprobacionxProductodetall(string ADDMC, int tcod)
        {
            var nreg = new List<tabla_d_usuaprod>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                //nreg = (from c in ctx.tabla_d_usuaprod where c.DA_CODIGO.Trim() == ADDMC.Trim() select c).ToList();
                nreg = (from c in ctx.tabla_d_usuaprod.Where(x => x.DA_CODIGO == ADDMC.Trim() && x.DA_TIPOCODIGO == tcod)
                        select new
                        {
                            DA_IDUSUA = c.DA_IDUSUA,
                            DA_FECHA = c.DA_FECHA,
                            DA_HORA = c.DA_HORA


                        }

                        ).ToList().Select(c => new tabla_d_usuaprod()
                        {
                            DA_IDUSUA = UT0030.Mostrarunusuario(c.DA_IDUSUA),
                            DA_FECHA = Convert.ToDateTime(string.Format("{0:dd/MM/yyyy}", c.DA_FECHA)),
                            DA_HORA = c.DA_HORA

                        }).ToList();
            }
            return nreg;
        }



    }
}
