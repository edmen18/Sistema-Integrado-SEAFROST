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
using System.Data.Odbc;
//using Oracle.DataAccess.Client;
//using System.Data.OracleClient;




namespace CapaDatos
{
   
   
    public class Cls_ConsultasCD
    {
        private SqlConnection conectar;
        private OleDbConnection conectarAc;
        private string caden;
        //private OracleConnection conectarOracle;

        public Cls_ConsultasCD(string cadena)
        {
            caden = cadena;
            this.conectar = Cls_ConexionCD.conectar(cadena);
            this.conectarAc = Cls_ConexionCD.conectarAccses(cadena);
           
           //this.conectarOracle = Cls_ConexionCD.conectarOracle(cadena);
        }




        public DataTable PR_REPORTESEMAFOROREQUERIMIENTO(int band,DateTime fecha1, DateTime fecha2)
        {
            string sql = string.Empty;
            sql = "PR_REPORTESEMAFOROREQUERIMIENTO";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandTimeout = 10000;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@band", band);
            sqlCmd.Parameters.AddWithValue("@fechaini", fecha1);
            sqlCmd.Parameters.AddWithValue("@fechafin", fecha2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        public DataTable reporte_condicionConsolidado(Cls_Detalle detalle)
        {

            string sql = string.Empty;
            sql = "pr_reporte_condicionConsolidado";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@periodo", detalle.periodo);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable pr_reporteasistencia_general(string fecha)
        {

            string sql = string.Empty;
            sql = "pr_reporteasistencia_general";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable listaPeriodoPlanillaIndividual()
        {

            string sql = string.Empty;
            sql = "select distinct Periodo  from PersonalPlanillaMovimientosIndividual where Periodo >'201409' ORDER BY periodo DESC";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text ;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }




        public List<Cls_anexo_doc_cabGuias> funObtenerCls_anexo_doc_cabGuias(string parNumdoc2)
        {
            List<Cls_anexo_doc_cabGuias> varRespuesta;
            Cls_anexo_doc_cabGuias varFila;
            string sql = string.Empty;
            sql = "select isnull(id,0) as id,isnull(numdoc2,'') as numdoc2,isnull(serie,'') as serie ,isnull(correlativo,'') as correlativo from inyprod_anexo_doc_cabGuias where numdoc2=@numdoc2";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_anexo_doc_cabGuias>();
            while (rs.Read())
            {
                varFila = new Cls_anexo_doc_cabGuias();
                varFila.id = Convert.ToInt32( rs["id"]);
                varFila.numdoc2 = rs["numdoc2"].ToString();
                varFila.serie = rs["serie"].ToString();
                varFila.correlativo  = rs["correlativo"].ToString();
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public List<Cls_Doc_det> funObtenerDoc_detFlitro(string parNumdoc2)
        {
            List<Cls_Doc_det> varRespuesta;
            Cls_Doc_det varFila;
            string sql = string.Empty;
            sql = "select * from v_doc_det_consolidado where numdoc2=@numdoc2";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_Doc_det>();
            while (rs.Read())
            {
                varFila = new Cls_Doc_det();
                varFila.codpro = rs["codpro"].ToString();
                varFila.cantidad = Convert.ToInt32(rs["cantidad"]);
                varFila.unidad = rs["unidad"].ToString();
                varFila.doccruce = rs["doccruce"].ToString();
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public List<Cls_details_reprocesos> funObtenerdetails_reprocesos(string parNumdoc2)
        {
            List<Cls_details_reprocesos> varRespuesta;
            Cls_details_reprocesos varFila;
            string sql = string.Empty;
            sql = "select isnull(idnumdoc,0) as idnumdoc ,isnull(idnumdoc2,0) as idnumdoc2 ,isnull(numdoc2,'') as numdoc2, isnull(detalle,'') as detalle, isnull(fecha,getdate()) as fecha from details_reprocesos where numdoc2=@numdoc2";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_details_reprocesos>();
            while (rs.Read())
            {
                varFila = new Cls_details_reprocesos();
                varFila.idnumdoc =  Convert.ToInt32(rs["idnumdoc"]);
                varFila.idnumdoc2 = Convert.ToInt32(rs["idnumdoc2"]);
                varFila.numdoc2 = rs["numdoc2"].ToString();
                varFila.detalle = rs["detalle"].ToString();
                varFila.fecha = Convert.ToDateTime(  rs["fecha"]);
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public List<Cls_Doc_det> funObtenerDoc_detFlitroCodigoNS(string parNumdoc2)
        {
            List<Cls_Doc_det> varRespuesta;
            Cls_Doc_det varFila;
            string sql = string.Empty;
            sql = "sp_inyplanilla_Doc_detFlitroCodigoNS";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
                  
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
           // sqlCmd.CommandType = CommandType.Text;
            
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_Doc_det>();
            while (rs.Read())
            {
                varFila = new Cls_Doc_det();
                varFila.codpro = rs["codpro"].ToString();
                varFila.cantidad = Convert.ToInt32(rs["cantidad"]);
                varFila.unidad = rs["unidad"].ToString();
                varFila.doccruce = rs["doccruce"].ToString();
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }
       



        public List<Cls_especies_materiaprima> funObtenerespecies_materiaprimaFlitro(int parIdempresa, Boolean parConcurrencia, string parEjercicio)
        {
            List<Cls_especies_materiaprima> varRespuesta;
            Cls_especies_materiaprima varFila;
            string sql = string.Empty;

            sql = "select id ,isnull(ltrim(rtrim(codpro)),'') as codpro,isnull(descripvulgar,'') as descripvulgar ,";
            sql = sql + " isnull(descripespecie,'') as descripespecie ,isnull(idempresa,0) as idempresa,";
            sql = sql + " isnull(concurrencia,0) as concurrencia ,isnull(imagen,'') as imagen,isnull(ejercicio,'') as ejercicio,isnull(calidad,'') as calidad";
            sql = sql + " from   especies_materiaprima where idempresa =@idempresa and concurrencia =@concurrencia and ejercicio=@ejercicio";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.Parameters.AddWithValue("@idempresa", parIdempresa);
            sqlCmd.Parameters.AddWithValue("@concurrencia", parConcurrencia);
            sqlCmd.Parameters.AddWithValue("@ejercicio", parEjercicio);

            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
                      

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();

            varRespuesta = new List<Cls_especies_materiaprima>();
            while (rs.Read())
            {
                varFila = new Cls_especies_materiaprima();

                varFila.codpro = rs["codpro"].ToString();
                varFila.concurrencia = Convert.ToBoolean(rs["concurrencia"]);
                varFila.descripespecie = rs["descripespecie"].ToString();
                varFila.descripvulgar = rs["descripvulgar"].ToString();
                varFila.ejercicio = rs["ejercicio"].ToString();
                varFila.id = Convert.ToInt32(rs["id"]);
                varFila.idempresa = Convert.ToInt32(rs["idempresa"]);
                varFila.imagen = rs["imagen"].ToString();
                varFila.calidad = rs["calidad"].ToString();
                               
                varRespuesta.Add(varFila);
            }

            conectar.Close();
            return varRespuesta;
        }
       
        public List<Cls_CentroCostosPPPCE> funObtenerCentroCostosPPP(string parSerie, string parcodcco2)
        {
            List<Cls_CentroCostosPPPCE> varRespuesta;
            Cls_CentroCostosPPPCE varFila;
            string sql = string.Empty;
            sql = "select codcco,planta,codcco2,serie,valva from v_inyprod_listacentroscostos where codcco2 ='" + parcodcco2 + "'  and serie ='" + parSerie + "'";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();


            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();

            varRespuesta = new List<Cls_CentroCostosPPPCE>();
            while (rs.Read())
            {
                varFila = new Cls_CentroCostosPPPCE();
                varFila.codcco = rs["codcco"].ToString();
                varFila.planta = rs["planta"].ToString();
                varFila.codcco2 = rs["codcco2"].ToString();
                varFila.serie = rs["serie"].ToString();
                varFila.valva = Convert.ToBoolean(rs["valva"]);
                varRespuesta.Add(varFila);
            }

            conectar.Close();
            return varRespuesta;
        }

        public Cls_AccesosModuloInyweb funObtenerCls_AccesosModuloInyweb(string parCodusu, string parModulo, string parOpcion)
        {
            Cls_AccesosModuloInyweb varRespuesta = null;
            string sql = string.Empty;
            sql = "select top 1 isnull(id,0) as id,isnull(codusu,'') as codusu,isnull(modulo,0) as modulo,isnull(opcion,0) as opcion,isnull(p1,0) as p1,isnull(p2,0) as p2,isnull(p3,0) as p3,isnull(p4,0) as p4,isnull(ingreso,0) as ingreso from accesosmoduloinyweb where codusu=@codusu and modulo =@modulo and opcion =@opcion and ingreso=1";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codusu", parCodusu);
            sqlCmd.Parameters.AddWithValue("@modulo", parModulo);
            sqlCmd.Parameters.AddWithValue("@opcion", parOpcion);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_AccesosModuloInyweb();
                varRespuesta.codusu = rs["codusu"].ToString();
                varRespuesta.id = Convert.ToInt32(rs["id"]);
                varRespuesta.ingreso = Convert.ToBoolean(rs["ingreso"]);
                varRespuesta.modulo = Convert.ToInt32(rs["modulo"]);
                varRespuesta.opcion = Convert.ToInt32(rs["opcion"]);
                varRespuesta.p1 = Convert.ToBoolean(rs["p1"]);
                varRespuesta.p2 = Convert.ToBoolean(rs["p2"]);
                varRespuesta.p3 = Convert.ToBoolean(rs["p3"]);
                varRespuesta.p4 = Convert.ToBoolean(rs["p4"]);


            }
            conectar.Close();
            return varRespuesta;
        }
        

        public Cls_DocumRelacionExterno funObtenerDocumRelacionExterno(string parSerieDocOrigen)
        {
            Cls_DocumRelacionExterno varRespuesta = null;
            string sql = string.Empty;
            sql = "select top 1 SerieDocOrigen, SerieDocDestino, TipoTransfer from DocumRelacionExterno where SerieDocOrigen =@SerieDocOrigen and TipoTransfer ='D'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@SerieDocOrigen", parSerieDocOrigen);
           
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_DocumRelacionExterno();
                varRespuesta.SerieDocDestino = rs["SerieDocDestino"].ToString();
                varRespuesta.SerieDocOrigen = rs["SerieDocOrigen"].ToString();
                varRespuesta.TipoTransfer = rs["TipoTransfer"].ToString();
            }
            conectar.Close();
            return varRespuesta;
        }
        
        


        public Cls_estuctura_producto funObtenerEstructuraProductosFiltro(string parCodpro)
        {
            Cls_estuctura_producto varRespuesta = null;
            string sql = string.Empty;
            sql = "select codpro,origen,grupo,especie,presentacion,calidad,tratamiento,agregado,talla,clas_unid,glaseo,congelamiento,cant_empaque,peso_emp_primario,um from v_inyplanilla_PTCompleta where CodPro =@codpro";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codpro", parCodpro);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_estuctura_producto();
                varRespuesta.codpro = rs["codpro"].ToString();
                varRespuesta.origen = rs["origen"].ToString();
                varRespuesta.grupo = rs["grupo"].ToString();
                varRespuesta.especie = rs["especie"].ToString();
                varRespuesta.presentacion = rs["presentacion"].ToString();
                varRespuesta.calidad = rs["calidad"].ToString();
                varRespuesta.tratamiento = rs["tratamiento"].ToString();
                varRespuesta.agregado = rs["agregado"].ToString();
                varRespuesta.talla = rs["talla"].ToString();
                varRespuesta.clas_unid = rs["clas_unid"].ToString();
                varRespuesta.glaseo = rs["glaseo"].ToString();
                varRespuesta.congelamiento = rs["congelamiento"].ToString();
                varRespuesta.cant_empaque = rs["cant_empaque"].ToString();
                varRespuesta.peso_emp_primario = rs["peso_emp_primario"].ToString();
                varRespuesta.um = rs["um"].ToString();

            }
            conectar.Close();
            return varRespuesta;
        }

        public Cls_Productos funObtenerProductosFiltro(string parCodpro)
        {
            Cls_Productos varRespuesta = null;
            string sql = string.Empty;
            sql = "select isnull(idcodpro,0) as idcodpro,isnull(codpro,'') as codpro,isnull(tipoprod,'') as tipoprod,isnull(descrip,'') as descrip,isnull(unidad,'') as unidad,isnull(rend,0) as rend,isnull(subproducto,0) as  subproducto,bloqueado from productos  where CodPro =@codpro";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codpro", parCodpro);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_Productos();
                varRespuesta.idcodpro =Convert.ToInt32(rs["idcodpro"]);
                varRespuesta.codpro = rs["codpro"].ToString();
                varRespuesta.tipoprod =rs["tipoprod"].ToString();
                varRespuesta.descrip = rs["descrip"].ToString();
                varRespuesta.unidad = rs["unidad"].ToString();
                varRespuesta.rend = Convert.ToDouble(rs["rend"]);
                varRespuesta.subproducto = Convert.ToBoolean(rs["subproducto"]);
                varRespuesta.bloqueado = Convert.ToBoolean(rs["bloqueado"]);
               

            }
            conectar.Close();
            return varRespuesta;
        }

        /*******************************************************************/

        public Cls_EtiquetasTrazabilidad funObtenerEtiquetasTrazabilidad(string idnlotehex)
        {
            Cls_EtiquetasTrazabilidad varRespuesta = null;
            string sql = string.Empty;
            sql = "select isnull(idnlotehex,'') as idnlotehex,isnull(codpro,'') as codpro,isnull(nlote,'')as nlote ,";
            sql = sql + " isnull(estadoEtiq,'') as estadoEtiq,isnull(tipoMaster,'') as tipoMaster ,isnull(saldos,0) as saldos,";
            sql = sql + " isnull(sobrantes,0) as sobrantes,isnull(langostineratercero,'') as langostineratercero  ";
            sql = sql + " from inyprod_etiquetastrazabilidad where idnlotehex =@idnlotehex";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@idnlotehex", idnlotehex);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_EtiquetasTrazabilidad();
                varRespuesta.idnlotehex = rs["idnlotehex"].ToString();
                varRespuesta.codpro  = rs["codpro"].ToString();
                varRespuesta.nlote  = rs["nlote"].ToString();
                varRespuesta.estadoEtiq = rs["estadoEtiq"].ToString();
                varRespuesta.tipoMaster = rs["tipoMaster"].ToString();
                varRespuesta.saldos = Convert.ToDouble(rs["saldos"]);
                varRespuesta.sobrantes = Convert.ToDouble(rs["sobrantes"]);
                varRespuesta.langostineratercero = rs["langostineratercero"].ToString();
            

  }
            conectar.Close();
            return varRespuesta;
        }


        /*******************************************************************/


        //public Cls_Usuarios funObtenerUsuarios(string parCodusu)
        //{
        //    Cls_Usuarios varRespuesta = null;
        //    string sql = string.Empty;
        //    sql = "select isnull(idCodUsu,0)  as idCodUsu, isnull(CodUsu,'') as CodUsu ,  isnull(clave,'') as Clave ,isnull(Codper,'') as Codper,isnull(codtipo,'O') as codtipo,isnull(codarea,'') as codarea  from tabla_usuarios where CodUsu = @codusu";
        //    SqlCommand sqlCmd = new SqlCommand();
        //    sqlCmd.Connection = conectar;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.Parameters.AddWithValue("@codusu", parCodusu);
          
        //    conectar.Open();
        //    SqlDataReader rs;
        //    rs = sqlCmd.ExecuteReader();
        //    if (rs.Read())
        //    {
        //        varRespuesta = new Cls_Usuarios();
        //        varRespuesta.clave = rs["Clave"].ToString();
        //        varRespuesta.codper = rs["Codper"].ToString();
        //        varRespuesta.codUsu = rs["CodUsu"].ToString();
        //        varRespuesta.codtipo = rs["codtipo"].ToString();

        //        varRespuesta.idCodUsu = Convert.ToInt32(rs["idCodUsu"]);
               
        //        varRespuesta.codarea = rs["codarea"].ToString();


        //    }
        //    conectar.Close();
        //    return varRespuesta;
        //}

        public Cls_Usuarios funObtenerUsuarios(string parCodusu)
        {
            Cls_Usuarios varRespuesta = null;
            string sql = string.Empty;
            sql = "select  usuario, password , nombres  from  usuario where usuario = @codusu";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codusu", parCodusu);
         
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_Usuarios();
                varRespuesta.usuario = rs["usuario"].ToString();
                varRespuesta.password = rs["password"].ToString();
                varRespuesta.nombres = rs["nombres"].ToString();
                //varRespuesta.apellidos = rs["apellidos"].ToString();
                //varRespuesta.tipousuario = rs["tipousuario"].ToString();
                //varRespuesta.estado = rs["estado"].ToString();

            }
            conectar.Close();
            return varRespuesta;
        }
       

        public Cls_Usuarios funObtenerUsuarios(string parCodusu,string parClave)
        {
            Cls_Usuarios varRespuesta = null;
            string sql = string.Empty;
            sql = "select  id,usuario,password,nombres,sala  from  usuario where usuario = @codusu and password=@clave";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codusu", parCodusu);
            sqlCmd.Parameters.AddWithValue("@clave", parClave);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_Usuarios();
                varRespuesta.usuario = rs["usuario"].ToString();
                varRespuesta.password = rs["password"].ToString();
                varRespuesta.nombres = rs["nombres"].ToString();
            
               
            }
            conectar.Close();
            return varRespuesta;
        }


        public Cls_Empresas funObtenerEmpresasFiltro(int parId)
        {
            Cls_Empresas varRespuesta = null;
            string sql = string.Empty;
            sql = "select top 1 isnull(id,0) as id,isnull(empresa,'') as empresa,isnull(ruc,'') as ruc  from Empresas where id=@id";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@id", parId);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_Empresas();
                varRespuesta.id = Convert.ToInt32(rs["id"]);
                varRespuesta.empresa = rs["empresa"].ToString();
                varRespuesta.ruc = rs["ruc"].ToString();

            }
            conectar.Close();
            return varRespuesta;
        }

        public Cls_SeriesValva funObtenerseriesValva(string parop, string parreferencia, string parCodcco, string parEspecie)
        {
            Cls_SeriesValva varRespuesta = null;
            string sql = string.Empty;
            sql = "select top 1 serie,serieplanilla,codbod ,codcco,siguiente,op ,referencia,codPta ,codCam,tipodoc,especie from v_inyprod_seriesValva where op=@op and referencia =@referencia and Codcco =@codcco and Tipodoc ='O' and especie = @especie";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@op", parop);
            sqlCmd.Parameters.AddWithValue("@referencia", parreferencia);
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            sqlCmd.Parameters.AddWithValue("@especie", parEspecie);

            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_SeriesValva();
                varRespuesta.serie = rs["serie"].ToString();
                varRespuesta.serieplanilla = rs["serieplanilla"].ToString();
                varRespuesta.codbod = rs["codbod"].ToString();
                varRespuesta.codcco = rs["codcco"].ToString();
                varRespuesta.siguiente = rs["siguiente"].ToString();
                varRespuesta.op = rs["op"].ToString();
                varRespuesta.referencia = rs["referencia"].ToString();
                varRespuesta.codPta = rs["codPta"].ToString();
                varRespuesta.codCam = rs["codCam"].ToString();
                varRespuesta.tipodoc = rs["tipodoc"].ToString();
                varRespuesta.especie = rs["especie"].ToString();

            }
            conectar.Close();

            return varRespuesta;
        }

       
        public Cls_Master_Reprocesos funObtenerMaster_Reprocesos(string parNumdoc2)
        {
            Cls_Master_Reprocesos varRespuesta = null;
            string sql = string.Empty;
            sql = "select isnull(idnumdoc2,0) as idnumdoc2 ,isnull(numdoc2,'') as numdoc2,isnull(fecha,getdate()) as fecha from Master_Reprocesos where numdoc2 = @numdoc2";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_Master_Reprocesos();
                varRespuesta.idnumdoc2 = Convert.ToInt32(rs["idnumdoc2"]);
                varRespuesta.numdoc2 = rs["numdoc2"].ToString();
                varRespuesta.fecha = Convert.ToDateTime( rs["fecha"]);
                
            }
            conectar.Close();

            return varRespuesta;
        }
       

        public Cls_Series funObtenerseries(string parserie, string parop)
        {
            Cls_Series varRespuesta = null;

            string sql = string.Empty;

            sql = "select isnull(Tipodoc,'') as Tipodoc ,	isnull(Serie,'') as Serie,	isnull(Descrip,'') as Descrip,	isnull(Serieref,'') as Serieref,isnull(SerieForaneo,'') as SerieForaneo,	isnull(Formato,'')  as Formato,	isnull(Control,'') as Control,	isnull(Codbod,'') as Codbod,";
            sql = sql + " isnull(Codcco,'') as Codcco,	isnull(Codbco,'') as Codbco,	isnull(Correl,0) as Correl,	isnull(Valor1,0) as Valor1,	isnull(Valor2,0) as Valor2,	isnull(Valor3,0) as Valor3,	isnull(Automatico,'') as Automatico,	isnull(Fechamod,getdate()) as Fechamod,";
            sql = sql + " isnull(FechaAutorizaImp,getdate()) as FechaAutorizaImp,	isnull(CodAutorizaImp,'') as CodAutorizaImp,isnull(Operacion_descorto,'') as Operacion_descorto,";
            sql = sql + " isnull(Operacion_deslargo,'') as Operacion_deslargo,	isnull(Tipodoc_descorto,'') as Tipodoc_descorto,isnull(Tipodoc_deslargo,'') as Tipodoc_deslargo,	isnull(Packing,0) as Packing,	isnull(CodusuPacking,'') as CodusuPacking,";
            sql = sql + " isnull(FechamodPacking,getdate()) as FechamodPacking,	isnull(FusionSeriesDoc,getdate()) as FusionSeriesDoc,	isnull(CodPta,'') as CodPta,	isnull(CodCam,'') as CodCam,	isnull(DescripCorto,'') as DescripCorto,	isnull(Id_TipoComprobante,'') as Id_TipoComprobante,";
            sql = sql + " isnull(Id_TipoOperacion,'') as Id_TipoOperacion,	isnull(SunatMedioPago,'') as SunatMedioPago,	isnull(Sede,'') as Sede,	isnull(generaSerieAutomatico,0) as generaSerieAutomatico,	isnull(serie_ni,'') as serie_ni,";
            sql = sql + " isnull(ns,0) as ns,	isnull(tipo,0)as tipo, 	isnull(op,'') as op,	isnull(referencia,0 ) as referencia ";
            sql = sql + " from Series where serie = @serie and op = @op";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@serie", parserie);
            sqlCmd.Parameters.AddWithValue("@op", parop);
            // sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);

            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_Series();
                varRespuesta.Tipodoc = rs["Tipodoc"].ToString();
                varRespuesta.Serie = rs["Serie"].ToString();
                varRespuesta.Descrip = rs["Descrip"].ToString();
                varRespuesta.Serieref = rs["Serieref"].ToString();
                varRespuesta.SerieForaneo = rs["SerieForaneo"].ToString();
                varRespuesta.Formato = rs["Formato"].ToString();
                varRespuesta.Control = rs["Control"].ToString();
                varRespuesta.Codbod = rs["Codbod"].ToString();
                varRespuesta.Codcco = rs["Codcco"].ToString();
                varRespuesta.Codbco = rs["Codbco"].ToString();
                varRespuesta.Correl = Convert.ToDouble(rs["Correl"]);
                varRespuesta.Valor1 = Convert.ToDouble(rs["Valor1"]);
                varRespuesta.Valor2 = Convert.ToDouble(rs["Valor2"]);
                varRespuesta.Valor3 = Convert.ToDouble(rs["Valor3"]);
                varRespuesta.Automatico = rs["Automatico"].ToString();
                varRespuesta.Fechamod = Convert.ToDateTime(rs["Fechamod"]);
                varRespuesta.FechaAutorizaImp = Convert.ToDateTime(rs["FechaAutorizaImp"]);
                varRespuesta.CodAutorizaImp = rs["CodAutorizaImp"].ToString();
                varRespuesta.Operacion_descorto = rs["Operacion_descorto"].ToString();
                varRespuesta.Operacion_deslargo = rs["Operacion_deslargo"].ToString();
                varRespuesta.Tipodoc_descorto = rs["Tipodoc_descorto"].ToString();
                varRespuesta.Tipodoc_deslargo = rs["Tipodoc_deslargo"].ToString();
                varRespuesta.Packing = Convert.ToInt32(rs["Packing"]);
                varRespuesta.CodusuPacking = rs["CodusuPacking"].ToString();
                varRespuesta.FechamodPacking = Convert.ToDateTime(rs["FechamodPacking"]);
                varRespuesta.FusionSeriesDoc = rs["FusionSeriesDoc"].ToString();
                varRespuesta.CodPta = rs["CodPta"].ToString();
                varRespuesta.CodCam = rs["CodCam"].ToString();
                varRespuesta.DescripCorto = rs["DescripCorto"].ToString();
                varRespuesta.Id_TipoComprobante = rs["Id_TipoComprobante"].ToString();
                varRespuesta.Id_TipoOperacion = rs["Id_TipoOperacion"].ToString();
                varRespuesta.SunatMedioPago = rs["SunatMedioPago"].ToString();
                varRespuesta.Sede = rs["Sede"].ToString();
                varRespuesta.generaSerieAutomatico = Convert.ToBoolean(rs["generaSerieAutomatico"].ToString());
                varRespuesta.serie_ni = rs["Tipodoc"].ToString();
                varRespuesta.ns = Convert.ToBoolean(rs["ns"]);
                varRespuesta.tipo = Convert.ToBoolean(rs["tipo"]);
                varRespuesta.op = rs["op"].ToString();
                varRespuesta.referencia = Convert.ToInt32(rs["referencia"]);

            }
            conectar.Close();

            return varRespuesta;
        }

        public Cls_ComparativoCab funObtenerComparativoCab(string numdoc2)
        {
            Cls_ComparativoCab varRespuesta = null;

            string sql = string.Empty;

            sql = "select dbo.obtensiglasxni(@numdoc2 ) as sigla,dbo.HallaNloteTotal(@numdoc2) as nlote";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_ComparativoCab();
                varRespuesta.sigla = rs["sigla"].ToString();
                varRespuesta.nlote = rs["nlote"].ToString();
            }
            conectar.Close();

            return varRespuesta;
        }

        public Cls_planillaCab funObtenerplanillaCab(string numdoc2)
        {
            Cls_planillaCab varRespuesta = null;
            string sql = string.Empty;
            sql = "SELECT isnull(IdNumdoc2,0) as  IdNumdoc2, isnull(Numdoc2,'') as Numdoc2, isnull(ActualizaOk,0) as  ActualizaOk";
            sql = sql + " ,isnull(TipoOp,'') as TipoOp , isnull(FECHA,'') as fecha , isnull(DFECHA,'') as DFECHA , isnull(PERIODO ,'') as periodo, isnull(CODTER ,'') as codter, isnull(Idcodter,0) as  Idcodter";
            sql = sql + " ,isnull(DESTER ,'') as dester, isnull(ESTADO,'') as estado , isnull(CODBOD,'') as  CODBOD, isnull(Idcodbod,0) as  Idcodbod , isnull(CODCCO,'') as codcco, isnull(Idcodcco,0) as Idcodcco";
            sql = sql + " ,isnull(ESTADO2,'') as  ESTADO2 , isnull(DOCREFER,'') as  DOCREFER, isnull(DOCCRUCE,'') as  DOCCRUCE , isnull(CODUSU,'') as  CODUSU , isnull(ESTADOG ,'') as ESTADOG , isnull(CodusuVB,'') as  CodusuVB";
            sql = sql + " ,isnull(FechaVB,GETDATE()) as  FechaVB, isnull(Fechamod ,GETDATE()) as Fechamod, isnull(CodPta ,'') as CodPta, isnull(ConMeta ,0) as ConMeta , isnull(ConCajita,0) as ConCajita , isnull(ConFunda,0) as  ConFunda";
            sql = sql + " ,isnull(CodccoPropio,'') as  CodccoPropio, isnull(LangostineraTercero ,'') as LangostineraTercero, isnull(PozaTercero ,'') as PozaTercero";
            sql = sql + " ,isnull(PropioAcopio,0) as PropioAcopio, isnull(PropioCampos ,0) as PropioCampos, isnull(DeTercero ,0) as DeTercero, isnull(DocCruceNI,'') as DocCruceNI";
            sql = sql + " ,isnull(NumPedidoRemoto,0)  as NumPedidoRemoto, isnull(statusPedidoRemoto,'') as  statusPedidoRemoto, isnull(numDERMB,'') as  numDERMB, isnull(PE ,'') as PE, isnull(PropioMixto,0) as  PropioMixto, isnull(LangostineraTerceroiny,'') as  LangostineraTerceroiny, isnull(PozaTerceroiny ,'') as PozaTerceroiny from INYProd_PlanillaProduccionCab where doccruce = @numdoc2";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();

            if (rs.Read())
            {
                varRespuesta = new Cls_planillaCab();
                varRespuesta.ActualizaOk = Convert.ToBoolean(rs["ActualizaOk"]);
                varRespuesta.CODBOD = rs["CODBOD"].ToString();
                varRespuesta.CODCCO = rs["CODCCO"].ToString();
                varRespuesta.CodccoPropio = rs["CodccoPropio"].ToString();
                varRespuesta.CodPta = rs["CodPta"].ToString();
                varRespuesta.CODTER = rs["CODTER"].ToString();
                varRespuesta.CODUSU = rs["CODUSU"].ToString();
                varRespuesta.CodusuVB = rs["CodusuVB"].ToString();
                varRespuesta.ConCajita = Convert.ToBoolean(rs["ConCajita"]);
                varRespuesta.ConFunda = Convert.ToBoolean(rs["ConFunda"]);
                varRespuesta.ConMeta = Convert.ToBoolean(rs["ConMeta"]);
                varRespuesta.DESTER = rs["DESTER"].ToString();
                varRespuesta.DeTercero = Convert.ToBoolean(rs["DeTercero"]);
                varRespuesta.DFECHA = Convert.ToDateTime(rs["DFECHA"]);
                varRespuesta.DOCCRUCE = rs["DOCCRUCE"].ToString();
                varRespuesta.DocCruceNI = rs["DocCruceNI"].ToString();
                varRespuesta.DOCREFER = rs["DOCREFER"].ToString();
                varRespuesta.ESTADO = rs["ESTADO"].ToString();
                varRespuesta.ESTADO2 = rs["ESTADO2"].ToString();
                varRespuesta.ESTADOG = rs["ESTADOG"].ToString();
                varRespuesta.FECHA = rs["FECHA"].ToString();
                varRespuesta.Fechamod = Convert.ToDateTime(rs["Fechamod"]);
                varRespuesta.FechaVB = Convert.ToDateTime(rs["FechaVB"]);
                varRespuesta.Idcodbod = Convert.ToInt32(rs["Idcodbod"]);
                varRespuesta.Idcodcco = Convert.ToInt32(rs["Idcodcco"]);
                varRespuesta.Idcodter = Convert.ToInt32(rs["Idcodter"]);
                varRespuesta.IdNumdoc2 = Convert.ToInt32(rs["IdNumdoc2"]);
                varRespuesta.LangostineraTercero = rs["LangostineraTercero"].ToString();
                varRespuesta.LangostineraTerceroiny = rs["LangostineraTerceroiny"].ToString();
                varRespuesta.numDERMB = rs["numDERMB"].ToString();
                varRespuesta.Numdoc2 = rs["Numdoc2"].ToString();
                varRespuesta.NumPedidoRemoto = Convert.ToInt32(rs["NumPedidoRemoto"]);
                varRespuesta.PE = rs["PE"].ToString();
                varRespuesta.PERIODO = rs["PERIODO"].ToString();
                varRespuesta.PozaTercero = rs["PozaTercero"].ToString();
                varRespuesta.PozaTerceroiny = rs["PozaTerceroiny"].ToString();
                varRespuesta.PropioAcopio = Convert.ToBoolean(rs["PropioAcopio"]);
                varRespuesta.PropioCampos = Convert.ToBoolean(rs["PropioCampos"]);
                varRespuesta.PropioMixto = Convert.ToBoolean(rs["PropioMixto"]);
                varRespuesta.statusPedidoRemoto = rs["statusPedidoRemoto"].ToString();
                varRespuesta.TipoOp = rs["TipoOp"].ToString();
            }
            conectar.Close();

            return varRespuesta;
        }

        public Cls_planillaCab sp_planilla_obtenLangostineraPozaReprocesosTerceros(string numdoc2)
        {
            Cls_planillaCab varRespuesta = null;
            string sql = string.Empty;
            sql = "sp_planilla_obtenLangostineraPozaReprocesosTerceros";
            SqlParameter langtercero, pozatercero;
            SqlCommand sqlCmd = new SqlCommand();
            
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            
            langtercero = sqlCmd.Parameters.Add("@LangostineraTercero", SqlDbType.VarChar, 20);
            pozatercero = sqlCmd.Parameters.Add("@pozatercero", SqlDbType.VarChar, 20);
            langtercero.Direction = ParameterDirection.Output;
            pozatercero.Direction = ParameterDirection.Output;
 

            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();
            sqlCmd.ExecuteNonQuery();
            
            conectar.Close();
            varRespuesta = new Cls_planillaCab();
            varRespuesta.LangostineraTercero = langtercero.Value.ToString();
            varRespuesta.PozaTercero = pozatercero.Value.ToString();
           
           
            return varRespuesta;
        }
               
        public Cls_planillaCab sp_inyprod_setLangostineraPozaTeceroReetiquetado(string numdoc2)
        {
            Cls_planillaCab varRespuesta = null;
            string sql = string.Empty;
            sql = "sp_inyprod_setLangostineraPozaTeceroReetiquetado";
          //  SqlParameter langtercero, pozatercero;
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);

            //langtercero = sqlCmd.Parameters.Add("@LangostineraTercero", SqlDbType.VarChar, 20);
            //pozatercero = sqlCmd.Parameters.Add("@pozatercero", SqlDbType.VarChar, 20);
            //langtercero.Direction = ParameterDirection.Output;
            //pozatercero.Direction = ParameterDirection.Output;


            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();
            //sqlCmd.ExecuteNonQuery();

            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_planillaCab();
                varRespuesta.LangostineraTercero = rs["LangostineraTercero"].ToString(); ;
                varRespuesta.PozaTercero = rs["PozaTercero"].ToString(); 
            }
            conectar.Close();



            //conectar.Close();
            //varRespuesta = new Cls_planillaCab();
            //varRespuesta.LangostineraTercero = langtercero.Value.ToString();
            //varRespuesta.PozaTercero = pozatercero.Value.ToString();


            return varRespuesta;
        }
                
        public Cls_Doc_cab funObtenerdoc_Cab(string numdoc2)
        {
            Cls_Doc_cab varRespuesta = null;
            string sql = string.Empty;
            sql = "select * from v_doc_cab_consolidado where numdoc2 = @numdoc2";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_Doc_cab();
                varRespuesta.IdNumdoc2 = Convert.ToInt32(rs["IdNumdoc2"]);
                varRespuesta.Numdoc2 = rs["Numdoc2"].ToString();
                varRespuesta.ActualizaOk = Convert.ToBoolean(rs["ActualizaOk"]);
                varRespuesta.TipoOp = rs["TipoOp"].ToString();
                varRespuesta.FECHA = rs["FECHA"].ToString();
                varRespuesta.DFECHA = Convert.ToDateTime(rs["DFECHA"]);
                varRespuesta.PERIODO = rs["PERIODO"].ToString();
                varRespuesta.CODTER = rs["CODTER"].ToString();
                varRespuesta.Idcodter = Convert.ToInt32(rs["Idcodter"]);
                varRespuesta.DESTER = rs["DESTER"].ToString();
                varRespuesta.ESTADO = rs["ESTADO"].ToString();
                varRespuesta.CODBOD = rs["CODBOD"].ToString();
                varRespuesta.Idcodbod = Convert.ToInt32(rs["Idcodbod"]);
                varRespuesta.CODCCO = rs["CODCCO"].ToString();
                varRespuesta.Idcodcco = Convert.ToInt32(rs["Idcodcco"]);
                varRespuesta.CODUSU = rs["CODUSU"].ToString();
                varRespuesta.ESTADOG = rs["ESTADOG"].ToString();
                varRespuesta.CodusuVB = rs["CodusuVB"].ToString();
                varRespuesta.FechaVB = Convert.ToDateTime(rs["FechaVB"]);
                varRespuesta.Fechamod = Convert.ToDateTime(rs["Fechamod"]);
                varRespuesta.FlagVB = Convert.ToBoolean(rs["FlagVB"]);
                varRespuesta.codtervb = rs["codtervb"].ToString();
                varRespuesta.numDERMB = rs["numDERMB"].ToString();
                
                varRespuesta.nloteni = rs["nloteni"].ToString();
                varRespuesta.OBSERV2 = rs["OBSERV2"].ToString();
                varRespuesta.ProcedenciaPesca = rs["ProcedenciaPesca"].ToString();
                varRespuesta.EMBARQUE = rs["EMBARQUE"].ToString();
                varRespuesta.PLACAVEH = rs["PLACAVEH"].ToString();
                varRespuesta.matriculaEmbarcacion = rs["matriculaEmbarcacion"].ToString();
                varRespuesta.poza = rs["poza"].ToString();
                varRespuesta.guiaRemision = rs["guiaRemision"].ToString();
                varRespuesta.idcodemb = Convert.ToInt32(rs["idcodemb"]);
                varRespuesta.numMallas = Convert.ToInt32(rs["numMallas"]);
                varRespuesta.numManojos = Convert.ToDouble(rs["numManojos"]);
                varRespuesta.frecepcion = Convert.ToDateTime(rs["frecepcion"]);
                varRespuesta.plantaproceso = rs["plantaproceso"].ToString();
                
                varRespuesta.CODBOD2 = rs["CODBOD2"].ToString();
                varRespuesta.idCodcco2 = Convert.ToInt32(rs["idCodcco2"]);

                varRespuesta.numdocrefer2 = rs["numdocrefer2"].ToString();
               
            }
            conectar.Close();

            return varRespuesta;
        }

        public Cls_InicalLote funObtenerInicalLoteFiltro(string parDescripVulgar)
        {
            Cls_InicalLote varRespuesta = null;
            string sql = string.Empty;
            sql = "SELECT  isnull(id,0) as id, isnull(InicialLote,'') as InicialLote, isnull(DescripVulgar,'') as DescripVulgar  FROM inyprod_InicalLote where DescripVulgar = @DescripVulgar";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@DescripVulgar", parDescripVulgar);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_InicalLote();
                varRespuesta.id = Convert.ToInt32(rs["id"]);
                varRespuesta.InicialLote = rs["InicialLote"].ToString();
                varRespuesta.DescripVulgar = rs["DescripVulgar"].ToString(); ;
            }
            conectar.Close();

            return varRespuesta;
        }


      
        public Cls_AnexoDocCAb funObtenerAnexoDocCAb(string parNumdoc2)
        {
            Cls_AnexoDocCAb varRespuesta = null;
            string sql = string.Empty;
            sql = "select isnull(idnumdoc2,0) as idnumdoc2,isnull(numdoc2,'') as numdoc2,isnull(color,'') as color , isnull(codlang,'') as codlang,isnull(poza,'') as poza,isnull(factor,0) as factor from inyprod_anexo_doc_cab where numdoc2 =@numdoc2";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
           

            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_AnexoDocCAb();
                varRespuesta.IdNumdoc2 = Convert.ToInt32(rs["idnumdoc2"]);
                varRespuesta.Numdoc2 = rs["Numdoc2"].ToString();
                varRespuesta.color = rs["color"].ToString();
                varRespuesta.codlang = rs["codlang"].ToString();
                varRespuesta.poza  = rs["poza"].ToString();
                varRespuesta.factor = Convert.ToDouble(rs["factor"]);
                
            }
            conectar.Close();

            return varRespuesta;
        }

      
        /*********************************************************/
        public DataTable sp_inyprod_devuelveInsumosFacturables(string numdoc2, string codper , int  tipo)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_devuelveInsumosFacturables";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            sqlCmd.Parameters.AddWithValue("@codper", codper);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
           
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }


        public DataTable sp_inyplanilla_datosdetreporetpp(string numdoc2,int tipo)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_datosdetreporetppx2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        /*********************************************************/



        public DataTable sp_inyprod_partes_reprocesos_pendientes(string codcco , Boolean  acopio, Boolean campos , Boolean tercero )
        {
            string sql = string.Empty;
            sql = "sp_inyprod_partes_reprocesos_pendientes";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", codcco);
            sqlCmd.Parameters.AddWithValue("@acopio", acopio);
            sqlCmd.Parameters.AddWithValue("@campos", campos);
            sqlCmd.Parameters.AddWithValue("@tercero", tercero);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
                    
        public DataTable sp_inyprod_listaPartesReetiquetadosPendientes(string parOp,string parCodcco,string parReferencia)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_listaPartesReetiquetadosPendientes";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@op", parOp);
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            sqlCmd.Parameters.AddWithValue("@referencia", parReferencia);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerOrigenNoConformidad()
        {
            string sql = string.Empty;
            sql = "SELECT id,codorigen,detalle FROM tabla_origenNoConformidad";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }



        public DataTable sp_inyprod_notasSalidaPendientesCruce(string codcco , string op , int referencia )
        {
            string sql = string.Empty;
            sql = "sp_inyprod_notasSalidaPendientesCruce";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", codcco);
            sqlCmd.Parameters.AddWithValue("@op", op);
            sqlCmd.Parameters.AddWithValue("@referencia", referencia);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
       
        public DataTable sp_inyprod_listaPartesReetiquetadosPendientes(string op ,string codcco , int referencia)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_listaPartesReetiquetadosPendientes";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@op", op);
            sqlCmd.Parameters.AddWithValue("@codcco", codcco);
            sqlCmd.Parameters.AddWithValue("@referencia", referencia);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
       
        public DataTable sp_inyplanilla_Tabla_Maestroxreproceso(string parCodcco)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_Tabla_Maestroxreproceso";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        
        public DataTable sp_inyplanilla_muestrasincruce_ns(string parCodcco,int partipo)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_muestrasincruce_ns";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            sqlCmd.Parameters.AddWithValue("@tipo", partipo);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable sp_inyplanilla_Tabla_Maestrox2(string parCodcco)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_Tabla_Maestrox2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable sp_inyplanilla_Tabla_MaestroxCamposx2(string parCodcco)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_Tabla_MaestroxCamposx2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable sp_inyplanilla_Tabla_Maestro_terceros(string parCodcco)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_Tabla_Maestro_terceros";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable sp_inyplanilla_Tabla_Maestro_terceros_abc(string parCodcco)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_Tabla_Maestro_terceros_abc";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
            
        public DataTable funObtenerdatosComparativoReetiquetado(string parnumdoc2)
        {
            string sql = string.Empty;
            sql = "select d.codpro,d.glosa as descrip,d.cantidad as cantPP,0 as cantCamara,d.unidad ,0 as nroEtiqUsadas,0 as nroEtiqActivas,0 as nroEtiqBloqueadas,0 as nroEtiqanuladas,0 as nroEtiqImpresas from Doc_det d inner join productos p on d.codpro = p.codpro  where d.Numdoc2 =@numdoc2 and p.tipoprod not in (5,6)";
            DataTable dt = new DataTable ();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parnumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }


        public DataTable funObtenerArchivos()
        {
            string sql = string.Empty;
            sql = "select ROW_NUMBER() OVER(Order by f.codarea ) as item,f.fileid,f.filename,(select a.detalle from tabla_areas a where a.codarea=f.codarea) as area,f.codusu,f.fechamod from   FilesContent f order by area";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerArchivos(string codarea)
        {
            string sql = string.Empty;
            sql = "select ROW_NUMBER() OVER(Order by f.fileid desc) as item,f.fileid,f.filename,(select a.detalle from tabla_areas a where a.codarea=f.codarea) as area,f.codusu,f.fechamod from   FilesContent f where f.codarea=@codarea";

            sql = sql +" union all select ROW_NUMBER() OVER(Order by f.fileid desc) as item,f.fileid,f.filename,(select a.detalle from tabla_areas a where a.codarea=f.codarea) as area,f.codusu,f.fechamod from   FilesContent f where f.codarea='018' order by area";

            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.Parameters.AddWithValue("@codarea", codarea);
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerAreas(string parCodarea)
        {
            string sql = string.Empty;
            sql = "select isnull(idarea,0) as idarea,isnull(codarea,'') as codareas,isnull(detalle,'') as detalle from tabla_areas where codarea= @codarea";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codarea", parCodarea);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        public DataTable funObtenerAreas()
        {
            string sql = string.Empty;
            sql = "select isnull(idarea,0) as idarea,isnull(codarea,'') as codareas,isnull(detalle,'') as detalle from tabla_areas";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        public DataTable funObtenerUnidadesMedida()
        {
            string sql = string.Empty;
            sql = "select * from  tabla_unidades";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerTipoPresupuesto()
        {
            string sql = string.Empty;
            sql = "select * from  tabla_tipoPresupuesto";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerTipodeOrden()
        {
            string sql = string.Empty;
            sql = "select * from  tabla_tipoOrden";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenertipoMantenimiento()
        {
            string sql = string.Empty;
            sql = "select * from  tabla_tipoMantenimiento";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerdatosComparativo(string parnumdoc2)
        {
            string sql = string.Empty;
            sql = "select i.codpro, dbo.RetornaDescripCorta (i.descrip) as descrip,i.cantidadplanilla as cantPP,i.cantidadcamara as cantCamara,(select top 1 p.unidad from Productos p where p.codpro=i.codpro  ) as unidad , i.etiqusadas as nroEtiqUsadas,i.Etiqactivas as nroEtiqActivas,i.etiqbloq as nroEtiqBloqueadas,i.Etiqanulada  as nroEtiqanuladas,i.Etiqimpresas as nroEtiqImpresas  from INYProd_PlanillaProdCamaraxpp i where i.numdoc2 = @numdoc2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parnumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerDTISValva_DT(string parcodcco)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_listaNIValvas";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parcodcco);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        
        public DataTable sp_inyprod_consolidadosCuCosteo(string parnumdoc2)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_consolidadosCuCosteo";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parnumdoc2);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerEmpresas(int idempresa)
        {
            string sql = string.Empty;

            if (idempresa == 1)
            {
                sql = "select id,empresa from empresas";
            }
            if (idempresa == 2)
            {
                sql = "select id,empresa from empresas order by empresa desc";
            }


           // sql = "select id,empresa from empresas order by empresa desc";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerEjerciciosActivos(int anio )
        {
            string sql = string.Empty;
            
            sql = "SELECT  id, ejercicio, activo FROM  ejercicios WHERE activo = 1 and ejercicio= @anio union all SELECT  id, ejercicio, activo FROM  ejercicios WHERE activo = 1 and ejercicio<> @anio";
            
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@anio", anio);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
               
        public DataTable funObtenerProductosActivos(string codigo , int tipo , string planta, string cod)
        {
            string sql = string.Empty;

            DataTable dt = new DataTable();

           
             try
             {

            sql = "sp_iny_planilla_productoxpr_pruebaxj";
          
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            sqlCmd.Parameters.AddWithValue("@planta", planta);
            sqlCmd.Parameters.AddWithValue("@cod", cod);
            
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
          

             }
             catch (Exception)
             {
                 dt = null;
             }

             return dt;
        }

         public DataTable sp_inyplanilla_CAxPE(int parTipo,string parPlanta ,string parCod , string  parNumdoc2 )
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_CAxPE";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@tipo", parTipo);
            sqlCmd.Parameters.AddWithValue("@planta", parPlanta);
            sqlCmd.Parameters.AddWithValue("@cod", parCod);
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

         public DataTable sp_inyplanilla_CAxPExfiltro(int parTipo,string parPlanta , string  parNumdoc2 )
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_CAxPExfiltro";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@tipo", parTipo);
            sqlCmd.Parameters.AddWithValue("@planta", parPlanta);
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

                   
        public DataTable funObtenerProductosActivosFiltro(string codigo, int tipo, string planta)
        {
            string sql = string.Empty;
            DataTable dt = new DataTable();
           
             try
             {

            
            sql = "sp_iny_planilla_productoxpr_pruebaxfiltro";
            
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            sqlCmd.Parameters.AddWithValue("@planta", planta);
          

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
           // return dt;
             }
             catch (Exception)
             {
                 dt = null;
             }

             return dt;

        }

        public DataTable funObtenerDetalleConsumo(string codcco , string  numdoc2 , int toper , string numpp)
        {
            string sql = string.Empty;
            sql = "sp_inyplanilla_detalle_partex2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", codcco);
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            sqlCmd.Parameters.AddWithValue("@toper", toper);
            sqlCmd.Parameters.AddWithValue("@numpp", numpp);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerDetallePlanilla(string numdoc2)
        {
            string sql = string.Empty;
            sql = "select * from v_inyprod_PlanillaProducciondet where numdoc2= @numdoc2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
                            
        public DataTable funObtenerDetalleDTIValva(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "select d.numdoc2,d.codpro,d.glosa,case when d.unidad ='LB' then d.cantidad/2.2 else d.Cantidad end as cantidad ";
            sql = sql + " ,d.unidad  from Doc_cab c inner join Doc_det d on c.Numdoc2 = d.Numdoc2 ";
            sql = sql + " where c.Numdoc2 in (select distinct left(r.Detalle,15) from Details_Reprocesos r ";
            sql = sql + " where r.numdoc2 =@numdoc2) and d.Debcre ='C' and c.valva ='1' order by d.Numdoc2 ,d.Glosa";
            DataTable dt = new DataTable();
            string[] columnas = new string[] { "numdoc2", "codpro", "glosa", "cantidad", "unidad" };
             foreach (string col in columnas)
            {
                dt.Columns.Add(new DataColumn(col));
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            
            while (rs.Read())
            {
                 DataRow datarw;
                 datarw = dt.NewRow();
                 datarw[0] = rs["numdoc2"].ToString();
                 datarw[1] = rs["codpro"].ToString();
                 datarw[2] = rs["glosa"].ToString();
                 datarw[3] = Math.Round( Convert.ToDouble( rs["cantidad"]),2);
                 datarw[4] = rs["unidad"].ToString();
                 dt.Rows.Add(datarw);
            }
            conectar.Close();
            return dt;
        }
          
        public DataTable funObtenerAnexoGuiasFiltro(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "select serie,correlativo  from inyprod_anexo_doc_cabGuias where numdoc2 =@numdoc2";
            DataTable dt = new DataTable();
            string[] columnas = new string[] { "serie", "correlativo"};
            foreach (string col in columnas)
            {
                dt.Columns.Add(new DataColumn(col));
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();

            while (rs.Read())
            {
                DataRow datarw;
                datarw = dt.NewRow();
                datarw[0] = rs["serie"].ToString();
                datarw[1] = rs["correlativo"].ToString();
                dt.Rows.Add(datarw);
            }
            conectar.Close();
            return dt;
        }
        
        public DataTable funObtenerCentroCostosPPP_DT(string parcodcco2, string parSerie)
        {
            string sql = string.Empty;
            sql = "select codcco,planta,codcco2,serie,valva,codcco+'$'+valva as otro  from v_inyprod_listacentroscostos where codcco2 ='" + parcodcco2 + "'  and serie ='" + parSerie + "'";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }

        public DataTable funObtenerRecortesppp(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "select dbo.retornadescripcorta(Glosa) as glosa, round(Cantidad,2) as cantidad,unidad from Doc_det where Numdoc2 ='" + parNumdoc2 + "' and Debcre ='D' and";
            sql = sql + " Codpro in ('12201500100000000010000K','122015T0000000000010000K')";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }
               
        public DataTable sp_inyprod_reporte_dt(string parCodcco, string parPeriodo,string parNumdoc2,string parFecha)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_reporte_dt";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            sqlCmd.Parameters.AddWithValue("@periodo", parPeriodo);
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.Parameters.AddWithValue("@fecha", parFecha);
            
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }


        public DataTable sp_inyprod_retornaDetalleNotaSalidaReetiquetado(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_retornaDetalleNotaSalidaReetiquetado";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        
        public DataTable sp_inyprod_reporte_ppp(string parCodcco, string parPeriodo, string parNumdoc2, string parFecha)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_reporte_ppp";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            sqlCmd.Parameters.AddWithValue("@periodo", parPeriodo);
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.Parameters.AddWithValue("@fecha", parFecha);

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable sp_inyprod_concatenapresentaciones(string parCodcco, int parTipo)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_concatenapresentaciones";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codcco", parCodcco);
            sqlCmd.Parameters.AddWithValue("@tipo", parTipo);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable sp_inyprod_potappp(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "sp_inyprod_potappp";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerDetalleNS(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "sp_iny_planilla_muestradetalleNSx2";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 1000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
              

        public DataTable funObtenerPlanillaProducciondet(string parNumdoc2)
        {
            string sql = string.Empty;
            sql = "select nitem,codpro,glosa,cantidad,unidad,nummaster,numempaqueprimario,codusu,fechamod, ";
            sql = sql + " numdoc,idnumdoc,estado,insumo,inicial_insumo,codplanta,planta,Numdoc2,doccruce";
            sql = sql + " from v_inyprod_PlanillaProducciondet where numdoc2 =@numdoc2 order by nitem";
            DataTable dt = new DataTable();
            string[] columnas = new string[] { "Item", "codpro", "Descripcion", "Peso", "Um", "Master",
            "cajitas", "Codusu", "Fecha" ,"NumPlanillaprodOrig","IdNumdoc","NumPlanillaprod","Insumo","cod_insumo",
            "cod_planta","Planta"};
            
            foreach (string col in columnas)
            {
                dt.Columns.Add(new DataColumn(col));
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", parNumdoc2);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();

            while (rs.Read())
            {
                DataRow datarw;
                datarw = dt.NewRow();
                datarw[0] = rs["nitem"].ToString();
                datarw[1] = rs["codpro"].ToString();
                datarw[2] = rs["glosa"].ToString();
                datarw[3] = Math.Round(Convert.ToDouble(rs["cantidad"]), 2);
                datarw[4] = rs["unidad"].ToString();
                datarw[5] = Convert.ToInt32(rs["nummaster"]);
                datarw[6] = Convert.ToInt32(rs["numempaqueprimario"]);
                datarw[7] = rs["codusu"].ToString();
                datarw[8] = rs["fechamod"].ToString();
                datarw[9] = rs["numdoc"].ToString();
                datarw[10] = Convert.ToInt32(rs["idnumdoc"]);
                datarw[11] = rs["estado"].ToString();
                datarw[12] = rs["insumo"].ToString();
                datarw[13] = rs["inicial_insumo"].ToString();
                datarw[14] = rs["codplanta"].ToString();
                datarw[15] = rs["planta"].ToString();
               // datarw[16] = rs["Numdoc2"].ToString();
              //  datarw[17] = rs["doccruce"].ToString();
                dt.Rows.Add(datarw);
            }
            conectar.Close();
            return dt;
        }


        public Cls_SolicitudCorrectivaPreventiva funSolicitudCorrectivaPreventivaObtenerNumeroSiguiente(string serie )
        {
            Cls_SolicitudCorrectivaPreventiva varRespuesta = null;
            string sql = string.Empty;
            sql = "select [dbo].[funcion_gestion_numerosiguiente](@serie) as numero";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.Parameters.AddWithValue("@serie", serie);

            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_SolicitudCorrectivaPreventiva();
                varRespuesta.numero = rs["numero"].ToString();
              

            }
            conectar.Close();

            return varRespuesta;
        }


        //public DataTable funObtenersolicitud_correctivaPreventiva( string serie )
        //{
        //    string sql = string.Empty;
        //    sql = "SELECT id, numero, tipo, origen, descripcion, otro_origen, fecha, doccruce, serie, seriecruce  FROM tabla_solicitud_correctivaPreventiva  where  serie = @serie"; 
        //    DataTable dt = new DataTable();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    sqlCmd.Connection = conectar;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.Parameters.AddWithValue("@serie", serie);
        //    sqlCmd.CommandType = CommandType.Text;
        //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        //    conectar.Open();
        //    da.Fill(dt);
        //    return dt;
        //}
        public DataTable funObtenersolicitud_correctivaPreventiva(string serie,string codusu )
        {
            string sql = string.Empty;
            sql = "SELECT id, numero, tipo, origen, descripcion, otro_origen, fecha, doccruce, serie, seriecruce,codusu  FROM tabla_solicitud_correctivaPreventiva  where  serie =@serie and codusu=@codusu";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@serie", serie);
            sqlCmd.Parameters.AddWithValue("@codusu", codusu);
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }


        public DataTable funObtenersolicitud_correctivaPreventivaEstado(string serie )
        {
            string sql = string.Empty;
            //  sql = "SELECT id, numero, tipo, origen, descripcion, otro_origen, fecha, doccruce, serie, seriecruce,codusu  FROM tabla_solicitud_correctivaPreventiva  where  serie = @serie";

            sql = "SELECT s.id, s.numero, s.tipo, s.origen, s.descripcion, s.otro_origen, s.fecha, s.doccruce, s.serie, s.seriecruce,s.codusu,";
            sql = sql + "convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='002' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as analisis,";
            sql = sql + " convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='003' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as accion,";
            sql = sql + " convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='004' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as plana,";
            sql = sql + " convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='005' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as informe";
            sql = sql + " FROM tabla_solicitud_correctivaPreventiva s  where  s.serie = @serie  and isnull(s.estado,'') <>'A'";

            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@serie", serie);
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }

        public DataTable funObtenersolicitud_correctivaPreventiva(string serie)
        {
            string sql = string.Empty;
          //  sql = "SELECT id, numero, tipo, origen, descripcion, otro_origen, fecha, doccruce, serie, seriecruce,codusu  FROM tabla_solicitud_correctivaPreventiva  where  serie = @serie";

            //sql = "SELECT s.id, s.numero, s.tipo, s.origen, s.descripcion, s.otro_origen, s.fecha, s.doccruce, s.serie, s.seriecruce,s.codusu,(select top 1 ta.detalle from tabla_areas ta  where ta.codarea= s.areadirigida) as areadirigida,";
            //sql=sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='002' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as analisis,";
            //sql =sql+ " convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='003' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as accion,";
            //sql = sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='004' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as plana,";
            //sql = sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='005' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as informe";
            //sql = sql +" FROM tabla_solicitud_correctivaPreventiva s  where  s.serie = @serie";
            sql = "select * from vista_listaSolicitudes where serie = @serie";


            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@serie", serie);
            //sqlCmd.Parameters.AddWithValue("@codusu", codusu);
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }


        public DataTable funObtenerOrdenesTrabajo(int band)
        {
            string sql = string.Empty;

            if (band == 0)
                sql = "select ROW_NUMBER() OVER(Order by numero) as item, * from vista_ordenesTrabajo where codusuautorizado=''";
         
            if (band == 1)
                sql = "select ROW_NUMBER() OVER(Order by numero) as item, * from vista_ordenesTrabajo where codusuautorizado<>'' and finalizado=0";

            if (band == 2)
                sql = "select ROW_NUMBER() OVER(Order by numero) as item, * from vista_ordenesTrabajo where codusuautorizado<>'' and finalizado=1 and aprobadopago=0";

            if (band == 3)
                sql = "select ROW_NUMBER() OVER(Order by numero) as item, * from vista_ordenesTrabajo where codusuautorizado<>'' and finalizado=1 and aprobadopago=1";


            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }

        public DataTable funObtenerOrdenesTrabajoFiltroAreaMantenimiento(Cls_OrdenTrabajo orden )
        {
            string sql = string.Empty;

            sql = "sp_listaOrdenesTrabajoValorizadas";
            
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codorden", orden.codorden );
            sqlCmd.Parameters.AddWithValue("@codarea", orden.codarea);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }



        public Cls_OrdenTrabajo funObtenerOrdenesTrabajo(Cls_OrdenTrabajo orden)
        {
            
            Cls_OrdenTrabajo varRespuesta = null;
            string sql = string.Empty;
            
            sql = "select ROW_NUMBER() OVER(Order by numero) as item,fecha as fechas,* from vista_ordenesTrabajo where numero=@numero and anio=@anio and mes=@mes";
            
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numero", orden.numero);
            sqlCmd.Parameters.AddWithValue("@mes", orden.mes);
            sqlCmd.Parameters.AddWithValue("@anio", orden.anio);
            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_OrdenTrabajo();

                varRespuesta.fechas = rs["fechas"].ToString();
                varRespuesta.numeroot = rs["numeroOT"].ToString();
                varRespuesta.semana =Convert.ToInt32 ( rs["semana"]);
                varRespuesta.numeroAC = rs["numeroAC"].ToString();
                varRespuesta.servicio = rs["servicio"].ToString();
                varRespuesta.contratista = rs["contratista"].ToString();
                varRespuesta.area = rs["area"].ToString();

                varRespuesta.fechaInicio =Convert.ToDateTime( rs["fechaInicio"]);
                varRespuesta.FechaFin = Convert.ToDateTime(rs["FechaFin"]);
                varRespuesta.orden = rs["orden"].ToString();
                varRespuesta.mantenimiento = rs["mantenimiento"].ToString();
                varRespuesta.codususolicitante = rs["codususolicitante"].ToString();

                varRespuesta.sacp = rs["sacp"].ToString();
                varRespuesta.codusuautorizado = rs["codusuautorizado"].ToString();

                varRespuesta.recibo  = rs["recibo"].ToString();
                varRespuesta.fecharecibo  = rs["fecharecibo"].ToString();

            }
            conectar.Close();

            return varRespuesta;



        }


        public Cls_SolicitudCorrectivaPreventiva funSolicitudCorrectivaPreventivaObtenerTodos(string numero,string serie )
        {
            Cls_SolicitudCorrectivaPreventiva varRespuesta = null;
            string sql = string.Empty;
            sql = "SELECT id,numero,tipo,origen,descripcion, otro_origen, fecha, doccruce, serie, seriecruce FROM tabla_solicitud_correctivaPreventiva where numero = @numero and serie = @serie";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numero", numero);
            sqlCmd.Parameters.AddWithValue("@serie", serie) ;



            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_SolicitudCorrectivaPreventiva();
                varRespuesta.numero = rs["numero"].ToString();
                varRespuesta.descripcion = rs["descripcion"].ToString();


            }
            conectar.Close();

            return varRespuesta;
        }


        public Cls_SolicitudCorrectivaPreventiva funSolicitudCorrectivaPreventivaObtenerTodos(string serie, string seriecruce2,string doccruce2)
        {
            Cls_SolicitudCorrectivaPreventiva varRespuesta = null;
            string sql = string.Empty;
            sql = "SELECT id,numero,tipo,origen,descripcion, otro_origen, fecha, doccruce, serie, seriecruce FROM tabla_solicitud_correctivaPreventiva where serie = @serie and seriecruce2=@seriecruce2 and doccruce2=@doccruce2";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
       
            sqlCmd.Parameters.AddWithValue("@serie", serie);
            sqlCmd.Parameters.AddWithValue("@seriecruce2", seriecruce2 );
            sqlCmd.Parameters.AddWithValue("@doccruce2", doccruce2);


            conectar.Open();

            SqlDataReader rs;

            rs = sqlCmd.ExecuteReader();


            if (rs.Read())
            {
                varRespuesta = new Cls_SolicitudCorrectivaPreventiva();
                varRespuesta.numero = rs["numero"].ToString();
                varRespuesta.descripcion = rs["descripcion"].ToString();


            }
            conectar.Close();

            return varRespuesta;
        }

        public Cls_OrdenTrabajo funcion_tabla_ordendetrabajo_numerosiguiente(Cls_OrdenTrabajo orden)
        {
            Cls_OrdenTrabajo varRespuesta = null;


            string sql = string.Empty;
            sql = "select dbo.funcion_tabla_ordendetrabajo_numerosiguiente(@mes,@anio) as numero";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@mes", orden.mes);
            sqlCmd.Parameters.AddWithValue("@anio", orden.anio);

            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                varRespuesta = new Cls_OrdenTrabajo();
                varRespuesta.numero = rs["numero"].ToString();
            }
            conectar.Close();
            return varRespuesta;

        }


        public DataTable funObtenerDetalleOrdenesTrabajo(Cls_DetalleOrdenTrabajo detalle)
        {
            string sql = string.Empty;

            sql = "select ROW_NUMBER() OVER(Order by numero) as item, * from  vista_detalleOrdenesTrabajo  where mes=@mes and anio=@anio and numero=@numero and codpresupuesto=@codpresupuesto";
            
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@mes", detalle.mes);
            sqlCmd.Parameters.AddWithValue("@anio", detalle.anio);
            sqlCmd.Parameters.AddWithValue("@numero", detalle.numero);
            sqlCmd.Parameters.AddWithValue("@codpresupuesto", detalle.codpresupuesto );
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }


        public DataTable funObtenerListaArchivos(Cls_FilesContent files)
        {
            string sql = string.Empty;
            if (files.codarea =="-1")
                sql = "select ROW_NUMBER() OVER(Order by f.codarea ) as item,f.fileid,f.filename,(select a.detalle from tabla_areas a where a.codarea=f.codarea) as area,f.codusu,f.fechamod from   FilesContent f order by area";
            else
                sql = "select ROW_NUMBER() OVER(Order by f.codarea ) as item,f.fileid,f.filename,(select a.detalle from tabla_areas a where a.codarea=f.codarea) as area,f.codusu,f.fechamod from   FilesContent f where f.codarea=@codarea order by area";

            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@codarea",files.codarea);
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }

        public DataTable funObtenerListaSolicitudesxArea(Cls_SolicitudCorrectivaPreventiva sol)
        {
            string sql = string.Empty;
            if (sol.areadirigida == "-1")
                sql = "select * from vista_listaSolicitudes where serie=@serie";
            else
                sql = "select * from vista_listaSolicitudes where serie=@serie and codareadirigida=@codarea";

            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@serie", sol.serie );
            sqlCmd.Parameters.AddWithValue("@codarea", sol.areadirigida );
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();  
            return dt;
        }


        //public DataTable funObtenerLista_productoterminado_congelados()
        //{


           
            
        //    string sql = string.Empty;
        //    //  sql = "SELECT id, numero, tipo, origen, descripcion, otro_origen, fecha, doccruce, serie, seriecruce,codusu  FROM tabla_solicitud_correctivaPreventiva  where  serie = @serie";

        //    //sql = "SELECT s.id, s.numero, s.tipo, s.origen, s.descripcion, s.otro_origen, s.fecha, s.doccruce, s.serie, s.seriecruce,s.codusu,(select top 1 ta.detalle from tabla_areas ta  where ta.codarea= s.areadirigida) as areadirigida,";
        //    //sql=sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='002' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as analisis,";
        //    //sql =sql+ " convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='003' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as accion,";
        //    //sql = sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='004' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as plana,";
        //    //sql = sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='005' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as informe";
        //    //sql = sql +" FROM tabla_solicitud_correctivaPreventiva s  where  s.serie = @serie";
        //    sql = "select * from vista_productoterminado_congelados";


        //    DataTable dt = new DataTable();
         
        //    OleDbCommand sqlCmd = new  OleDbCommand();
        //    sqlCmd.Connection = conectarAc;
        //    sqlCmd.CommandText = sql;
        //   // sqlCmd.Parameters.AddWithValue("@serie", serie);
        //    //sqlCmd.Parameters.AddWithValue("@codusu", codusu);
        //    sqlCmd.CommandType = CommandType.Text;

        //    OleDbDataAdapter da= new OleDbDataAdapter();
        //    da.SelectCommand = sqlCmd;






        //    conectarAc.Open();
        //    da.Fill(dt);
        //    conectarAc.Close();  
        //    return dt;
        //}


        public DataTable funObtenerLista_productoterminado_congelados(string numero)
        {




            string sql = string.Empty;
                       sql = "select * from vista_productoterminado_congelados where id ='"+ numero +"'";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            // sqlCmd.Parameters.AddWithValue("@serie", serie);
            //sqlCmd.Parameters.AddWithValue("@codusu", codusu);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;






            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }



        //public Cls_Usuarios funObtenerUsuariosAccess(string parCodusu, string parClave)
        //{
           
        //    Cls_Usuarios varRespuesta = null;
        //    string sql = string.Empty;
        //    sql = "select * from usuario where usuario = @codusu and idusuario=@clave";
        //    OleDbCommand sqlCmd = new OleDbCommand();
        //    sqlCmd.Connection = conectarAc ;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.Parameters.AddWithValue("@codusu", parCodusu);
        //    sqlCmd.Parameters.AddWithValue("@clave", parClave);
        //    conectarAc.Open();
        //   OleDbDataReader    rs;
        //    rs = sqlCmd.ExecuteReader();
        //    if (rs.Read())
        //    {
        //        varRespuesta = new Cls_Usuarios();
        //        varRespuesta.clave = rs["usuario"].ToString();
        //        varRespuesta.codUsu = rs["idusuario"].ToString();
        //        varRespuesta.estado = rs["estado"].ToString();
              



        //    }
        //    conectarAc.Close();
        //    return varRespuesta;
        //}


        //public Cls_Usuarios funObtenerUsuariosAccessODBC(string parCodusu, string parClave)
        //{
        //    OdbcConnection conectarAc = Cls_ConexionCD.conectarAccsesODBC();
        //    Cls_Usuarios varRespuesta = null;
        //    string sql = string.Empty;
        //    sql = "select * from usuario where usuario ='" + parCodusu+"' and idusuario='"+ parClave +"'";
        //    OdbcCommand sqlCmd = new OdbcCommand();
        //    sqlCmd.Connection = conectarAc;
        //    sqlCmd.CommandText = sql;
        //    //sqlCmd.Parameters.AddWithValue("@codusu", parCodusu);
        //    //sqlCmd.Parameters.AddWithValue("@clave", parClave);
        //    conectarAc.Open();
        //   OdbcDataReader rs;
        //    rs = sqlCmd.ExecuteReader();
        //    if (rs.Read())
        //    {
        //        varRespuesta = new Cls_Usuarios();
        //        varRespuesta.clave = rs["usuario"].ToString();

        //        varRespuesta.codUsu = rs["idusuario"].ToString();




        //    }
        //    conectarAc.Close();
        //    return varRespuesta;
        //}


        public DataTable funObtenerLista_productoterminado_congelados(string f_prod1, string f_prod2,int tipo)
        {
      

            string sql = string.Empty;
            //sql = "select * from vista_productoterminado_congelados  where (f_prod>='"+f_prod1 +"' and f_prod<='" + f_prod2 +"')";

            if (tipo ==1)
                sql = "select * from vista_productoterminado_congelados WHERE (((vista_productoterminado_congelados.fprod) Between #" + f_prod1 + "# And #" + f_prod2 + "#))";

            if (tipo == 2)
                sql = "select * from vista_productoterminado_congelados WHERE (((vista_productoterminado_congelados.fdoc) Between #" + f_prod1 + "# And #" + f_prod2 + "#))";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            //sqlCmd.Parameters.AddWithValue("@f_prod1", f_prod1);
            //sqlCmd.Parameters.AddWithValue("@f_prod2", f_prod2);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }

        public DataTable funObtenerLista_especie_pp()
        {


            

            string sql = string.Empty;
            sql = "select * from especiepp";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            //sqlCmd.Parameters.AddWithValue("@f_prod1", f_prod1);
            //sqlCmd.Parameters.AddWithValue("@f_prod2", f_prod2);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }
        
        public DataTable funObtenerLista_materiaprima_congelados()
        {


         

            string sql = string.Empty;
            //  sql = "SELECT id, numero, tipo, origen, descripcion, otro_origen, fecha, doccruce, serie, seriecruce,codusu  FROM tabla_solicitud_correctivaPreventiva  where  serie = @serie";

            //sql = "SELECT s.id, s.numero, s.tipo, s.origen, s.descripcion, s.otro_origen, s.fecha, s.doccruce, s.serie, s.seriecruce,s.codusu,(select top 1 ta.detalle from tabla_areas ta  where ta.codarea= s.areadirigida) as areadirigida,";
            //sql=sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='002' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as analisis,";
            //sql =sql+ " convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='003' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as accion,";
            //sql = sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='004' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as plana,";
            //sql = sql+" convert (bit,(case when (select count(*) from tabla_solicitud_correctivaPreventiva a where a.serie='005' and  a.seriecruce2=s.serie and a.doccruce2=s.numero )  >0 then 1 else 0 end) )as informe";
            //sql = sql +" FROM tabla_solicitud_correctivaPreventiva s  where  s.serie = @serie";
            sql = "select * from vista_materiaprima_congelados";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            // sqlCmd.Parameters.AddWithValue("@serie", serie);
            //sqlCmd.Parameters.AddWithValue("@codusu", codusu);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;






            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }
        
        public DataTable funObtenerLista_materiaprima_congelados(string f_prod1, string f_prod2, int tipo)
        {




            string sql = string.Empty;
            //sql = "select * from vista_productoterminado_congelados  where (f_prod>='"+f_prod1 +"' and f_prod<='" + f_prod2 +"')";

            if (tipo == 1)
                sql = "select * from vista_materiaprima_congelados WHERE (((fprod) Between #" + f_prod1 + "# And #" + f_prod2 + "#))";

            if (tipo == 2)
                sql = "select * from vista_materiaprima_congelados WHERE (((fdoc) Between #" + f_prod1 + "# And #" + f_prod2 + "#))";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            //sqlCmd.Parameters.AddWithValue("@f_prod1", f_prod1);
            //sqlCmd.Parameters.AddWithValue("@f_prod2", f_prod2);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }

        public DataTable funObtenerLista_materiaprima_congelados(string numero)
        {




            string sql = string.Empty;
            //sql = "select * from vista_productoterminado_congelados  where (f_prod>='"+f_prod1 +"' and f_prod<='" + f_prod2 +"')";

            sql = "select * from detplanilla order by numplanilla desc";

            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            //sqlCmd.Parameters.AddWithValue("@f_prod1", f_prod1);
            //sqlCmd.Parameters.AddWithValue("@f_prod2", f_prod2);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }
        
        public DataTable funObtenerLista_insumos_congelados()
        {




            string sql = string.Empty;
            sql = "select * from vista_insumos_congelados";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
           
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }

        public DataTable funObtenerLista_insumos_congelados(string f_prod1, string f_prod2, int tipo)
        {




            string sql = string.Empty;
            //sql = "select * from vista_productoterminado_congelados  where (f_prod>='"+f_prod1 +"' and f_prod<='" + f_prod2 +"')";

            if (tipo == 1)
                sql = "select * from vista_insumos_congelados WHERE (((vista_insumos_congelados.fprod) Between #" + f_prod1 + "# And #" + f_prod2 + "#))";

            if (tipo == 2)
                sql = "select * from vista_insumos_congelados WHERE (((vista_insumos_congelados.fdoc) Between #" + f_prod1 + "# And #" + f_prod2 + "#))";


            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
            //sqlCmd.Parameters.AddWithValue("@f_prod1", f_prod1);
            //sqlCmd.Parameters.AddWithValue("@f_prod2", f_prod2);
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }
        
        public DataTable funObtenerLista_insumos_congelados(string numero)
        {




            string sql = string.Empty;
         
        
                sql = "select * from vista_insumos_congelados WHERE id='"+ numero+ "'";

           
            DataTable dt = new DataTable();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.Connection = conectarAc;
            sqlCmd.CommandText = sql;
      
            sqlCmd.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = sqlCmd;


            conectarAc.Open();
            da.Fill(dt);
            conectarAc.Close();
            return dt;
        }

       //////////////////////////////////////////////////// SEAFROST
        public DataTable funObtenerSalas()
        {
            
            string sql = string.Empty;
          

            sql = "select * from tabla_sala";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerSalasById(Cls_Planilla det)
        {

            string sql = string.Empty;


            sql = "select codsala,descripcion,sigla from tabla_sala where codsala='" + det.codsala + "' union all select codsala,descripcion,sigla  from tabla_sala where codsala <>'" + det.codsala + "'";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerTurnoById(Cls_Planilla det)
        {

            string sql = string.Empty;


            sql = "select codturno,descripcion from tabla_turno where codturno='" + det.codturno + "' union all select codturno,descripcion from tabla_turno where codturno<>'" + det.codturno + "'";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        
        public DataTable funObtenerAlmacenes()
        {

            string sql = string.Empty;


            sql = "select id,descripcion from almacen_stock";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        
        public string funObtenerNumeroGuia(string sala,string tipo )
        {
            string numguia = string.Empty;
            string sql = string.Empty;

            if (tipo == "003")
                sql = "select isnull( (select 'T' +replicate('0',(7- len(( max(convert(int,right(nguia,7))) + 1)))) + convert(varchar,( max(convert(int,right(nguia,7))) + 1))from control where codtipocontrol='" + tipo + "' and fecha >'01/01/2013'),0)as numguia";
            else
                sql = "select isnull ((select replicate('0',(8- len(( max(convert(int,nguia)) + 1)))) + convert(varchar,( max(convert(int,nguia)) + 1))  from control where  codtipocontrol='" + tipo + "' and codsala='" + sala + "' and fecha >'01/01/2013'), 0) as numguia";




            //DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = sqlCmd;


            //conectar.Open();
            ////da.Fill(dt);
            //conectar.Close();
            //return dt;

            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                numguia = rs["numguia"].ToString();
            }
            conectar.Close();
            return numguia;

        }



        // public List<string>  funObtenerTrabajador(Cls_Personal Personal)
        //{
        //    //List<Cls_Salida> varRespuesta;
        //    List<string> varRespuesta;
        //    //Cls_Personal varFila = null;
        //    string sql = string.Empty;
        //    sql = "select codper,trabajador,condicion from vista_PersonalPlanillas where trabajador like '%" + Personal.nom + "%' AND ESTADO='A'";
        //    //OracleCommand sqlCmd = new OracleCommand();
        //    //sqlCmd.Connection = conectarOracle;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.CommandType = CommandType.Text;
        //    conectarOracle.Open();
        //    OracleDataReader rs;
        //    rs = sqlCmd.ExecuteReader();
        //    varRespuesta = new List<string>();
        //    while (rs.Read())
        //    {
        //        //varFila = new Cls_Personal();
        //        //varFila.codtra = rs["codper"].ToString();
        //        //varFila.nom = rs["trabajador"].ToString();
        //        //varFila.condicion = Convert.ToInt32(rs["condicion"]);

        //        varRespuesta.Add(rs["trabajador"].ToString());

        //        // varRespuesta.Add(varFila);
        //    }
        //    conectarOracle.Close();
        //    return varRespuesta;
        //}


        public List<string> funObtenerProductos(string producto)
        {
            List<string> varRespuesta;
           
            string sql = string.Empty;
            sql = "select  dest from T_Tarea where dest like '%'+'" + producto + "'+'%'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<string>();
            while (rs.Read())
            {

                varRespuesta.Add(rs["dest"].ToString());
               
               
            }
            conectar.Close();
            return varRespuesta;
        }
        
        public Cls_Salida funObtenerProductosCls_Salida(string producto,string codigo, int tipo)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Salida varFila=null;
            string sql = string.Empty;
            
            if (tipo ==1)
                sql = "select idsalida, descripcion from salida where rtrim(ltrim(descripcion)) = '" + producto + "'";
            else
                sql = "select idsalida, descripcion from salida where idsalida = '" + codigo + "'";
            

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
         //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Salida();
                varFila.idsalida = rs["idsalida"].ToString();
                varFila.descripcion = rs["descripcion"].ToString();
               // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }

        public Cls_Tarea funObtenerTareaByDescripcion(Cls_Tarea tarea)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Tarea varFila = null;
            string sql = string.Empty;

            if (tarea.tipo == 1)
                sql = "select codt, dest,activo from t_tarea where rtrim(ltrim(dest)) = '" + tarea.dest + "'";
            else
                sql = "select codt, dest,activo from t_tarea where codt = '" + tarea.codt + "'";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Tarea();
                varFila.codt = rs["codt"].ToString();
                varFila.dest = rs["dest"].ToString();
                varFila.activo = Convert.ToBoolean(  rs["activo"]);
                // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }

        public double funObtenerStockIdxAlmacen(string codigo,string almacen)
        {
            double saldo = 0;
            string sql = string.Empty;
            //SqlParameter cantidad;

            sql = "select dbo.fn_reporte_stock_idxAlmacen ( @codigo,GETDATE(),2,@origen) as cantidad";
                      

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@origen", almacen);

            //cantidad = sqlCmd.Parameters.Add("@cantidad", SqlDbType.Money);
            //cantidad.Direction = ParameterDirection.Output;
          

            conectar.Open();
            //sqlCmd.ExecuteNonQuery();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {
                saldo = Convert.ToDouble(rs["cantidad"]);
            }
            conectar.Close();
           
          
            return saldo;

        }

        public double funObtenerStockId(string codigo)
        {
            double saldo = 0;
            string sql = string.Empty;
            SqlParameter cantidad;

            sql = "pr_reporte_stock_id";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@codigo", codigo);


            cantidad = sqlCmd.Parameters.Add("@cantidad", SqlDbType.Money);
            cantidad.Direction = ParameterDirection.Output;


            conectar.Open();
            sqlCmd.ExecuteNonQuery();
            conectar.Close();
            saldo = Convert.ToDouble(cantidad.Value);
            return saldo;

        }

        public DataTable funObtenerProcesos(string codtipocontrol)
        {

            string sql = string.Empty;


            sql = "select * from tabla_procesos where codproceso in (SELECT  codProceso FROM  tabla_TipoControlProceso where activo =1 and codTipoControl ='" + codtipocontrol + "')";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }
        public DataTable funObtenerArea()
        {

            string sql = string.Empty;


            sql = "select * from tabla_area";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerTurno()
        {

            string sql = string.Empty;


            sql = "select * from tabla_turno";

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenervista_muestraGuia(string nguia ,string codtipocontrol,string codsala )
        {

            string sql = string.Empty;

            if (codtipocontrol == "003")
                sql = "select convert(varchar(20),fechaprod,103) as fechaprod,producto,cantidad,almacen,proceso,coddetalle,destino,lote,idsalida  from vista_muestraGuia_destino where nguia='" + nguia + "' and codsala='" + codsala + "'  and codtipocontrol ='" + codtipocontrol + "'";
            else
                sql = "select convert(varchar(20),fechaprod,103) as fechaprod,producto,cantidad,almacen,proceso,coddetalle,destino,lote,idsalida  from vista_muestraGuia where nguia='" + nguia + "' and codsala='" + codsala + "'  and codtipocontrol ='" + codtipocontrol + "'";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerVistaMovimientosEspecie(string idespecie, int tipo, string fecha1, string fecha2)
        {

            string sql = string.Empty;


            


            if (tipo == 1)
                sql = "select * from vista_movimientos where f_produccion1 >='" + fecha1 + "' and f_produccion1 <='" + fecha2 + "' and  cod_esp='" + idespecie + "'";
            else
                sql = "select * from vista_movimientos where fecha1 >='" + fecha1 + "' and fecha1 <='" + fecha2 + "' and  cod_esp='" + idespecie + "'";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerVistaMovimientosProducto(string idproducto,int tipo, string fecha1,string fecha2)
        {

            string sql = string.Empty;


            if (tipo == 1)
                sql = "select * from vista_movimientos where f_produccion1 >='" + fecha1 + "' and f_produccion1 <='" + fecha2 + "' and  idsalida='" + idproducto + "'";
            else
                sql = "select * from vista_movimientos where fecha1 >='" + fecha1 + "' and fecha1 <='" + fecha2 + "' and  idsalida='" + idproducto + "'";




            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerVistaMovimientos(string fecha1, string fecha2, int tipo, string idproducto)
        {

            string sql = string.Empty;

            //if (idproducto == String.Empty)
            //{
            //    if (tipo == 1)
            //        // sql = "select * ,(select tp.descripcion from tabla_procesos tp where tp.codproceso=vm.codproceso ) as tipo from vista_movimientos vm where vm.f_produccion1 >='" + fecha1 + "' and vm.f_produccion1 <='" + fecha2 + "' order by vm.f_produccion1";
            //        sql = "select * , (select tp.descripcion from tabla_procesos tp where tp.codproceso=vm.codproceso ) as tipo from vista_movimientos vm where vm.f_produccion1 >='" + fecha1 + "' and vm.f_produccion1 <='" + fecha2 + "'  order by vm.idsalida, vm.f_produccion1";
            //    else
            //        sql = "select * ,(select tp.descripcion from tabla_procesos tp where tp.codproceso=vm.codproceso ) as tipo from vista_movimientos vm where vm.fecha1 >='" + fecha1 + "' and vm.fecha1 <='" + fecha2 + "' order by vm.idsalida, vm.fecha1";

            //}
            //else
            //{
            //if (tipo == 1)
            //    // sql = "select * ,(select tp.descripcion from tabla_procesos tp where tp.codproceso=vm.codproceso ) as tipo from vista_movimientos vm where vm.f_produccion1 >='" + fecha1 + "' and vm.f_produccion1 <='" + fecha2 + "' order by vm.f_produccion1";
            sql = "sp_reportemovimeintosStock";// "select * , (select tp.descripcion from tabla_procesos tp where tp.codproceso=vm.codproceso ) as tipo from vista_movimientos vm where vm.f_produccion1 >='" + fecha1 + "' and vm.f_produccion1 <='" + fecha2 + "'  and  vm.idsalida='" + idproducto + "' order by vm.idsalida, vm.f_produccion1";
            //else
            //    sql ="sp_reportemovimeintosStock";// sql = "select * ,(select tp.descripcion from tabla_procesos tp where tp.codproceso=vm.codproceso ) as tipo from vista_movimientos vm where vm.fecha1 >='" + fecha1 + "' and vm.fecha1 <='" + fecha2 + "' and  vm.idsalida='" + idproducto + "' order by vm.idsalida, vm.fecha1";

            //}





            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@idsalida", idproducto);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            sqlCmd.Parameters.AddWithValue("@fecha1", fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", fecha2);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerListaEspecies()
        {

            string sql = string.Empty;


            sql = "select * from especie order by desesp";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable pr_reporte_stock(DateTime fecha, string codigo,string almacen,int tipo,string codespecie )
        {
             string sql = string.Empty;
             sql = "pr_reporte_stock";
             DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@ffin", fecha);
            sqlCmd.Parameters.AddWithValue("@codpro", codigo);
            sqlCmd.Parameters.AddWithValue("@almacen", almacen);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            sqlCmd.Parameters.AddWithValue("@codespecie", codespecie);


            
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
         }

        public DataTable pr_lista_guias( string nguia,string tipo)
        {
            string sql = string.Empty;
            sql = "pr_lista_guias";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@nguia", nguia);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            return dt;
        }

        public DataTable funMuestraDetalleGuia(int codcontrol)
        {
            string sql = string.Empty;
            sql = "select fecha_prod ,descripcion,lote,cantidad,tipo,coddetalle,idsalida,alm_origen,idalmacen,codproceso,descpalm_origen , descpalmacen  from vista_muestra_detalle_guia where codcontrol =" + codcontrol;
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public int funObtenerAcceso(string acceso,string codusu)
        {
            int reg = 0;
            string sql = string.Empty;
            sql = "select count(*) as reg from tabla_accesos where codopcion='" + acceso + "' and codusuario='"+codusu +"'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            

            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            if (rs.Read())
            {

                reg = Convert.ToInt32(rs["reg"]);
                
            }
            conectar.Close();
            return reg;
        }

        public DataTable funObtenerTipoControl()
        {

            string sql = string.Empty;


            sql = "select codtipocontrol,descripcion from tabla_tipocontrol";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerProcesosID(string codproceso)
        {

            string sql = string.Empty;


            sql = "select codproceso,descripcion from tabla_procesos where codproceso = '" + codproceso + "' union all select * from tabla_procesos where codproceso <> '" + codproceso + "'";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerAlmacenesID(string id)
        {

            string sql = string.Empty;


            sql = "select ID,descripcion from almacen_stock where id = '" + id + "' union all select ID,descripcion from almacen_stock where id <> '" + id + "'";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerProductosSalida(string producto)
        {

           

            string sql = string.Empty;


            sql = "select idsalida, descripcion from salida where descripcion like '%" + producto + "%'";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerSalidasID(string id)
        {

            string sql = string.Empty;


            sql = "SELECT        idsalida, descripcion  FROM   salida where idsalida=' " + id + "' ";



            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }


        ////////////////////////////////////////////
        public Cls_Bloqueo funObtenerBloqueo()
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Bloqueo varFila = null;
            string sql = string.Empty;
            sql = "select fechaDoc,fechaProd from tabla_bloqueos where id = '001'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Bloqueo();
                varFila.fechaDoc =Convert.ToDateTime( rs["fechaDoc"]);
                varFila.fechaProd = Convert.ToDateTime( rs["fechaProd"]);
                // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }

        ///////////////////////////////////////////
        public Cls_Control funObtenerControl(Cls_Control  control)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Control varFila = null;
            string sql = string.Empty;
            sql = "select nguia,observaciones from control where codcontrol = " + control.codcontrol ;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Control();
                varFila.nguia = rs["nguia"].ToString();
                varFila.observaciones = rs["observaciones"].ToString();
                // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }



        public DataTable funObtenerEspecieAll()
        {
            string sql = string.Empty;

            sql = "select * from especie order by desesp ";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerProcesosAll()
        {
            string sql = string.Empty;

            sql = "select * from tabla_procesos";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public Cls_Planilla funObtenerPlanillaNumero()
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Planilla varFila = null;
            string sql = string.Empty;
            sql = "select MAX(NumPlanilla) + 1 as numplanilla from T_Planilla";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Planilla();
                varFila.numplanilla = Convert.ToInt32( rs["numplanilla"]);
               
                // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }


        public DataTable funObtenerTipoPersonalAll()
        {
            string sql = string.Empty;

            sql = "select * from tabla_tipoPersonal order by id";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerTipoPersonalById(Cls_DetPlanilla tipo)
        {
            string sql = string.Empty;

            sql = "select * from tabla_tipoPersonal where tipo='"+ tipo.unidad+ "' union all select * from tabla_tipoPersonal where tipo<>'"+ tipo.unidad+ "'" ;
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }


        public DataTable funObtenerProductoAll()
        {
            string sql = string.Empty;

            sql = "select * from T_Producto order by desp";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerPresentacionAll()
        {
            string sql = string.Empty;

            sql = "select * from T_Presentacion order by despr";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerPresentacionByID(int id)
        {
            string sql = string.Empty;
           // sql = "select *  from T_Presentacion where codpr in (select codpr  from T_CodigoGral where codp ='"+id+"') order by despr";
            sql = "select *  from T_Presentacion where id in (select idpres  from T_CodigoGral where idprod ="+id+") order by despr";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
       }

        public DataTable funObtenerTareaByID(int id, int idprod)
        {
            string sql = string.Empty;
            sql = "select * from T_Tarea where codt in (select distinct codt  from T_tarGral where idprest=" + id + " and idprod =" + idprod + ") and activo=1";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable funObtenerTareaAll()
        {
            string sql = string.Empty;

            sql = "select * from T_tarea order by dest";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        //public Cls_Personal funObtenerPersonalId(Cls_Personal Personal)
        //{
        //    //List<Cls_Salida> varRespuesta;
        //    Cls_Personal varFila = null;
        //    string sql = string.Empty;
        //    sql = "select codper,trabajador,condicion from vista_PersonalPlanillas where estado='A' and CODPER ='" + Personal.codtra + "'";
        //    OracleCommand sqlCmd = new OracleCommand();
        //    sqlCmd.Connection = conectarOracle;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.CommandType = CommandType.Text;
        //    conectarOracle.Open();
        //    OracleDataReader rs;
        //    rs = sqlCmd.ExecuteReader();
        //    //   varRespuesta = new List<Cls_Salida>();
        //    if (rs.Read())
        //    {
        //        varFila = new Cls_Personal();
        //        varFila.codtra = rs["codper"].ToString();
        //        varFila.nom = rs["trabajador"].ToString();
        //        varFila.condicion = Convert.ToInt32 (   rs["condicion"]);

        //        // varRespuesta.Add(varFila);
        //    }
        //    conectarOracle.Close();
        //    return varFila;
        //}

        public List<Cls_Salida> funObtenerProductosBYFiltro(Cls_Salida producto)
        {
            List<Cls_Salida> varRespuesta;
            Cls_Salida varFila = null;
            string sql = string.Empty;

            sql = "select codigo,detalle from vista_personalyservices where categoria='03' and activo=1 and detalle like '%" + producto.descripcion + "%'";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;

            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_Salida>();
            while (rs.Read())
            {
                varFila = new Cls_Salida();
                varFila.idsalida = rs["codigo"].ToString();
                varFila.descripcion = rs["detalle"].ToString();
                //varFila.idpresentacion = rs["idpresentacion"].ToString();

                //varFila.peso = Convert.ToDouble(rs["peso"]);
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public Cls_Personal funVerificaBiometrico(Cls_Personal Personal)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Personal varFila = null;
            string sql = string.Empty;
            sql = "select inysoft2013.dbo.funcion_verificaFechaPlanilla('" +  Personal.fecha + "','" + Personal.dni +"') as cuenta";
            //sql = "select codper,trabajador,condicion from vista_PersonalPlanillas where estado='A' and CODPER ='" + Personal.codtra + "'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Personal();
                varFila.cont = Convert.ToInt32(rs["cuenta"]);

                // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }
        public Cls_Personal funObtenerPersonalIdLocal(Cls_Personal Personal)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Personal varFila = null;
            string sql = string.Empty;
         //   sql = "select inysoft2013.dbo.funcion_verificaFechaPlanilla('" + Personal.fecha + "',codper) as cuenta, CodPer,detalle, case when GrupoTrabajo='015' then '2' when  GrupoTrabajo='001' then '3' else  GrupoTrabajo end as GrupoTrabajo  from  inysoft2013.dbo.personal where Activo=1 and Categoria ='03' and codigo='" + Personal.codtra + "'";

            sql = "select 1 as cuenta, CodPer,detalle, case when GrupoTrabajo='015' then '2' when  GrupoTrabajo='001' then '3' else  GrupoTrabajo end as GrupoTrabajo  from  inysoft2013.dbo.personal where Activo=1 and Categoria ='03' and codigo='" + Personal.codtra + "'";
          
            
            //sql = "select codper,trabajador,condicion from vista_PersonalPlanillas where estado='A' and CODPER ='" + Personal.codtra + "'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Personal();
                varFila.dni  = rs["codper"].ToString();
                varFila.nom = rs["detalle"].ToString();
                varFila.condicion = Convert.ToInt32(rs["GrupoTrabajo"]);
                varFila.cont = Convert.ToInt32(rs["cuenta"]);

                // varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varFila;
        }

        //public DataTable funObtenerMovimientosInsumos(Cls_Detalle detalle)
        //{
        //    //List<Cls_Salida> varRespuesta;
        //    //Cls_Personal varFila = null;
        //    string sql = string.Empty;
        //    sql = "pr_reporteAlmacen";
        //    OracleCommand sqlCmd = new OracleCommand();
        //    sqlCmd.Connection = conectarOracle;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.CommandType = CommandType.StoredProcedure;
            


        //    //OracleParameter val = new OracleParameter("var_mesAnterior", OracleType.Int32, 50);
        //    //val.Value = detalle.var_mesAnterior;
        //    //sqlCmd.Parameters.Add(val);

        //    //OracleParameter val1 = new OracleParameter("var_mesActual", OracleType.Int32, 50);
        //    //val1.Value = detalle.var_mesActual;
        //    //sqlCmd.Parameters.Add(val1);

        //    //OracleParameter val2 = new OracleParameter("var_periodoActualInicio", OracleType.Int32, 50);
        //    //val2.Value = detalle.var_periodoActualInicio;
        //    //sqlCmd.Parameters.Add(val2);

        //    //OracleParameter val3 = new OracleParameter("var_periodoActualFin", OracleType.Int32, 50);
        //    //val3.Value = detalle.var_periodoActualFin;
        //    //sqlCmd.Parameters.Add(val3);

        //    sqlCmd.Parameters.Add(new OracleParameter("var_anio", OracleType.Int32)).Value = detalle.anio;
        //    sqlCmd.Parameters.Add(new OracleParameter("var_mesAnterior", OracleType.Int32)).Value = detalle.var_mesAnterior;
        //    sqlCmd.Parameters.Add(new OracleParameter("var_mesActual", OracleType.Int32)).Value = detalle.var_mesActual;
        //    sqlCmd.Parameters.Add(new OracleParameter("var_periodoActualInicio", OracleType.VarChar)).Value = detalle.var_periodoActualInicio;
        //    sqlCmd.Parameters.Add(new OracleParameter("var_periodoActualFin", OracleType.VarChar)).Value = detalle.var_periodoActualFin;
        //    sqlCmd.Parameters.Add(new OracleParameter("var_anioAnterior", OracleType.Int32)).Value = detalle.anioAnterior ;
        //    sqlCmd.Parameters.Add(new OracleParameter("prc", OracleType.Cursor)).Direction = ParameterDirection.Output;




        //    //sqlCmd.Parameters.AddWithValue("var_mesAnterior", detalle.var_mesAnterior);
        //    //sqlCmd.Parameters.AddWithValue("var_mesActual", detalle.var_mesActual );

        //    //sqlCmd.Parameters.AddWithValue("var_periodoActualInicio", detalle.var_periodoActualInicio);
        //    //sqlCmd.Parameters.AddWithValue("var_periodoActualFin", detalle.var_periodoActualFin );


        //    DataTable dt = new DataTable();


        //    OracleDataAdapter da = new OracleDataAdapter();
        //    da.SelectCommand = sqlCmd;

        //    sqlCmd.CommandTimeout = 1000;

        //    conectarOracle.Open();
        //    da.Fill(dt);
        //    conectarOracle.Close();
        //    return dt;



        //    //conectarOracle.Open();
        //    //OracleDataReader rs;
        //    //rs = sqlCmd.ExecuteReader();
        //    ////   varRespuesta = new List<Cls_Salida>();
        //    //if (rs.Read())
        //    //{
        //    //    varFila = new Cls_Personal();
        //    //    varFila.codtra = rs["codper"].ToString();
        //    //    varFila.nom = rs["trabajador"].ToString();
        //    //    varFila.condicion = Convert.ToInt32(rs["condicion"]);

        //    //    // varRespuesta.Add(varFila);
        //    //}
        //    //conectarOracle.Close();
        //    //return varFila;
        //}

        public Cls_Personal funObtenerPersonalId1(Cls_Personal Personal)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Personal varFila = null;
            string sql = string.Empty;
            sql = "select codper,trabajador from vista_PersonalPlanillas where estado='A' and CODPER ='" + Personal.codtra + "'";
            // OracleCommand sqlCmd = new OracleCommand();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            // conectarOracle.Open();
            conectar.Open();
            SqlDataReader rs;
            //  OracleDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Personal();
                varFila.codtra = rs["codper"].ToString();
                varFila.nom = rs["trabajador"].ToString();

                // varRespuesta.Add(varFila);
            }
            // conectarOracle.Close();
            conectar.Close();
            return varFila;
        }

        public Cls_Personal funObtenerPersonalIdServices(Cls_Personal Personal)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Personal varFila = null;
            string sql = string.Empty;
            sql = "select codtra,descripcion  from tabla_services where  codtra='" + Personal.codtra + "'";
            // OracleCommand sqlCmd = new OracleCommand();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            // conectarOracle.Open();
            conectar.Open();
            SqlDataReader rs;
            //  OracleDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Personal();
                varFila.codtra = rs["codtra"].ToString();
                varFila.nom = rs["descripcion"].ToString();

                // varRespuesta.Add(varFila);
            }
            // conectarOracle.Close();
            conectar.Close();
            return varFila;
        }

        public DataTable funObtenerlistaDetallePlanilla(Cls_DetPlanilla det)
        {
            string sql = string.Empty;

            if (det.tipo2 ==1)
                sql = "select coddetpla,codtra,detalletrabajador,producto,presentacion,tarea,kilos,codp,codpr,codt,horas,dni,idprod,idprest from vista_listaDetallePlanilla where numplanilla1=" + det.numplanilla + " and ip='" + det.ip + "' order by coddetpla";
            else
                sql = "select coddetpla,codtra,detalletrabajador,producto,presentacion,tarea,kilos,codp,codpr,codt,horas,dni,idprod,idprest from vista_listaDetallePlanilla where numplanilla=" + det.numplanilla + " order by coddetpla";
            
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerlistaReportePersonal()
        {
            string sql = string.Empty;

            sql = "select * from tabla_reportepersonal";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;

        }

        public DataTable funObtenerGruposTrabajo()
        {
            string sql = string.Empty;
            sql = "select grupotrabajo,detalle from PersonalGruposTrabajos where categoria='03'";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }


        public DataTable funObtenerlistaDetallePlanillaOK(Cls_DetPlanilla det)
        {
            string sql = string.Empty;

            sql = "select coddetpla,codtra,detalletrabajador,producto,presentacion,tarea,kilos,codp,codpr,codt,horas,dni,idprod,idprest from vista_listaDetallePlanilla where numplanilla=" + det.numplanilla;
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public Cls_Planilla funObtenerlistaCabeceraPlanillaOK(Cls_Planilla cab)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_Planilla varFila = null;
            string sql = string.Empty;
            sql = "select numplanilla,fecha,fechaprod,codturno,codsala,kilos from vista_cabeceraPlanillas where numplanilla=" + cab.numplanilla;
            // OracleCommand sqlCmd = new OracleCommand();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            // conectarOracle.Open();
            conectar.Open();
            SqlDataReader rs;
            //  OracleDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_Planilla();
                varFila.numplanilla =Convert.ToInt32( rs["numplanilla"]);
                varFila.fecha1 =Convert.ToDateTime( rs["fecha"]);
                varFila.fecha2 = Convert.ToDateTime(rs["fechaprod"]);
                varFila.codturno = rs["codturno"].ToString();
                varFila.codsala = rs["codsala"].ToString();
                varFila.kilos = Convert.ToDouble( rs["kilos"]);

                // varRespuesta.Add(varFila);
            }
            // conectarOracle.Close();
            conectar.Close();
            return varFila;
        }


        public DataTable funObtenerlistaCabeceraPlanilla(Cls_Planilla det)
        {
            string sql = string.Empty;

            //if (det.tipo2 ==1)
            //sql = "select numplanilla,fecha,fechaprod,responsable,sala,turno,tipo  from vista_listaCabeceraPlanilla where (fecha1 >=@fecha1 and fecha1 <=@fecha2)";
            //else
            if (det.tipo2 == 1)
                sql = "select  NumPlanilla,convert(varchar(20),fecha,103) as fecha,convert(varchar(20),FecProduc,103) as fechaprod,responsable ,tipo,sala ,turno,producto,presentacion,tarea,sum(kilos) as kilos from vista_listaCabDetPlanilla where (FecProduc >=@fecha1 and FecProduc <=@fecha2) group by NumPlanilla,fecha,FecProduc,responsable ,tipo,sala ,turno,producto,presentacion,tarea";
            else
                sql = "select  NumPlanilla,convert(varchar(20),fecha,103) as fecha,convert(varchar(20),FecProduc,103) as fechaprod,responsable ,tipo,sala ,turno,producto,presentacion,tarea,sum(kilos) as kilos from vista_listaCabDetPlanilla where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codp ='" + det.codp + "' and codpr ='" + det.codpr + "' and codt ='" + det.codt + "' group by NumPlanilla,fecha,FecProduc,responsable ,tipo,sala ,turno,producto,presentacion,tarea";
            

            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();

            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);

            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenerCondicion()
        {
            string sql = string.Empty;

            sql = "select id,descripcion  from tabla_condicion order by descripcion";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();

           

            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public List<Cls_Planilla> funObtenerPlanilaForSie(Cls_Planilla det)
        {
           
            List<Cls_Planilla> varRespuesta;
            Cls_Planilla varFila = null;
          
            string sql = string.Empty;
            sql = "select numplanilla,codp,codpr,codt,fecha,hora,responsable,confirmacion,turno,bloque,fechaprod,sala from vista_CabeceraPlanillaBySIE";
            sql = sql + " where (fecha2 >=@fecha1 and fecha2 <=@fecha2)";
          
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_Planilla>();
            while (rs.Read())
            {
                varFila = new Cls_Planilla();
                varFila.numplanilla = Convert.ToInt32(rs["numplanilla"]);
                varFila.codp= rs["codp"].ToString();
                varFila.codpr = rs["codpr"].ToString();
                varFila.codt = rs["codt"].ToString();
                varFila.sfecha = rs["fecha"].ToString();
                varFila.hora = rs["hora"].ToString();
                varFila.responsable= rs["responsable"].ToString();
                varFila.confirmacion = rs["confirmacion"].ToString();
                varFila.turno = rs["turno"].ToString();
                varFila.bloque = Convert.ToBoolean( rs["bloque"]);
                varFila.sFecProduc = rs["fechaProd"].ToString();
                varFila.Sala = rs["sala"].ToString();
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }
        public List<Cls_DetPlanilla> funObtenerDetallePlanilaForSie(Cls_Planilla planilla)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila = null;

            string sql = string.Empty;
            sql = "select coddetpla,codtra,kilos,numplanilla,fecproduc  from vista_detallePlanillaBySIE where (FecProduc >=@fecha1 and FecProduc <=@fecha2 )";
           
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@fecha1", planilla.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", planilla.fecha2);
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();
                varFila.codtra =rs["codtra"].ToString();
                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.numplanilla = Convert.ToInt32(rs["numPlanilla"]);
                varFila.coddetpla = Convert.ToInt32(rs["coddetpla"]);
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }


        public List<Cls_DetPlanilla> funObtenerlistaDetalleByFechaByPresentacion(Cls_Planilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;
           
            string sql = string.Empty;

            if (det.tipo2 == 1)
            {
                sql = "select idprod as codp,idprest as codpr, producto,presentacion,tarea, sum(kilos) as kilos,tarifa,sum(kilos)*tarifa as total from vista_listaCabDetPlanilla";
                sql = sql + " where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and idprod =@codp and idprest=@codpr";
                sql = sql + " group by idprod,idprest, producto,presentacion,tarea,tarifa order by producto,presentacion,tarea";

            }
            else
            {
                sql = "select idprod as codp,idprest as codpr, producto,presentacion,tarea, sum(kilos) as kilos,tarifa,sum(kilos)*tarifa as total from vista_listaCabDetPlanilla";
                sql = sql + " where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and idprod =@codp and idprest=@codpr and codturno =@codturno ";
                sql = sql + " group by idprod,idprest, producto,presentacion,tarea,tarifa order by producto,presentacion,tarea";
            }
            
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
            sqlCmd.Parameters.AddWithValue("@codp", det.idprod );
            sqlCmd.Parameters.AddWithValue("@codpr", det.idprest );

            if (det.tipo2 != 1)
            {

                sqlCmd.Parameters.AddWithValue("@codturno", det.codturno);
            }
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codp = rs["codp"].ToString();
                varFila.codpr = rs["codpr"].ToString();
                //varFila.codt = rs["codt"].ToString();
                varFila.producto = rs["producto"].ToString();
                varFila.presentacion = rs["presentacion"].ToString();
                varFila.tarea = rs["tarea"].ToString();

                varFila.kilos  = Convert.ToDouble( rs["kilos"]);
                varFila.tarifa = Convert.ToDouble(rs["tarifa"]);
                varFila.total = Convert.ToDouble(rs["total"]);

                //varFila.turno = rs["turno"].ToString();
               
               
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public List<Cls_DetPlanilla> funObtenerlistaDetalleByFecha(Cls_Planilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;

            if (det.tipo2 == 1)
            {
                sql = "select codp,codpr,producto,presentacion,sum(kilos) as kilos,sum(total) as total,'' as codturno,idprod,idprest from vista_listaDetalleByProducto where (FecProduc >=@fecha1 and FecProduc <=@fecha2) ";
                sql = sql + " group by codp,codpr,producto,presentacion,idprod,idprest order by producto,presentacion";
            }
            else
            {
                sql = "select codp,codpr,producto,presentacion,sum(kilos) as kilos,sum(total) as total, codturno ,idprod,idprest from vista_listaDetalleByProducto where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codturno ='" + det.codturno + "'";
                sql = sql + " group by codp,codpr,producto,presentacion,codturno,idprod,idprest order by producto,presentacion,codturno";
            }
        

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
           
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codp = rs["codp"].ToString();
                varFila.codpr = rs["codpr"].ToString();
                varFila.producto = rs["producto"].ToString();
                varFila.presentacion = rs["presentacion"].ToString();

                varFila.codturno = rs["codturno"].ToString();

                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.total = Convert.ToDouble(rs["total"]);

                varFila.idprest = Convert.ToInt32  (rs["idprest"]);
                varFila.idprod = Convert.ToInt32(rs["idprod"]);

                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public List<Cls_DetPlanilla> funObtenerlistaDetalleByFechaByCodturno(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;


          
                sql = "select codp,codpr,producto,presentacion,sum(kilos) as kilos,sum(total) as total from vista_listaDetalleByProducto where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codturno='" + det.codturno + "'";
                sql = sql + " group by codp,codpr,producto,presentacion order by producto,presentacion";
          
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);

            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codp = rs["codp"].ToString();
                varFila.codpr = rs["codpr"].ToString();
                varFila.producto = rs["producto"].ToString();
                varFila.presentacion = rs["presentacion"].ToString();

                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.total = Convert.ToDouble(rs["total"]);



                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }


        public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByTurno(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;
            sql = "select codtra,detalletrabajador,sum(kilos) as kilos,sum(total) as total from vista_listaDetalleByTrabajador";
            sql = sql + " where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codturno='"+ det.codturno +"' group by codtra,detalletrabajador order by detalletrabajador";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);

            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["detalletrabajador"].ToString();
                //varFila.producto = rs["producto"].ToString();
                //varFila.codp = rs["codp"].ToString();
                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.total = Convert.ToDouble(rs["total"]);


                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }


        public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajador(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;
            sql = "select codtra,detalletrabajador,sum(kilos) as kilos,sum(total) as total from vista_listaDetalleByTrabajador";
            sql = sql + " where (FecProduc >=@fecha1 and FecProduc <=@fecha2) group by codtra,detalletrabajador order by codtra";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);

            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["detalletrabajador"].ToString();
                //varFila.producto = rs["producto"].ToString();
                //varFila.codp = rs["codp"].ToString();
                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.total = Convert.ToDouble(rs["total"]);


                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }


        public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFechaLike(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;
            sql = "select codtra,detalleTrabajador,convert(varchar(30),FecProduc,103) as fechaprod,numplanilla,producto,presentacion ,tarea,SUM(kilos) as kilos,tarifa,tarifa*SUM(kilos)as total,turno";
            sql = sql + " from vista_listaCabDetPlanilla  where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codtra like '%"+det.codtra+"%'";
            sql = sql + " group by codtra,detalleTrabajador,FecProduc,numplanilla,producto,presentacion,tarea,tarifa,turno order by FecProduc,producto,presentacion,tarea,tarifa,turno";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
            //sqlCmd.Parameters.AddWithValue("@codtra", det.codtra);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["detalleTrabajador"].ToString();
                varFila.FecProduc = rs["fechaprod"].ToString();
                varFila.numplanilla = Convert.ToInt32(rs["numplanilla"]);

                varFila.producto = rs["producto"].ToString();
                varFila.presentacion = rs["presentacion"].ToString();
                varFila.tarea = rs["tarea"].ToString();

                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.tarifa = Convert.ToDouble(rs["tarifa"]);
                varFila.total = Convert.ToDouble(rs["total"]);
                varFila.turno = rs["turno"].ToString();
                
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        //public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFechaByTurno(Cls_DetPlanilla det)
        //{
        //    List<Cls_DetPlanilla> varRespuesta;
        //    Cls_DetPlanilla varFila;

        //    string sql = string.Empty;

        //    if (det.tipo == 1)
        //    {
        //        sql = "select codtra,detalleTrabajador,convert(varchar(30),FecProduc,103) as fechaprod,numplanilla,producto,presentacion ,tarea,SUM(kilos) as kilos,tarifa,tarifa*SUM(kilos) as total,turno";
        //        sql = sql + " from vista_listaCabDetPlanilla  where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codturno ='" + det.codturno + "'";
        //        sql = sql + " group by codtra,detalleTrabajador,FecProduc,numplanilla,producto,presentacion,tarea,tarifa,turno order by FecProduc,producto,presentacion,tarea,tarifa,turno";
        //    }
        //    else
        //    {
        //        sql = "select codtra,detalleTrabajador,convert(varchar(30),FecProduc,103) as fechaprod,numplanilla,producto,presentacion ,tarea,SUM(kilos) as kilos,tarifa,tarifa*SUM(kilos)as total,turno";
        //        sql = sql + " from vista_listaCabDetPlanilla  where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codturno in ('001','002')";
        //        sql = sql + " group by codtra,detalleTrabajador,FecProduc,numplanilla,producto,presentacion,tarea,tarifa,turno order by FecProduc,producto,presentacion,tarea,tarifa,turno";
        //    }

        //    SqlCommand sqlCmd = new SqlCommand();
        //    sqlCmd.Connection = conectar;
        //    sqlCmd.CommandText = sql;
        //    sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
        //    sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
        //    //sqlCmd.Parameters.AddWithValue("@codtra", det.codtra);
        //    sqlCmd.CommandType = CommandType.Text;
        //    conectar.Open();
        //    SqlDataReader rs;
        //    rs = sqlCmd.ExecuteReader();
        //    varRespuesta = new List<Cls_DetPlanilla>();
        //    while (rs.Read())
        //    {
        //        varFila = new Cls_DetPlanilla();

        //        varFila.codtra = rs["codtra"].ToString();
        //        varFila.trabajador = rs["detalleTrabajador"].ToString();
        //        varFila.FecProduc = rs["fechaprod"].ToString();
        //        varFila.numplanilla = Convert.ToInt32(rs["numplanilla"]);

        //        varFila.producto = rs["producto"].ToString();
        //        varFila.presentacion = rs["presentacion"].ToString();
        //        varFila.tarea = rs["tarea"].ToString();

        //        varFila.kilos = Convert.ToDouble(rs["kilos"]);
        //        varFila.tarifa = Convert.ToDouble(rs["tarifa"]);
        //        varFila.total = Convert.ToDouble(rs["total"]);
        //        varFila.turno = rs["turno"].ToString();


        //        varRespuesta.Add(varFila);
        //    }
        //    conectar.Close();
        //    return varRespuesta;
        //}

        public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFechaByTurno(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;
            sql = "select codtra,detalleTrabajador,convert(varchar(30),FecProduc,103) as fechaprod,numplanilla,producto,presentacion ,tarea,SUM(kilos) as kilos,tarifa,tarifa*SUM(kilos)as total,turno";
            sql = sql + " from vista_listaCabDetPlanilla  where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codtra =@codtra and codturno='"+ det.codturno  +"'";
            sql = sql + " group by codtra,detalleTrabajador,FecProduc,numplanilla,producto,presentacion,tarea,tarifa,turno order by FecProduc,producto,presentacion,tarea,tarifa,turno";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
            sqlCmd.Parameters.AddWithValue("@codtra", det.codtra);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["detalleTrabajador"].ToString();
                varFila.FecProduc = rs["fechaprod"].ToString();
                varFila.numplanilla = Convert.ToInt32(rs["numplanilla"]);

                varFila.producto = rs["producto"].ToString();
                varFila.presentacion = rs["presentacion"].ToString();
                varFila.tarea = rs["tarea"].ToString();

                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.tarifa = Convert.ToDouble(rs["tarifa"]);
                varFila.total = Convert.ToDouble(rs["total"]);
                varFila.turno = rs["turno"].ToString();
                
                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFecha(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;
            sql = "select codtra,detalleTrabajador,convert(varchar(30),FecProduc,103) as fechaprod,numplanilla,producto,presentacion ,tarea,SUM(kilos) as kilos,tarifa,tarifa*SUM(kilos)as total,turno";
            sql = sql + " from vista_listaCabDetPlanilla  where (FecProduc >=@fecha1 and FecProduc <=@fecha2) and codtra =@codtra";
            sql = sql + " group by codtra,detalleTrabajador,FecProduc,numplanilla,producto,presentacion,tarea,tarifa,turno order by FecProduc,producto,presentacion,tarea,tarifa,turno";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
            sqlCmd.Parameters.AddWithValue("@codtra", det.codtra);
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["detalleTrabajador"].ToString();
                varFila.FecProduc =   rs["fechaprod"].ToString();
                varFila.numplanilla = Convert.ToInt32( rs["numplanilla"]);

                varFila.producto = rs["producto"].ToString();
                varFila.presentacion = rs["presentacion"].ToString();
                varFila.tarea = rs["tarea"].ToString();

                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.tarifa = Convert.ToDouble(rs["tarifa"]);
                varFila.total = Convert.ToDouble(rs["total"]);
                varFila.turno = rs["turno"].ToString();

                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }


        public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByCondicion(Cls_DetPlanilla det)
        {
            List<Cls_DetPlanilla> varRespuesta;
            Cls_DetPlanilla varFila;

            string sql = string.Empty;

            if (det.condicion != 4)
            {
                sql = "select codtra,detalleTrabajador,sum(kilos*tarifa) as total,dni  from vista_listaCabDetPlanilla";
                sql = sql + " where condicion=@condicion and (FecProduc  >=@fecha1 and FecProduc <=@fecha2) group by codtra,detalleTrabajador,dni order by detalleTrabajador";
            }
            else
            {
                sql = "select codtra,detalleTrabajador,sum(kilos*tarifa) as total,dni  from vista_listaCabDetPlanilla";
                sql = sql + " where condicion in (2,3) and (FecProduc  >=@fecha1 and FecProduc <=@fecha2) group by codtra,detalleTrabajador,dni order by detalleTrabajador";

            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@fecha1", det.fecha1);
            sqlCmd.Parameters.AddWithValue("@fecha2", det.fecha2);
            if (det.condicion != 4)
            {
                sqlCmd.Parameters.AddWithValue("@condicion", det.condicion);
            }
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_DetPlanilla>();
            while (rs.Read())
            {
                varFila = new Cls_DetPlanilla();

                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["detalleTrabajador"].ToString();
             
                varFila.total = Convert.ToDouble(rs["total"]);


                varRespuesta.Add(varFila);
            }
            conectar.Close();
            return varRespuesta;
        }

        public Cls_DetPlanilla funObtenerDetallePlanillaByID(Cls_DetPlanilla det)
        {
            //List<Cls_Salida> varRespuesta;
            Cls_DetPlanilla varFila = null;
            string sql = string.Empty;
            sql = "select codtra,detalleTrabajador as trabajador,kilos,horas from DetPlanilla where coddetpla=" + det.coddetpla;
            // OracleCommand sqlCmd = new OracleCommand();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            // conectarOracle.Open();
            conectar.Open();
            SqlDataReader rs;
            //  OracleDataReader rs;
            rs = sqlCmd.ExecuteReader();
            //   varRespuesta = new List<Cls_Salida>();
            if (rs.Read())
            {
                varFila = new Cls_DetPlanilla();
                varFila.codtra = rs["codtra"].ToString();
                varFila.trabajador = rs["trabajador"].ToString();
                varFila.kilos = Convert.ToDouble(rs["kilos"]);
                varFila.horas  = Convert.ToDouble(rs["horas"]);

                // varRespuesta.Add(varFila);
            }
            // conectarOracle.Close();
            conectar.Close();
            return varFila;
        }

        public DataTable funObtenerlistaUnidad()
        {
            string sql = string.Empty;

            sql = "select id,sigla  from tabla_unidad";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenervista_listaSemanasPorPeriodo(string semana)
        {
            string sql = string.Empty;

            sql = "select distinct  * from vista_listaSemanasPorPeriodo  where Periodo='"+semana+"' order by semana";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenervista_listaSemanasPorPeriodoById(string semana, string periodo)
        {
            string sql = string.Empty;

            if (semana == "-1")
                sql = "select distinct  * from vista_listaSemanasPorPeriodoById  where  periodo ='" + periodo + "' order by tipo,id";
            else
                sql = "select distinct  * from vista_listaSemanasPorPeriodoById  where semana='" + semana + "' and periodo ='" + periodo + "' order by tipo,id";

            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;


        }

        public DataTable funObtenervista_listaPlanillasSemana(Cls_Planilla pla)
        { 
            string sql = string.Empty;

            sql = "pr_reporte_condicionConsolidadoPorPlanilla";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@periodo", pla.periodo );
            sqlCmd.Parameters.AddWithValue("@semanag", pla.semanag);
            sqlCmd.Parameters.AddWithValue("@tipopla", pla.tipopla);
            sqlCmd.Parameters.AddWithValue("@idpla", pla.idpla);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;


            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
            
        }

        public void pr_copiaresumen(string periodoant, string periodoactual, string fdoc)
        {
            //string dt = string.Empty;
            string sql = string.Empty;
            sql = "PR_InsertarResumen";
            //DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandTimeout = 10000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@periodoant", periodoant);
            sqlCmd.Parameters.AddWithValue("@periodoactual", periodoactual);
            sqlCmd.Parameters.AddWithValue("@fdoc", fdoc);
            conectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();

            while (rs.Read())
            {
                //dt = rs["CANTSTOCK"].ToString();
            }
            conectar.Close();
        }


        public List<Cls_articulos> funObtenerArticulos(string producto,string COalm,string MIstoc)
        {
            List<Cls_articulos> varRespuesta;
            Cls_articulos varllena;
            string sql = string.Empty;
            sql = "select  AR_CDESCRI,AR_CCODIGO,AR_CUNIDAD,AR_NIGVCPR,AR_CTIPDES,AR_NPRECOM,AR_CCONTRO,AR_CMONCOM from AL0003ARTI where AR_CLINEA!='R' and AR_CCODIGO in (select SK_CCODIGO from AL0003STOC where SK_NSKDIS>= '" + MIstoc +"' and SK_CALMA like '%'+'"+ COalm +"'+'%') and AR_CDESCRI like '%'+'" + producto + "'+'%'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<Cls_articulos>();
            while (rs.Read())
            {
                varllena = new Cls_articulos();
                varllena.AR_CDESCRI =rs["AR_CDESCRI"].ToString();
                varllena.AR_CCODIGO = (rs["AR_CCODIGO"].ToString());
                varllena.AR_CUNIDAD = (rs["AR_CUNIDAD"].ToString());
                varllena.AR_NIGVCPR = Convert.ToDecimal(rs["AR_NIGVCPR"]);
                varllena.AR_CTIPDES = (rs["AR_CTIPDES"].ToString());
                varllena.AR_NPRECOM = Convert.ToDecimal(rs["AR_NPRECOM"]);
                varllena.AR_CCONTRO = (rs["AR_CCONTRO"].ToString());
                varllena.AR_CMONCOM = (rs["AR_CMONCOM"].ToString());
                varRespuesta.Add(varllena);
            }
            conectar.Close();
            return varRespuesta;
        }


        public List<PRAL0003MOVG> PR_ConsumoCcosto(string foragrupa, string almacen, string fin, string ffn, string codigo, string codigo2)
        {
            List<PRAL0003MOVG> varRespuesta;
            PRAL0003MOVG varllena;
            string sql = string.Empty;
            sql = "exec PR_CONSUMO_CC @foragrupa='" + foragrupa + "',@almacen='" + almacen + "',@fin='" + fin + "',@ffn='" + ffn + "',@codigo='" + codigo + "',@codigo2='" + codigo2 + "' ";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.Text;
            conectar.Open();
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();
            varRespuesta = new List<PRAL0003MOVG>();
            while (rs.Read())
            {
                varllena = new PRAL0003MOVG();
                varllena.C6_CCODIGO = rs["C6_CCODIGO"].ToString();
                varllena.C6_CCENCOS = (rs["C6_CCENCOS"].ToString());
                varRespuesta.Add(varllena);
            }
            conectar.Close();
            return varRespuesta;
        }


        public void pr_limpiarstockval(string periodoactual)
        {
            //string dt = string.Empty;
            string sql = string.Empty;
            sql = "PR_LIMPIASTOCKV";
            //DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandTimeout = 10000;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@periodoactual", periodoactual);
            conectar.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            SqlDataReader rs;
            rs = sqlCmd.ExecuteReader();

            while (rs.Read())
            {
                //dt = rs["CANTSTOCK"].ToString();
            }
            conectar.Close();
        }

        public DataTable PrEntradasSalidas(string foragrupa, string almacen, string fin, string ffn, string codigo, string codigo2,string codmov,string tm)
        {
            string sql = string.Empty;
            sql = "PR_ESCOSTO_CC";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@foragrupa", foragrupa);
            sqlCmd.Parameters.AddWithValue("@almacen", almacen);
            sqlCmd.Parameters.AddWithValue("@fin", fin);
            sqlCmd.Parameters.AddWithValue("@ffn", ffn);
            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@codigo2", codigo2);
            sqlCmd.Parameters.AddWithValue("@codmov", codmov);
            sqlCmd.Parameters.AddWithValue("@tm", tm); 
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable PrStockVal(string almacen, string fin, string codigo, string codigo2)
        {
            string sql = string.Empty;
            sql = "PR_STOCK_CC";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@almacen", almacen);
            sqlCmd.Parameters.AddWithValue("@fin", fin);
            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@codigo2", codigo2);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable PrConsumoVal(string foragrupa,string almacen, string fin, string ffn, string codigo, string codigo2,string localIP,string almacen2)
        {
            string sql = string.Empty;
            sql = "PR_CONSUMO_CC";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar; 
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@foragrupa", foragrupa);
            sqlCmd.Parameters.AddWithValue("@almacen", almacen);
            sqlCmd.Parameters.AddWithValue("@fin",fin );
            sqlCmd.Parameters.AddWithValue("@ffn", ffn);
            sqlCmd.Parameters.AddWithValue("@codigo",codigo);
            sqlCmd.Parameters.AddWithValue("@codigo2", codigo2);
            sqlCmd.Parameters.AddWithValue("@localIP", localIP); 
            sqlCmd.Parameters.AddWithValue("@almacenref", almacen2);
            sqlCmd.CommandTimeout = 10000;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        public DataTable PrKardexVal(string fin, string ffn,string codigo,string codigo2, string moneda)
        {
            string sql = string.Empty;
            sql = "PR_KARDEX_PERIODO";
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql; 
            sqlCmd.CommandType = CommandType.StoredProcedure; 
            sqlCmd.Parameters.AddWithValue("@fin", fin); 
            sqlCmd.Parameters.AddWithValue("@ffn", ffn); 
            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@codigo2", codigo2);
            sqlCmd.Parameters.AddWithValue("@moneda", moneda);
            sqlCmd.CommandTimeout = 10000;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            conectar.Open();
            da.Fill(dt);
            conectar.Close();
            return dt;
        }

        //public DataTable PR_ConsumoCcosto(string foragrupa, string almacen, string fin, string ffn, string codigo, string codigo2)
        //{
        //    string sql = string.Empty;
        //    sql = "PR_CONSUMO_CC";
        //    DataTable dt = new DataTable();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    sqlCmd.Connection = conectar;
        //    sqlCmd.CommandText = sql;

        //    sqlCmd.CommandType = CommandType.StoredProcedure;

        //    sqlCmd.Parameters.AddWithValue("@foragrupa", foragrupa);
        //    sqlCmd.Parameters.AddWithValue("@almacen", almacen);
        //    sqlCmd.Parameters.AddWithValue("@fin", fin);
        //    sqlCmd.Parameters.AddWithValue("@ffn", ffn);
        //    sqlCmd.Parameters.AddWithValue("@codigo", codigo);
        //    sqlCmd.Parameters.AddWithValue("@codigo2", codigo2);

        //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        //    conectar.Open();
        //    da.Fill(dt);
        //    conectar.Close();
        //    return dt;
        //}


    }
}
