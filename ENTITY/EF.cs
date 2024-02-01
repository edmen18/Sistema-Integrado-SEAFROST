using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CapaNegocio;

namespace ENTITY
{
    public class EF
    {
        public Usuarios devuelveDNIUsuario(string user)
        {
            Usuarios userx = new Usuarios();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = ctx.Usuarios.Where(x => x.CodUsu == user).FirstOrDefault();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return userx;
        }

        public int CuentaUsuarios(string user)
        {
            int cuenta = 0;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    cuenta = ctx.Usuarios.Where(x => x.CodUsu==user).Count();
                  
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cuenta;
        }

        public int CuentaUsuariosClave(string user,string clave)
        {
            int cuenta = 0;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    cuenta = ctx.Usuarios.Where(x => x.CodUsu == user  &&  x.Clave == clave  ).Count();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cuenta;
        }
        public List<tabla_tipoPermiso> ListarTipoPermisos(string id)
        {
            var alumnos = new List<tabla_tipoPermiso>();

            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = ctx.tabla_tipoPermiso.Where(x => x.cod == id ).Concat(ctx.tabla_tipoPermiso.Where(x => x.cod != id)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public List<PersonalCategorias> ListarPersonalCategorias(string id)
        {
            var alumnos = new List<PersonalCategorias>();

            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = ctx.PersonalCategorias.Where(x => x.Categoria == id && x.activo==true).Concat(ctx.PersonalCategorias.Where(x => x.Categoria != id && x.activo == true)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public List<tabla_tipoHorarios> ListarTipoHorarios(string id)
        {
            var alumnos = new List<tabla_tipoHorarios>();

            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = ctx.tabla_tipoHorarios.Where(x => x.cod == id).Concat(ctx.tabla_tipoHorarios.Where(x => x.cod != id)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public List<vista_listaHorarios> ListarHorarios()
        {
            var alumnos = new List<vista_listaHorarios>();

            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                   
                    alumnos = (from a in ctx.tabla_Horarios
                               select new
                               {
                                  a.hora_fija ,a.minuto_fija ,a.codturno ,

                                   descripturno =
                                       ((from b in ctx.tabla_turno
                                         where
                                           b.cod == a.codturno
                                         select new
                                         {
                                             b.descripcion
                                         }).FirstOrDefault().descripcion),


                                 codTipoHorario =a.descripcion ,

                                 codcosto = a.codcosto ,
                                  cod = a.cod,
                                   hora_ing = a.hora_ing,
                                   hora_sal = a.hora_sal,
                                   minutos_ing= a.minutos_ing ,
                                   minutos_sal=a.minutos_sal,
                                   tipoHorarios =
                                       ((from b in ctx.tabla_tipoHorarios
                                         where
                                           b.cod == a.descripcion
                                         select new
                                         {
                                             b.descripcion
                                         }).FirstOrDefault().descripcion),
                                   descripCosto =
                                 ((from b in ctx.Ccosto
                                   where
                                     b.Codcco == a.codcosto
                                   select new
                                   {
                                       b.Descrip
                                   }).FirstOrDefault().Descrip)
                                   
                               }).ToList()
                                    .Select(c => new vista_listaHorarios()
                                    {
                                        HORA_INICIO = c.hora_ing,
                                        HORA_FIN = c.hora_sal,
                                        TIPO_HORARIO = c.tipoHorarios,
                                        DESCRIP_COSTO=c.descripCosto,
                                        MINUTOS_INICIO = c.minutos_ing,
                                        MINUTOS_FIN = c.minutos_sal,
                                        ID=c.cod ,
                                        COD_COSTO=c.codcosto,
                                        COD_TIPOHORARIO=c.codTipoHorario ,
                                        HORA_FIJA =c.hora_fija ,
                                        MINUTOS_FIJA =c.minuto_fija ,
                                        COD_TURNO =c.codturno ,
                                        TURNO =c.descripturno 
                                    }).ToList();
                    }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public List<vista_permisos> ListarPermisosFiltro(string codautoriza)
        {
            var alumnos = new List<vista_permisos>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = (from a in ctx.tabla_permisos.Where(x => x.codtipopermiso == "001" && x.codperAutoriza == codautoriza && x.estado ==false)
                               select new
                               {
                                   DNIAUTORIZA = a.codperAutoriza,

                                   ID = a.id,
                                   DNI = a.codper,
                                   FECHAINICIO = a.fechaincicio,
                                   FECHAFIN = a.fechafin,
                                   MOTIVO = a.motivo,
                                   CODTIPOPERMISO = a.codtipopermiso,

                                   HORAINICIO = a.horasInicio,
                                   MINUTOINICIO = a.minutosInicio,

                                   HORAFIN = a.horasFin,
                                   MINUTOFIN = a.minutosFin,

                                   NOMBRETRABAJADOR = ((from b in ctx.PersonalEmpresa
                                                        where
                                                          b.CodPer == a.codper
                                                        select new
                                                        {
                                                            b.Detalle
                                                        }).FirstOrDefault().Detalle),
                                   NOMBREAUTORIZA = ((from b in ctx.PersonalEmpresa
                                                      where
                                                        b.CodPer == a.codperAutoriza
                                                      select new
                                                      {
                                                          b.Detalle
                                                      }).FirstOrDefault().Detalle),

                                   TIPOPERMISO = ((from b in ctx.tabla_tipoPermiso
                                                   where
                                                     b.cod == a.codtipopermiso
                                                   select new
                                                   {
                                                       b.descripcion
                                                   }).FirstOrDefault().descripcion),


                               }).ToList()
                           .Select(c => new vista_permisos()
                           {
                               ID = c.ID,
                               NOMBRETRABAJADOR = c.NOMBRETRABAJADOR,

                               DNI = c.DNI,
                               FECHAINICIO = String.Format("{0:dd/MM/yyyy}", c.FECHAINICIO),

                               MOTIVO = c.MOTIVO.ToUpper(),

                               HORAINICIO = c.HORAINICIO,
                               MINUTOINICIO = c.MINUTOINICIO,
                               HORAFIN = c.HORAFIN,
                               MINUTOFIN = c.MINUTOFIN,
                               NOMBREAUTORIZA = c.NOMBREAUTORIZA,
                               DNIAUTORIZA=c.DNIAUTORIZA
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        public List<vista_permisos> ListarPermisos()
        {
            var alumnos = new List<vista_permisos>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = (from a in ctx.tabla_permisos.Where(x=>x.codtipopermiso=="001" )
                               select new
                               {
                                   DNIAUTORIZA = a.codperAutoriza,
                                   ID = a.id,
                                   DNI=a.codper,
                                   FECHAINICIO=a.fechaincicio,
                                   FECHAFIN = a.fechafin,
                                   MOTIVO = a.motivo,
                                   CODTIPOPERMISO =a.codtipopermiso,

                                   HORAINICIO=a.horasInicio,
                                   MINUTOINICIO =a.minutosInicio,

                                   HORAFIN = a.horasFin,
                                   MINUTOFIN = a.minutosFin,

                                   NOMBRETRABAJADOR = ((from b in ctx.PersonalEmpresa
                                              where
                                                b.CodPer == a.codper
                                              select new
                                              {
                                                  b.Detalle
                                              }).FirstOrDefault().Detalle),
                                   NOMBREAUTORIZA = ((from b in ctx.PersonalEmpresa
                                                        where
                                                          b.CodPer == a.codperAutoriza
                                                        select new
                                                        {
                                                            b.Detalle
                                                        }).FirstOrDefault().Detalle),

                                   TIPOPERMISO = ((from b in ctx.tabla_tipoPermiso
                                                   where
                                                     b.cod == a.codtipopermiso
                                                   select new
                                                   {
                                                       b.descripcion
                                                   }).FirstOrDefault().descripcion),


                               }).ToList()
                           .Select(c => new vista_permisos()
                           {
                               ID = c.ID,
                               NOMBRETRABAJADOR=c.NOMBRETRABAJADOR,
                           
                               DNI=c.DNI,
                               FECHAINICIO = String.Format("{0:dd/MM/yyyy}", c.FECHAINICIO),
                             
                               MOTIVO =c.MOTIVO.ToUpper(),
                             
                               HORAINICIO=c.HORAINICIO,
                               MINUTOINICIO=c.MINUTOINICIO,
                               HORAFIN = c.HORAFIN,
                               MINUTOFIN = c.MINUTOFIN,
                               NOMBREAUTORIZA =c.NOMBREAUTORIZA,
                               DNIAUTORIZA = c.DNIAUTORIZA
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public List<vista_vacaciones> ListarVacaciones(string tipo)
        {
            var alumnos = new List<vista_vacaciones>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = (from a in ctx.tabla_permisos.Where(x => x.codtipopermiso == tipo)
                               select new
                               {
                                   ID = a.id,
                                   DNI = a.codper,
                                   FECHAINICIO = a.fechaincicio,
                                   FECHAFIN = a.fechafin,
                                   MOTIVO = a.motivo,
                                 

                                   NOMBRETRABAJADOR = ((from b in ctx.PersonalEmpresa
                                                        where
                                                          b.CodPer == a.codper
                                                        select new
                                                        {
                                                            b.Detalle
                                                        }).FirstOrDefault().Detalle)
                                   
                               }).ToList()
                           .Select(c => new vista_vacaciones()
                           {
                               ID = c.ID,
                               NOMBRETRABAJADOR = c.NOMBRETRABAJADOR,
                         
                               DNI = c.DNI,
                               FECHAINICIO = String.Format("{0:dd/MM/yyyy}", c.FECHAINICIO),
                               FECHAFIN = String.Format("{0:dd/MM/yyyy}", c.FECHAFIN),
                               MOTIVO = c.MOTIVO.ToUpper()
                             
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public List<vista_usuario> ListarUsuarios()
        {
            var alumnos = new List<vista_usuario>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                            alumnos = (from a in ctx.Usuarios
                                       select new
                               {
                                   ID = a.idCodUsu,
                                   CODPER = a.Codper,
                                   NOMBRE = ((from b in ctx.PersonalEmpresa
                                              where
                                                b.CodPer == a.Codper 
                                              select new
                                              {
                                                  b.Detalle
                                              }).FirstOrDefault().Detalle),
                                 CODUSUARIO=a.CodUsu,
                                 CLAVE =a.Clave 

                               }).ToList()
                                   .Select(c => new vista_usuario()
                                   {
                                      ID =c.ID ,
                                      DNI =c.CODPER,
                                      NOMBRE =c.NOMBRE ,
                                      CODUSUARIO =c.CODUSUARIO,
                                       CLAVE =c.CLAVE
                                   }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public List<vista_costos> ListarCostos(string id)
        {
            var alumnos = new List<vista_costos>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {

                    //alumnos = ctx.tabla_tipoHorarios.Where(x => x.cod == id).Concat(ctx.tabla_tipoHorarios.Where(x => x.cod != id)).ToList();


                    alumnos = (from a in ctx.Ccosto.Where(x => x.Codcco == id).Concat(ctx.Ccosto.Where(x => x.Codcco != id))
                               select new
                               {
                                   ID = a.idCodcco,
                                   CODIGO_COSTO=a.Codcco,
                                   DESCRIP_COSTO = a.Descrip,
                                   CODPER_RESPONSABLE=a.codPer,
                                   RESPONSABLE = ((from b in ctx.PersonalEmpresa
                                              where
                                                b.CodPer == a.codPer
                                              select new
                                              {
                                                  b.Detalle
                                              }).FirstOrDefault().Detalle),

                               }).ToList()
                           .Select(c => new vista_costos()
                           {
                               ID = c.ID,
                               CODIGO_COSTO=c.CODIGO_COSTO,
                               DESCRIP_COSTO = c.DESCRIP_COSTO,
                               CODPER_RESPONSABLE=c.CODPER_RESPONSABLE,
                               RESPONSABLE =c.RESPONSABLE

                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public List<PersonalEmpresa> ListarPersonalEmpresa(string texto)
        {
            var alumnos = new List<PersonalEmpresa>();

            //try
            //{
                using (var ctx = new PERSONALCONTEXT())
                {
                    alumnos = ctx.PersonalEmpresa.Where(x => x.Detalle.Contains(texto))
                                     .ToList();
                }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            return alumnos;
        }
        public List<T_Presentacion> ListarPresentacion()
        {
            var alumnos = new List<T_Presentacion>();

            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {
                    alumnos = ctx.T_Presentacion.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public Boolean ActualizarConfiguracion(PersonalConfiguracion alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                   ctx.Entry(alumno).State = EntityState.Modified;
                   ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }
        public Boolean GuardarPermiso(tabla_permisos alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {

                    if (alumno.id > 0)
                    {
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }
                    else
                    {
                       
                            ctx.Entry(alumno).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }

        public Boolean EliminarPermiso(int id)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    ctx.Entry(new tabla_permisos { id = id }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
                 
            }
            return band;
        }

        public Boolean GuardarUsuario(Usuarios alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {

                    if (alumno.idCodUsu  > 0)
                    {
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }
                    else
                    {
                        if (CuentaUsuarios(alumno.CodUsu ) ==0)
                        ctx.Entry(alumno).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }
        public Boolean GuardarCosto(Ccosto alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    if (alumno.idCodcco > 0)
                    {
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }
                    else
                    {
                        alumno.Codcco = Cls_Utilidades.llenaConceros((Convert.ToInt32(ctx.Ccosto.Max(x => x.Codcco)) + 1).ToString(), 5);
                        ctx.Entry(alumno).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }
        public Boolean GuardarHorarios(tabla_Horarios alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    if (alumno.cod > 0)
                    {
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(alumno).State = EntityState.Added;
                    }
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }
        public Boolean GuardarPresentacion(T_Presentacion alumno, int idprod)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {                 
                        ctx.Entry(alumno).State = EntityState.Added;
                        ctx.SaveChanges();
                         var x = alumno.id;
                    T_CodigoGral general = new T_CodigoGral
                    {
                         idprod=idprod,
                         idpres=x
                    };
                    GuardarCodGeneral(general);
                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }
        public Boolean GuardarProducto(T_Producto alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {                 
                    ctx.Entry(alumno).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
               band = false;
            }
            return band;
        }
        public List<T_Producto> ListarProducto()
        {
            var alumnos = new List<T_Producto>();

            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {
                    alumnos = ctx.T_Producto.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public void GuardarCodGeneral(T_CodigoGral general)
        {
            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {
                  ctx.Entry(general).State = EntityState.Added;
                  ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Eliminar(string id)
        {
            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {
                    ctx.Entry(new T_Presentacion { codpr = id }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public T_Presentacion Obtener(string id)
        {
            var alumno = new T_Presentacion();

            try
            {
                using (var ctx = new PLANILLASCONTEXT())
                {
                    alumno = ctx.T_Presentacion.Where(x => x.codpr == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumno;
        }
    }
}
