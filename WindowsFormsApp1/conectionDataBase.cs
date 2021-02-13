using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class conectionDataBase
    {
        private string connectionString = "";
        
        public System.Data.DataTable UserDataConnections(string name, int legajo, int tipo, int nroSucursal)
        {            
            SqlConnection connection;
            SqlCommand command;
            string sql = "";
            SqlDataReader dataReader;
            System.Data.DataTable dt = new System.Data.DataTable();

            sql = StringQuery(name, legajo, tipo, nroSucursal);

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                /*while (dataReader.Read())
                {*/
                    dt.Load(dataReader);   
                //}
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }


            return dt;
        }

        private String StringQuery(string name, int legajo, int tipo, int nroSucursal)
        {
            string sql;
            bool flags1;
            flags1 = false;

            sql = "SELECT usu.Tipo AS 'TIPO', usu.Nombre AS 'NOMBRE', usu.Legajo AS 'LEGAJO', usu.Clave AS 'CLAVE', suc.Descripcion AS 'SUCURSAL' " +
                  "FROM UsuariosPos usu INNER JOIN Sucursales suc " +
                  "ON usu.Sucursal = suc.Id " +
                  "WHERE ";

            if (!name.Equals(""))
            {
                sql += "usu.Nombre LIKE '%" + name + "%' ";
                flags1 = true;
            }
                

            if (legajo != -1)
            {
                if (flags1)
                {
                    sql += "AND ";
                    flags1 = false;
                }

                sql += "usu.Legajo = " + legajo + " ";
                flags1 = true;
            }

            if (nroSucursal != -1)
            {
                if (flags1)
                {
                    sql += "AND ";
                    flags1 = false;
                }

                sql += "usu.Sucursal = " + nroSucursal + " ";
                flags1 = true;
            }
                

            if (tipo != -1)
            {
                if (flags1)
                {
                    sql += "AND ";
                    flags1 = false;
                }

                sql += " usu.Tipo = " + (tipo + 1);
                flags1 = true;
            }
                

            return sql;
        }

        public System.Data.DataTable ReportsCashierDataConnections(int nroPV, int nroComprob)
        {            
            SqlConnection connection;
            SqlCommand command;
            string sql = "";
            SqlDataReader dataReader;
            System.Data.DataTable dt = new System.Data.DataTable();

            sql = "SELECT dtr.[bStatus] AS ESTADO, " +
                  "dtr.[iNroSuc] AS 'NÚMERO DE SUCURSAL' " +
                  ",dtr.[iNroPV] AS 'NÚMERO DE PV' ,dtr.[iNroPos] AS 'NÚMERO DE POS' " +
                  ",dtr.[iNroZ] AS 'NÚMERO DE Z' " +
                  ",dtr.[iNroY] AS 'NÚMERO DE Y' " +
                  ",dtr.[iNroUser] AS 'LEGAJO CAJERO' " +
                  ",dtr.[iNroTicket] AS 'TICKET TIPRE' " +
                  ",REPLACE(CONVERT(VARCHAR, dtr.fPrecioTotal), '.', ',')  AS 'PRECIO TOTAL' " +
                  ",dtr.[iNroComprob] AS 'TICKET COMPROBANTE DE VENTA' " +
                  ",dtr.[fTimeSynchro] AS 'FECHA Y HORA' " +
                  "FROM[dbo].[dE_TResu] dtr " +
                  "WHERE dtr.iNroPV =  " + nroPV + " AND dtr.iNroComprob = " + nroComprob;
  

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                /*while (dataReader.Read())
                {*/
                dt.Load(dataReader);
                //}
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }


            return dt;
        }




        /*
          
            Ver como hacer funcionar esto
         
          
            private void SqlAndString(out bool flag,out string sql)
            {
                if (flags1)
                {
                    sql += "AND ";
                    flags1 = false;
                }
            }

        */
    }
}
