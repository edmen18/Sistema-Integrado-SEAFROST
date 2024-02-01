namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class UT0030
    {
        [Key]
        [StringLength(5)]
        public string TU_ALIAS { get; set; }

        [Required]
        [StringLength(40)]
        public string TU_NOMUSU { get; set; }

        [Required]
        [StringLength(8)]
        public string TU_PASSWO { get; set; }

        [Required]
        [StringLength(2)]
        public string TU_LOCEMI { get; set; }

        [Required]
        [StringLength(2)]
        public string TU_DPTMTO { get; set; }

        [Required]
        [StringLength(1)]
        public string TU_TIPUSU { get; set; }

        [Required]
        [StringLength(4)]
        public string TU_NROALM { get; set; }

        [Required]
        [StringLength(3)]
        public string TU_FORVEN { get; set; }

        [Required]
        [StringLength(2)]
        public string TU_IMPRES { get; set; }

        public DateTime? TU_FECCRE { get; set; }

        public DateTime? TU_FECACT { get; set; }

        [Required]
        [StringLength(5)]
        public string TU_USUARI { get; set; }

        [Required]
        [StringLength(5)]
        public string TU_USUMOD { get; set; }

        [StringLength(1)]
        public string TU_CNUMMAN { get; set; }

        [Required]
        [StringLength(10)]
        public string TU_TELEFONO { get; set; }

        [Required]
        [StringLength(50)]
        public string TU_CORREO { get; set; }

        [Required]
        [StringLength(4)]
        public string TU_CCODCAJ { get; set; }

        [Required]
        [StringLength(4)]
        public string TU_CCODAGE { get; set; }

        [Required]
        [StringLength(4)]
        public string TU_CAJMN { get; set; }

        [Required]
        [StringLength(4)]
        public string TU_CAJUS { get; set; }

        [Required]
        [StringLength(1)]
        public string TU_CAPRPD { get; set; }

        [Required]
        [StringLength(1)]
        public string TU_CAPRRQ { get; set; }

        [Required]
        [StringLength(1)]
        public string TU_CAPROC { get; set; }

        [Required]
        [StringLength(1)]
        public string TU_CAPRLV { get; set; }

        [Required]
        [StringLength(5)]
        public string TU_CVENDE { get; set; }

        public static int CuentaUsuariosClave(string user, string clave)
        {
            int cuenta = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    cuenta = ctx.UT0030.Where(x => x.TU_ALIAS == user && x.TU_PASSWO == clave).Count();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cuenta;
        }

        public static List<UT0030> ListarUsuarios()
        {
            List<UT0030> userx = new List<UT0030>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    userx = (ctx.UT0030).OrderBy(x => x.TU_NOMUSU).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }


        // nuevo codigo edgar
        public static int CuentaAccesoADoc(string user)
        {
            int contador = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    contador = ctx.UT0030.Where(x => x.TU_ALIAS == user && x.TU_CAPROC == "S").Count();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return contador;
        }

        public static string Mostrarunusuario(string user)
        {
            var UR = "";
            try
            {
                using (var ctxb = new RSFACAR())
                {
                    UR = (ctxb.UT0030.Where(t => t.TU_ALIAS.Trim() == user).Select(rr => rr.TU_NOMUSU).FirstOrDefault()).ToString();
                    //TU_NOMUSU 

                }
            }
            catch
            {
            }

            return UR;
        }


        //nuevo sergio 15042016
        public static List<UT0030> ListarautocUsuarios(string nombre)
        {
            List<UT0030> userx = new List<UT0030>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    userx = (ctx.UT0030).Where(d => d.TU_NOMUSU.Contains(nombre)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }

        public static List<UT0030> ListarUsuariosxF()
        {
            List<UT0030> userx = new List<UT0030>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    userx = (ctx.UT0030).Where(d => d.TU_LOCEMI.Trim() == "F").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }

        public static UT0030 Mostrarinfousuario(string idusuario)
        {
            UT0030 userx = new UT0030();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    userx = (ctx.UT0030).Where(d => d.TU_ALIAS.Trim() == idusuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                userx = null;
            }

            return userx;
        }

    }
}
