using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using CapaEntidades;
using System.Data.OleDb;

namespace CapaDatos
{
   public class Cls_MantenimientosCD
    {
         private SqlConnection conectar;
         private OleDbConnection conectarAc;

         public Cls_MantenimientosCD(string cadena)
        {
            this.conectar = Cls_ConexionCD.conectar(cadena);
            this.conectarAc = Cls_ConexionCD.conectarAccses(cadena);
        }

         public Boolean actualizaUsuarios(string codusu,string clave)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "update usuario set password = @clave where usuario=@codusu";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@clave", clave);
                 sqlCmd.Parameters.AddWithValue("@codusu", codusu );

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }




         public Boolean eliminaArchivo(string filename)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from  FilesContent where filename =@filename";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@filename", filename);

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }




         public Boolean eliminaPlanillaDet(int idnumdoc)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from INYProd_PlanillaProduccionDet  where IdNumdoc =@idnumdoc";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@idnumdoc", idnumdoc);
                
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }



         public Boolean agregaGuiasNota(string numdoc2 , string serie , string correlativo)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                  sql = "insert into inyprod_anexo_doc_cabGuias(numdoc2 ,serie,correlativo ) values (@numdoc2,@serie,@correlativo)";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
                 sqlCmd.Parameters.AddWithValue("@serie", serie);
                 sqlCmd.Parameters.AddWithValue("@correlativo", correlativo);
                 
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

       /**************************************************************************/
         public Boolean actualizaDoc_cab(Cls_Doc_cab cab )
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "update Doc_cab set numdocrefer2 =@numdocrefer2 where Numdoc2 = @numdoc2";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@numdoc2", cab.Numdoc2 );
                 sqlCmd.Parameters.AddWithValue("@numdocrefer2", cab.numdocrefer2 );
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }


         

       /**************************************************************************/


         public Boolean eliminaGuiasNota(string numdoc2 )
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from inyprod_anexo_doc_cabGuias where numdoc2 =@numdoc2";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
                 
                 
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }


         public Boolean sp_solicitud_correctivaPreventivaInsercion(string numero, string tipo, string origen, string descripcion, string otro_origen, DateTime fecha, string serie, string doccruce, string doccruce2, string seriecruce,string seriecruce2,Boolean eficaz,string codusu,string areadirigida)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "sp_solicitud_correctivaPreventivaInsercion";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;  
                 sqlCmd.Parameters.AddWithValue("@numero", numero);
                 sqlCmd.Parameters.AddWithValue("@tipo", tipo);
                 sqlCmd.Parameters.AddWithValue("@origen", origen);
                 sqlCmd.Parameters.AddWithValue("@descripcion", descripcion);
                 sqlCmd.Parameters.AddWithValue("@otro_origen", otro_origen);
                 sqlCmd.Parameters.AddWithValue("@fecha", fecha);
                 sqlCmd.Parameters.AddWithValue("@serie", serie);

                 sqlCmd.Parameters.AddWithValue("@doccruce", doccruce);
                 sqlCmd.Parameters.AddWithValue("@doccruce2", doccruce2);
                 sqlCmd.Parameters.AddWithValue("@seriecruce", seriecruce);
                 sqlCmd.Parameters.AddWithValue("@seriecruce2", seriecruce2);
                 sqlCmd.Parameters.AddWithValue("@eficaz", eficaz);
                 sqlCmd.Parameters.AddWithValue("@codusu", codusu);

                 sqlCmd.Parameters.AddWithValue("@areadirigida", areadirigida);

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }



         public Boolean sp_tabla_planActividades_insercion(Cls_planActividades plan)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "sp_tabla_planActividades_insercion";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@numero", plan.numero );
                 sqlCmd.Parameters.AddWithValue("@serie", plan.serie);
                 sqlCmd.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                 sqlCmd.Parameters.AddWithValue("@finicio", plan.FInicio );
                 sqlCmd.Parameters.AddWithValue("@ffin", plan.FFin);
                 sqlCmd.Parameters.AddWithValue("@area", plan.Area);
                 sqlCmd.Parameters.AddWithValue("@responsable", plan.Responsable);
                 sqlCmd.Parameters.AddWithValue("@anioot", plan.anioot);
                 sqlCmd.Parameters.AddWithValue("@mesot", plan.mesot);
                 sqlCmd.Parameters.AddWithValue("@numeroot", plan.numeroot);
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }



         public Boolean actualizasolicitud_correctivaPreventiva(Cls_SolicitudCorrectivaPreventiva solicitud)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "update tabla_solicitud_correctivaPreventiva  set estado =@estado from tabla_solicitud_correctivaPreventiva where numero =@numero and serie =@serie";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@numero", solicitud.numero);
                 sqlCmd.Parameters.AddWithValue("@serie", solicitud.serie );
                 sqlCmd.Parameters.AddWithValue("@estado", solicitud.estado);

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaOrdenTrabajo(Cls_OrdenTrabajo orden)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from tabla_ordendetrabajo where numero =@numero and mes=@mes and anio=@anio";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@numero", orden.numero );
                 sqlCmd.Parameters.AddWithValue("@mes", orden.mes);
                 sqlCmd.Parameters.AddWithValue("@anio", orden.anio);
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean sp_ordendetrabajo_insercion(Cls_OrdenTrabajo orden)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "sp_ordendetrabajo_insercion";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 
                 sqlCmd.Parameters.AddWithValue("@numero", orden.numero );
                 sqlCmd.Parameters.AddWithValue("@mes", orden.mes);
                 sqlCmd.Parameters.AddWithValue("@anio", orden.anio);
                 sqlCmd.Parameters.AddWithValue("@codarea", orden.codarea);
                 sqlCmd.Parameters.AddWithValue("@codmantenimiento", orden.codmantenimiento);
                 sqlCmd.Parameters.AddWithValue("@codorden", orden.codorden);
                 sqlCmd.Parameters.AddWithValue("@codusuaprobado", orden.codusuaprobado);
                 sqlCmd.Parameters.AddWithValue("@codusuautorizado", orden.codusuautorizado);
                 sqlCmd.Parameters.AddWithValue("@codusuconformidad", orden.codusuconformidad);
                 sqlCmd.Parameters.AddWithValue("@codususolicitante", orden.codususolicitante);
                 sqlCmd.Parameters.AddWithValue("@contratista", orden.contratista);
                 sqlCmd.Parameters.AddWithValue("@fecha", orden.fecha);
                 sqlCmd.Parameters.AddWithValue("@FechaFin", orden.FechaFin);
                 sqlCmd.Parameters.AddWithValue("@fechaInicio", orden.fechaInicio);
               //  sqlCmd.Parameters.AddWithValue("@fecharecibo", orden.fecharecibo);
                 sqlCmd.Parameters.AddWithValue("@igvMateriales", orden.igvMateriales);
                 sqlCmd.Parameters.AddWithValue("@igvMo", orden.igvMo);
                 sqlCmd.Parameters.AddWithValue("@numeroAC", orden.numeroAC);
                 sqlCmd.Parameters.AddWithValue("@observacion", orden.observacion);
                 sqlCmd.Parameters.AddWithValue("@periodo", orden.periodo);
                 sqlCmd.Parameters.AddWithValue("@recibo", orden.recibo);
                 sqlCmd.Parameters.AddWithValue("@semana", orden.semana);
                 sqlCmd.Parameters.AddWithValue("@servicio", orden.servicio);
                 sqlCmd.Parameters.AddWithValue("@situacion", orden.situacion);
                 sqlCmd.Parameters.AddWithValue("@total", orden.total);
                 sqlCmd.Parameters.AddWithValue("@totalmateriales", orden.totalmateriales);
                 sqlCmd.Parameters.AddWithValue("@totalmo", orden.totalmo);
                 sqlCmd.Parameters.AddWithValue("@valorconigv", orden.valorconigv);
                 sqlCmd.Parameters.AddWithValue("@valorsinigv", orden.valorsinigv);
               
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean sp_detalleOrdenTrabajo_insercion(Cls_DetalleOrdenTrabajo detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "sp_detalleOrdenTrabajo_insercion";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@anio", detalle.anio);
                 sqlCmd.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                 sqlCmd.Parameters.AddWithValue("@centrocosto", detalle.centrocosto);
                 sqlCmd.Parameters.AddWithValue("@codpresupuesto", detalle.codpresupuesto);
                 sqlCmd.Parameters.AddWithValue("@codunidad", detalle.codunidad);
                 sqlCmd.Parameters.AddWithValue("@codusu", detalle.codusu);
                 sqlCmd.Parameters.AddWithValue("@detalle", detalle.detalle);
                 sqlCmd.Parameters.AddWithValue("@fecha", detalle.fecha);
                 sqlCmd.Parameters.AddWithValue("@mes", detalle.mes);
                 sqlCmd.Parameters.AddWithValue("@numero", detalle.numero );
                 sqlCmd.Parameters.AddWithValue("@total", detalle.total);
                 sqlCmd.Parameters.AddWithValue("@valorunitario", detalle.valorunitario);
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean actualizaOrdenTrabajo(Cls_OrdenTrabajo orden)
         {
             Boolean band = true;

             string sql = string.Empty;
           
            
             try
             {
                 sql = "sp_actualiza_ordenTrabajo";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@numero", orden.numero );
                 sqlCmd.Parameters.AddWithValue("@mes", orden.mes );
                 sqlCmd.Parameters.AddWithValue("@anio", orden.anio);
                 sqlCmd.Parameters.AddWithValue("@codusuautorizado", orden.codusuautorizado);
                 sqlCmd.Parameters.AddWithValue("@finalizado", orden.finalizado );
                 sqlCmd.Parameters.AddWithValue("@aprobadopago", orden.aprobadopago);

                 sqlCmd.Parameters.AddWithValue("@recibo", orden.recibo);
                 sqlCmd.Parameters.AddWithValue("@fecharecibo", orden.fecharecibo);

                 sqlCmd.Parameters.AddWithValue("@codusuaprobado", orden.codusuaprobado);
                 
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean sp_tabla_detalle_solicitud_correctivaPreventiva_insercion(Cls_DetalleSolicitudCorrectivaPreventiva detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "sp_tabla_detalle_solicitud_correctivaPreventiva_insercion";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@imagen", detalle.imagen);
                 sqlCmd.Parameters.AddWithValue("@numero", detalle.numero);
                 sqlCmd.Parameters.AddWithValue("@serie", detalle.serie);
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         //public Boolean eliminaOrdenTrabajo(Cls_OrdenTrabajo orden)
         //{
         //    Boolean band = true;

         //    string sql = string.Empty;
         //    try
         //    {

         //        sql = "delete from tabla_ordendetrabajo where numero =@numero and mes=@mes and anio=@anio";
         //        SqlCommand sqlCmd = new SqlCommand();
         //        sqlCmd.Connection = conectar;
         //        sqlCmd.CommandText = sql;
         //        sqlCmd.Parameters.AddWithValue("@numero", orden.numero);
         //        sqlCmd.Parameters.AddWithValue("@mes", orden.mes);
         //        sqlCmd.Parameters.AddWithValue("@anio", orden.anio);
         //        conectar.Open();
         //        sqlCmd.ExecuteNonQuery();
         //        conectar.Close();
         //    }
         //    catch (Exception)
         //    {
         //        band = false;
         //    }

         //    return band;
         //}

         public Boolean eliminaDetalleppAC(string id)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from detallepp  where idpproduccion ='" + id + "'";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;
                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaDetallempAC(string id)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from detallemp where  idpproduccion ='" + id + "'";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;
                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaDetalleinAC(string id)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from detallein   where idpproduccion ='" + id + "'";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;
                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaDetalleperAC(string id)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from detalleper  where idpproduccion ='" + id + "'";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;
                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean actualizaPProduccionAC(string id)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "update pproduccion  set estado='ANULADO',observaciones='ANULADO' where id ='" + id + "'";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;
                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

       ///////////////////////////////////////// seafrost

         public Boolean pr_inserta_control(Cls_Control control)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_inserta_control";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@codarea", control.codarea);
                 sqlCmd.Parameters.AddWithValue("@codestado", control.codestado);
                 //sqlCmd.Parameters.AddWithValue("@codproceso", control.codproceso);
                 sqlCmd.Parameters.AddWithValue("@codsala", control.codsala);
                 sqlCmd.Parameters.AddWithValue("@codtipocontrol", control.codtipocontrol);
                 sqlCmd.Parameters.AddWithValue("@codturno", control.codturno);
                 sqlCmd.Parameters.AddWithValue("@fecha", control.fecha);
                 sqlCmd.Parameters.AddWithValue("@fechaactual", control.fechaactual);
                 sqlCmd.Parameters.AddWithValue("@nguia", control.nguia);
                 sqlCmd.Parameters.AddWithValue("@usuario", control.usuario);
                 sqlCmd.Parameters.AddWithValue("@observaciones", control.observaciones );

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean pr_inserta_detalle(Cls_Detalle detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_inserta_detalle";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@alm_origen", detalle.alm_origen);
                 sqlCmd.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                 sqlCmd.Parameters.AddWithValue("@codproceso", detalle.codproceso);
                 sqlCmd.Parameters.AddWithValue("@codtipocontrol", detalle.codtipocontrol);
                 sqlCmd.Parameters.AddWithValue("@f_produccion", detalle.f_produccion);
                 sqlCmd.Parameters.AddWithValue("@idalmacen", detalle.idalmacen);
                 sqlCmd.Parameters.AddWithValue("@idsalida", detalle.idsalida);
                 sqlCmd.Parameters.AddWithValue("@nguia", detalle.nguia);
                 sqlCmd.Parameters.AddWithValue("@codsala", detalle.codsala);
                 sqlCmd.Parameters.AddWithValue("@lote", detalle.lote);
                

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaDetalle(int id)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "delete from detalle where coddetalle =" + id ;
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean pr_inserta_detalle_modificacion(Cls_Detalle detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {
                 sql = "pr_inserta_detalle_modificacion";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@alm_origen", detalle.alm_origen);
                 sqlCmd.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                 sqlCmd.Parameters.AddWithValue("@codproceso", detalle.codproceso);
                 sqlCmd.Parameters.AddWithValue("@f_produccion", detalle.f_produccion);
                 sqlCmd.Parameters.AddWithValue("@idalmacen", detalle.idalmacen);
                 sqlCmd.Parameters.AddWithValue("@idsalida", detalle.idsalida);
                 sqlCmd.Parameters.AddWithValue("@lote", detalle.lote);
                 sqlCmd.Parameters.AddWithValue("@codcontrol", detalle.codcontrol);
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean actualizaControl(int codcontrol)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "update control set codestado='001' where codcontrol=" + codcontrol;
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean pr_actualiza_controlInicial(Cls_Control control)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_actualiza_control_inicial";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;

                 sqlCmd.Parameters.AddWithValue("@usuario", control.usuario);
                 sqlCmd.Parameters.AddWithValue("@fecha", control.fecha);
                 sqlCmd.Parameters.AddWithValue("@observaciones", control.observaciones);
                 sqlCmd.Parameters.AddWithValue("@fechaactual", control.fechaactual);
                 sqlCmd.Parameters.AddWithValue("@codarea", control.codarea);
                 sqlCmd.Parameters.AddWithValue("@codturno", control.codturno);
                 sqlCmd.Parameters.AddWithValue("@codsala", control.codsala);
                 sqlCmd.Parameters.AddWithValue("@codcontrol", control.codcontrol);
              
                

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean pr_modifica_control_detalle(Cls_Control control,Cls_Detalle detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_modifica_control_detalle";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;

                 sqlCmd.Parameters.AddWithValue("@usuariomodifica", control.codusumodifica);
                 sqlCmd.Parameters.AddWithValue("@observaciones", control.observaciones);
                 sqlCmd.Parameters.AddWithValue("@codcontrol", control.codcontrol);
                 sqlCmd.Parameters.AddWithValue("@f_produccion", detalle.f_produccion);
                 sqlCmd.Parameters.AddWithValue("@idsalida", detalle.idsalida);
                 sqlCmd.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                 sqlCmd.Parameters.AddWithValue("@alm_origen", detalle.alm_origen);
                 sqlCmd.Parameters.AddWithValue("@idalmacen", detalle.idalmacen);
                 sqlCmd.Parameters.AddWithValue("@codproceso", detalle.codproceso);
                 sqlCmd.Parameters.AddWithValue("@lote", detalle.lote);
                 sqlCmd.Parameters.AddWithValue("@coddetalle", detalle.coddetalle);
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }


         public Boolean actualizaBloqueo(Cls_Bloqueo bloqueo)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "update tabla_bloqueos set fechaDoc = @fechaDoc , fechaProd =@fechaProd";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.Parameters.AddWithValue("@fechaDoc", bloqueo.fechaDoc);
                 sqlCmd.Parameters.AddWithValue("@fechaProd", bloqueo.fechaProd);

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }


         public Boolean pr_insertaPlanillaPersonal(Cls_Planilla personal)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_insertaPlanillaPersonal";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;

                 sqlCmd.Parameters.AddWithValue("@NumPlanilla", personal.numplanilla);
                 sqlCmd.Parameters.AddWithValue("@codp", personal.codp);
                 sqlCmd.Parameters.AddWithValue("@codpr", personal.codpr);
                 sqlCmd.Parameters.AddWithValue("@codt", personal.codt);
                 sqlCmd.Parameters.AddWithValue("@fecha", personal.fecha);
                 sqlCmd.Parameters.AddWithValue("@hora", personal.hora);
                 sqlCmd.Parameters.AddWithValue("@responsable", personal.responsable);
                 sqlCmd.Parameters.AddWithValue("@confirmacion", personal.confirmacion);
                 sqlCmd.Parameters.AddWithValue("@turno", personal.turno);
                 sqlCmd.Parameters.AddWithValue("@bloque", personal.bloque);
                 sqlCmd.Parameters.AddWithValue("@FecProduc", personal.FecProduc);
                 sqlCmd.Parameters.AddWithValue("@Sala", personal.Sala);
                 sqlCmd.Parameters.AddWithValue("@codturno", personal.codturno);
                 sqlCmd.Parameters.AddWithValue("@codsala", personal.codsala);
                 sqlCmd.Parameters.AddWithValue("@pendiente", personal.pendiente);
                 sqlCmd.Parameters.AddWithValue("@NumPlanilla1", personal.numplanilla1);
                 sqlCmd.Parameters.AddWithValue("@ip", personal.ip );
                 sqlCmd.Parameters.AddWithValue("@tipo2", personal.tipo2);

                 sqlCmd.Parameters.AddWithValue("@idprod", personal.idprod);
                 sqlCmd.Parameters.AddWithValue("@idprest", personal.idprest);

                 
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean pr_insertaReportePersonal(Cls_DetPlanilla personal)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "insert into tabla_reportepersonal (codigo, descripcion) values (@codigo, @descripcion)";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.Text ;


                 sqlCmd.Parameters.AddWithValue("@codigo", personal.codtra);
                 sqlCmd.Parameters.AddWithValue("@descripcion", personal.trabajador);

             

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }



         public Boolean pr_insertaDetallePlanillaPersonal(Cls_DetPlanilla personal)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_insertaDetallePlanillaPersonal";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;

              
                 sqlCmd.Parameters.AddWithValue("@codtra", personal.codtra );
                 sqlCmd.Parameters.AddWithValue("@kilos", personal.kilos );
                 sqlCmd.Parameters.AddWithValue("@numplanilla1", personal.numplanilla );
                 sqlCmd.Parameters.AddWithValue("@ip", personal.ip);
                 sqlCmd.Parameters.AddWithValue("@tipo", personal.tipo);
                 sqlCmd.Parameters.AddWithValue("@codp", personal.codp);
                 sqlCmd.Parameters.AddWithValue("@codpr", personal.codpr);
                 sqlCmd.Parameters.AddWithValue("@codt", personal.codt);
                 sqlCmd.Parameters.AddWithValue("@trabajador", personal.trabajador);

                 sqlCmd.Parameters.AddWithValue("@tipo2", personal.tipo2);
                 sqlCmd.Parameters.AddWithValue("@numplanilla", personal.numplanilla);
                 sqlCmd.Parameters.AddWithValue("@condicion", personal.condicion );
                 sqlCmd.Parameters.AddWithValue("@horas", personal.horas);

                 sqlCmd.Parameters.AddWithValue("@dni", personal.dni);

                 sqlCmd.Parameters.AddWithValue("@idprod", personal.idprod );
                 sqlCmd.Parameters.AddWithValue("@idprest", personal.idprest );
               
               

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaPersonal(Cls_DetPlanilla detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {
                 if (detalle.tipo ==1)
                    sql = "delete from tabla_reportepersonal where id=" + detalle.coddetpla;
                 else
                     sql = "delete from tabla_reportepersonal";


                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.Text ;

                 //sqlCmd.Parameters.AddWithValue("@kilos", detalle.kilos);
                 //sqlCmd.Parameters.AddWithValue("@numplanilla", detalle.numplanilla);
                 //sqlCmd.Parameters.AddWithValue("@tipo", detalle.tipo);
                 //sqlCmd.Parameters.AddWithValue("@tipo2", detalle.tipo2);
                 //sqlCmd.Parameters.AddWithValue("@coddetpla", detalle.coddetpla);
                 //sqlCmd.Parameters.AddWithValue("@ip", detalle.ip);

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaDetallePlanilla(Cls_DetPlanilla detalle)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_eliminaDetallePlanilla";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText= sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;

                 sqlCmd.Parameters.AddWithValue("@kilos", detalle.kilos);
                 sqlCmd.Parameters.AddWithValue("@numplanilla", detalle.numplanilla);
                 sqlCmd.Parameters.AddWithValue("@tipo", detalle.tipo );
                 sqlCmd.Parameters.AddWithValue("@tipo2", detalle.tipo2);
                 sqlCmd.Parameters.AddWithValue("@coddetpla", detalle.coddetpla);
                 sqlCmd.Parameters.AddWithValue("@ip", detalle.ip );
      
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean pr_reprocesaDetallePlanillaPersonal(Cls_DetPlanilla personal)
         {
             Boolean band = true;

             string sql = string.Empty;
             try
             {

                 sql = "pr_reprocesaDetallePlanillaPersonal";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@kilos", personal.kilos);
                 sqlCmd.Parameters.AddWithValue("@numplanilla1", personal.numplanilla);
                 sqlCmd.Parameters.AddWithValue("@ip", personal.ip);
                 sqlCmd.Parameters.AddWithValue("@tipo", personal.tipo);
                 sqlCmd.Parameters.AddWithValue("@tipo2", personal.tipo2);
                 sqlCmd.Parameters.AddWithValue("@numplanilla", personal.numplanilla);
                 sqlCmd.Parameters.AddWithValue("@horas", personal.horas );
                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaPlanillas(Cls_Planilla  planilla)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "delete from t_planilla WHERE (FecProduc Between #" + planilla.sfecha + "# And #" + planilla.sFecProduc + "#)";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;

                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean eliminaDetallePlanillas(Cls_Planilla planilla)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "delete from detplanilla where numplanilla in ( select distinct numplanilla from t_planilla WHERE (( FecProduc Between #" + planilla.sfecha + "# And #" + planilla.sFecProduc + "#)))";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;

                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }
         public Boolean agregaTareas(Cls_Tarea tarea)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "insert into t_tarea(codt ,dest ) values (@codt ,@dest)";
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;
               
                 sqlCmd.Parameters.AddWithValue("@codt", tarea.codt );
                 sqlCmd.Parameters.AddWithValue("@dest", tarea.dest );
               

                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean agregaCabeceraPlanilla(Cls_Planilla  planilla)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "insert into t_planilla(NumPlanilla ,codp,codpr,codt,fecha,hora,responsable,confirmacion,turno,bloque,FecProduc,Sala )";
                 sql = sql+" values (@numPlanilla ,@codp,@codpr,@codt,@fecha,@hora,@responsable,@confirmacion,@turno,@bloque,@FecProduc,@Sala )";
               
                 
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;

                 sqlCmd.Parameters.AddWithValue("@NumPlanilla", planilla.numplanilla);
                 sqlCmd.Parameters.AddWithValue("@codp", planilla.codp);
                 sqlCmd.Parameters.AddWithValue("@codpr", planilla.codpr);
                 sqlCmd.Parameters.AddWithValue("@codt", planilla.codt);
                 sqlCmd.Parameters.AddWithValue("@fecha", planilla.sfecha );
                 sqlCmd.Parameters.AddWithValue("@hora", planilla.hora);
                 sqlCmd.Parameters.AddWithValue("@responsable", planilla.responsable);
                 sqlCmd.Parameters.AddWithValue("@confirmacion", planilla.confirmacion);
                 sqlCmd.Parameters.AddWithValue("@turno", planilla.turno);
                 sqlCmd.Parameters.AddWithValue("@bloque", planilla.bloque);
                 sqlCmd.Parameters.AddWithValue("@FecProduc", planilla.sFecProduc );
                 sqlCmd.Parameters.AddWithValue("@Sala", planilla.Sala);

                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean agregaDetallePlanilla(Cls_DetPlanilla planilla)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "insert into detplanilla(coddetpla ,codtra,kilos,numplanilla)";
                 sql = sql + " values (@coddetpla ,@codtra,@kilos,@numPlanilla)";


                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;

                 sqlCmd.Parameters.AddWithValue("@coddetpla", planilla.coddetpla);
                 sqlCmd.Parameters.AddWithValue("@codtra", planilla.codtra);
                 sqlCmd.Parameters.AddWithValue("@kilos", planilla.kilos );
                 sqlCmd.Parameters.AddWithValue("@numPlanilla", planilla.numplanilla);
               

                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean actualizaCabeceraPlanilla()
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "update t_planilla  set sie=1  where sie is null";
                 
                 OleDbCommand sqlCmd = new OleDbCommand();
                 sqlCmd.Connection = conectarAc;
                 sqlCmd.CommandText = sql;

                 conectarAc.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectarAc.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean actualizaDetallePlanilla(Cls_DetPlanilla planilla)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {
                 //if (planilla.tipo ==1)
                 sql = "update DetPlanilla set codtra='" + planilla.codtra + "',detalleTrabajador='" + planilla.trabajador + "',kilos=" + planilla.kilos + ",horas=" + planilla.horas + ", condicion=" + planilla.condicion + "  where coddetpla=" + planilla.coddetpla;
                 //else
                 //    sql = "update DetPlanilla set codtra='" + planilla.codtra + "',detalleTrabajador='" + planilla.trabajador + "', condicion=" + planilla.condicion + "  where coddetpla=" + planilla.coddetpla;


                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;

                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean insertatarea(Cls_DetPlanilla planilla)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "pr_insertatarea";
                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;
                 sqlCmd.CommandType = CommandType.StoredProcedure;
                 sqlCmd.Parameters.AddWithValue("@descripcion", planilla.trabajador );
                 sqlCmd.Parameters.AddWithValue("@codp", planilla.codp );
                 sqlCmd.Parameters.AddWithValue("@codpr", planilla.codpr );
                 sqlCmd.Parameters.AddWithValue("@tar", planilla.tarifa);
                 sqlCmd.Parameters.AddWithValue("@und", planilla.unidad);

                 sqlCmd.Parameters.AddWithValue("@idprod", planilla.unidad);
                 sqlCmd.Parameters.AddWithValue("@idprest", planilla.unidad);


                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

         public Boolean actualizaTareas(Cls_Tarea tarea)
         {
             Boolean band = true;
             string sql = string.Empty;
             try
             {

                 sql = "update t_tarea set activo=@activo where codt=@codt";



                 SqlCommand sqlCmd = new SqlCommand();
                 sqlCmd.Connection = conectar;
                 sqlCmd.CommandText = sql;

                


                 sqlCmd.Parameters.AddWithValue("@activo", tarea.activo);
                 sqlCmd.Parameters.AddWithValue("@codt", tarea.codt);
            


                 conectar.Open();
                 sqlCmd.ExecuteNonQuery();
                 conectar.Close();
             }
             catch (Exception)
             {
                 band = false;
             }

             return band;
         }

       
   
   }
}
