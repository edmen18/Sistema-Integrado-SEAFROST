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

namespace CapaDatos
{
    public class Cls_Reportes
    {
        private SqlConnection conectar;
        private OleDbConnection conectarAc;
        private string caden;

        public Cls_Reportes(string cadena)
        {
            caden = cadena;
            this.conectar = Cls_ConexionCD.conectar(cadena);
            this.conectarAc = Cls_ConexionCD.conectarAccses(cadena);
        }


        public pproduccion funObtenerDatosPP(string id)
        {
            pproduccion dtDatos = new pproduccion();


            using (OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings[caden].ToString()))
            {

                #region Cargo Datos Materi prima

                string sql = @"select * from vista_materiaprima_congelados where id='"+id+"'";

                OleDbCommand command = new OleDbCommand(sql, conn);

                OleDbDataAdapter da = new OleDbDataAdapter(command);

                da.Fill(dtDatos, "MateriaPrima");

                #endregion

                #region Cargo Produccion

                sql = @"select * from vista_productoterminado_congelados where id='" + id+"'";


                command = new OleDbCommand(sql, conn);

                da = new OleDbDataAdapter(command);

                da.Fill(dtDatos, "Produccion");

                #endregion

                #region Cargo Insumos

                sql = @"select * from vista_insumos_congelados where id='" + id + "'";


                command = new OleDbCommand(sql, conn);

                da = new OleDbDataAdapter(command);

                da.Fill(dtDatos, "Insumos");

                #endregion

                #region Cargo Personal

                sql = @"select * from vista_personal_congelados where id='" + id + "'";


                command = new OleDbCommand(sql, conn);

                da = new OleDbDataAdapter(command);

                da.Fill(dtDatos, "Personal");

                #endregion


                #region Cargo Consolidado

                sql = @"select * from vista_consolidado_congelados where id='" + id + "'";


                command = new OleDbCommand(sql, conn);

                da = new OleDbDataAdapter(command);

                da.Fill(dtDatos, "Consolidado");

                #endregion

            }

            return dtDatos;
        }
    }
}
