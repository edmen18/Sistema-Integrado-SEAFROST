namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabla_menuusuarios
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string USUA { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        [StringLength(100)]
        public string NOMMENU { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string NOMITEM { get; set; }

        public decimal? orden { get; set; }
        public decimal? VEROCULTA { get; set; }

        public  int id { get; set; }

    public static List<tabla_menuusuarios> VerUsuario(string codusuario,string menuitm)
        {
            var lista = new List<tabla_menuusuarios>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    lista = ctx.tabla_menuusuarios.Where(x => x.USUA == codusuario && x.NOMMENU==menuitm && x.VEROCULTA==1).OrderBy(x => x.orden).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;

        }


        public static int ValidaUrls(string codusuario, string urll,string host) //tabla_menuusuarios
        {
            //var lista = new tabla_menuusuarios();
            int lista = 0;
            try
            {
                using (ANEXO_RSFACAR ctx = new ANEXO_RSFACAR())
                {
                    if (host == "localhost")
                         lista = ctx.tabla_menuusuarios.Where(x => x.USUA == codusuario && x.URL.Replace("/SEALOGISTICA", "") == urll).Count();
                       else
                          lista = ctx.tabla_menuusuarios.Where(x => x.USUA == codusuario && x.URL == urll).Count();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;

        }


        public static List<cabmenu> VerUsuariomain(string codusuario)
        {
            var lista = new List<cabmenu>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    lista = (from a in ctx.tabla_menuusuarios.Where(x =>
                              x.USUA == codusuario)
                             select new
                             {
                                 NOMMENU = a.NOMMENU
                             }).Distinct().Select(c => new cabmenu()
                             {
                                 NOMMENU = c.NOMMENU
                             }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;

        }

        public static List<tabla_menuusuarios> todosLasOpcionesPorUsuario(string codusuario)
        {
            var lista = new List<tabla_menuusuarios>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    lista = ctx.tabla_menuusuarios.Where(x => x.USUA == codusuario ).ToList();
               }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;

        }
    }
}
