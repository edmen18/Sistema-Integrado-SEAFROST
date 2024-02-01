using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.Odbc;
using System.Data.OracleClient;
//using Oracle.DataAccess.Client;

namespace CapaDatos
{
    class Cls_ConexionCD
    {
        public static SqlConnection conectar(String cadena) 
          {
             SqlConnection con ;


             try
             {
                 con = new SqlConnection(ConfigurationManager.ConnectionStrings[cadena].ConnectionString);
            
             }
             catch (Exception)
             {
                 con = null;
             }



             
             return con;
          }

        public static OleDbConnection conectarAccses(string cadena)
        {
            OleDbConnection con;

          

            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Z:\conservas.mdb");

            //con = new OleDbConnection(ConfigurationManager.ConnectionStrings[cadena].ConnectionString);

          

            
             

            return con;
        }

        public static OdbcConnection conectarAccsesODBC()
        {
            OdbcConnection con;

          
            con = new OdbcConnection("DSN=Proyect_Luser");






            return con;
        }

        public static OracleConnection conectarOracle(String cadena)
        {
            OracleConnection con;


            try
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings[cadena].ConnectionString);

            }
            catch (Exception)
            {
                con = null;
            }




            return con;
        }
    }
}
