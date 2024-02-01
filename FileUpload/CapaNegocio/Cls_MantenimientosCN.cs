using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidades;
namespace CapaNegocio
{
    public class Cls_MantenimientosCN
    {

        private string cadena;
        public Cls_MantenimientosCN(string cadena)
        {
            this.cadena = cadena;
        }

        public Boolean eliminaArchivo(string filename)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaArchivo(filename);
            return band;
        }



        public Boolean eliminaPlanillaDet(int idnumdoc)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaPlanillaDet(idnumdoc);
            return band;
        }

        public Boolean agregaGuiasNota(string numdoc2, string serie, string correlativo)
        {
            Cls_MantenimientosCD varMantenimientos  = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.agregaGuiasNota(numdoc2, serie, correlativo);
            return band;
        }

        public Boolean actualizaUsuarios(string codusu, string clave)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaUsuarios(codusu, clave);
            return band;
        }


        public Boolean eliminaGuiasNota(string numdoc2)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaGuiasNota(numdoc2);
            return band;
        }


        public Boolean actualizaDoc_cab(Cls_Doc_cab cab)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaDoc_cab(cab);
            return band;
        }

        public Boolean sp_solicitud_correctivaPreventivaInsercion(string numero, string tipo, string origen, string descripcion, string otro_origen, DateTime fecha, string serie, string doccruce, string doccruce2, string seriecruce, string seriecruce2, Boolean eficaz, string codusu, string areadirigida)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.sp_solicitud_correctivaPreventivaInsercion(numero, tipo, origen, descripcion, otro_origen, fecha, serie, doccruce, doccruce2, seriecruce, seriecruce2, eficaz, codusu, areadirigida);
            return band;
        }

        public Boolean sp_tabla_planActividades_insercion(Cls_planActividades plan)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.sp_tabla_planActividades_insercion(plan);
            return band;
        }


        public Boolean actualizasolicitud_correctivaPreventiva(Cls_SolicitudCorrectivaPreventiva solicitud)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizasolicitud_correctivaPreventiva(solicitud);
            return band;
        }

        public Boolean eliminaOrdenTrabajo(Cls_OrdenTrabajo orden)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaOrdenTrabajo(orden);
            return band;
        }

        public Boolean sp_ordendetrabajo_insercion(Cls_OrdenTrabajo orden)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.sp_ordendetrabajo_insercion(orden);
            return band;
        }

        public Boolean sp_detalleOrdenTrabajo_insercion(Cls_DetalleOrdenTrabajo detalle)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.sp_detalleOrdenTrabajo_insercion(detalle);
            return band;
        }

        public Boolean actualizaOrdenTrabajo(Cls_OrdenTrabajo orden)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaOrdenTrabajo(orden);
            return band;
        }

        public Boolean sp_tabla_detalle_solicitud_correctivaPreventiva_insercion(Cls_DetalleSolicitudCorrectivaPreventiva detalle)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.sp_tabla_detalle_solicitud_correctivaPreventiva_insercion(detalle);
            return band;
        }

        public Boolean eliminaDetalleppAC(string id)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetalleppAC(id);
            return band;
        }

        public Boolean eliminaDetallempAC(string id)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetallempAC(id);
            return band;
        }

        public Boolean eliminaDetalleinAC(string id)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetalleinAC(id);
            return band;
        }

        public Boolean eliminaDetalleperAC(string id)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetalleperAC(id);
            return band;
        }
        public Boolean actualizaPProduccionAC(string id)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaPProduccionAC(id);
            return band;
        }


        public Boolean pr_inserta_control(Cls_Control control)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_inserta_control(control);
            return band;
        }

        public Boolean pr_inserta_detalle(Cls_Detalle detalle)
         {
             Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
             Boolean band = varMantenimientos.pr_inserta_detalle(detalle);
             return band;
         }

        public Boolean eliminaDetalle(int id)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetalle(id);
            return band;
        }

        public Boolean pr_inserta_detalle_modificacion(Cls_Detalle detalle)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_inserta_detalle_modificacion(detalle);
            return band;
        }

        public Boolean actualizaControl(int codcontrol)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos. actualizaControl(codcontrol);
            return band;
        }

        public Boolean pr_actualiza_controlInicial(Cls_Control control)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_actualiza_controlInicial(control);
            return band;
        }

        public Boolean pr_modifica_control_detalle(Cls_Control control, Cls_Detalle detalle)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_modifica_control_detalle(control, detalle);
            return band;
        }


        public Boolean actualizaBloqueo(Cls_Bloqueo bloqueo)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaBloqueo(bloqueo);
            return band;
        }


        public Boolean pr_insertaPlanillaPersonal(Cls_Planilla personal)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_insertaPlanillaPersonal(personal);
            return band;
        }

        public Boolean pr_insertaDetallePlanillaPersonal(Cls_DetPlanilla personal)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_insertaDetallePlanillaPersonal(personal);
            return band;
        }

        public Boolean pr_insertaReportePersonal(Cls_DetPlanilla personal)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_insertaReportePersonal(personal);
            return band;
        }
         public Boolean eliminaPersonal(Cls_DetPlanilla detalle)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaPersonal(detalle);
            return band;
        }

        public Boolean eliminaDetallePlanilla(Cls_DetPlanilla detalle)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetallePlanilla(detalle);
            return band;
        }


        public Boolean pr_reprocesaDetallePlanillaPersonal(Cls_DetPlanilla personal)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.pr_reprocesaDetallePlanillaPersonal(personal);
            return band;
        }

        public Boolean eliminaPlanillas(Cls_Planilla planilla)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaPlanillas(planilla);
            return band;
        }

        public Boolean eliminaDetallePlanillas(Cls_Planilla planilla)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.eliminaDetallePlanillas(planilla);
            return band;
        }


        public Boolean agregaTareas(Cls_Tarea tarea)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.agregaTareas(tarea);
            return band;
        }

        public Boolean agregaCabeceraPlanilla(Cls_Planilla planilla)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.agregaCabeceraPlanilla(planilla);
            return band;
        }

        public Boolean agregaDetallePlanilla(Cls_DetPlanilla planilla)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.agregaDetallePlanilla(planilla);
            return band;
        }

        public Boolean actualizaCabeceraPlanilla()
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaCabeceraPlanilla();
            return band;
        }

        public Boolean actualizaDetallePlanilla(Cls_DetPlanilla planilla)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaDetallePlanilla(planilla);
            return band;
        }

        public Boolean insertatarea(Cls_DetPlanilla planilla)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.insertatarea(planilla);
            return band;
        }

        public Boolean actualizaTareas(Cls_Tarea tarea)
        {
            Cls_MantenimientosCD varMantenimientos = new Cls_MantenimientosCD(cadena);
            Boolean band = varMantenimientos.actualizaTareas(tarea);
            return band;
        }

        }


    }


