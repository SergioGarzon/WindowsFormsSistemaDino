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
                sql += SqlAndString(flags1);

                sql += "usu.Legajo = " + legajo + " ";
                flags1 = true;
            }

            if (nroSucursal != -1)
            {
                sql += SqlAndString(flags1);

                sql += "usu.Sucursal = " + nroSucursal + " ";
                flags1 = true;
            }
                

            if (tipo != -1)
            {
                sql += SqlAndString(flags1);

                sql += " usu.Tipo = " + (tipo + 1);
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
                  "WHERE dtr.iNroPV =  " + nroPV;
            
            
            if(nroComprob != -1)
            {
                sql += " AND dtr.iNroComprob = " + nroComprob + " " +                    
                  "ORDER BY dtr.[fTimeSynchro] DESC";
            }
            

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

        public List<string> getDataBaseCliente(int dni)
        {
            List<string> lista = new List<string>();

            SqlConnection connection;
            SqlCommand command;
            string sql = "";
            SqlDataReader dataReader;
            System.Data.DataTable dt = new System.Data.DataTable();

            sql = "SELECT " +
                  "uId AS 'FORMA DE PAGO' " +
	              ",[iNroY] AS 'NÚMERO DE Y' " + 
                  ",[iNroZ] AS 'NÚMERO DE Z' " + 
                  ",[iNroPos] AS 'NÚMERO DE POS' " +
                  ",[iNroSuc] AS 'NÚMERO DE SUCURSAL' " + 
                  ",[iNroUser] AS 'LEGAJO CAJERO' " +
                  ",[cDescripcion] AS 'DESCRIPCIÓN FORMA DE PAGO' " + 
                  ",REPLACE(CONVERT(VARCHAR,[dImporte]), '.', ',') AS 'IMPORTE' " + 
                  ",[dRecDesc] AS 'RECARGO/DESCUENTO' " +  
                  ",[cComprobante] AS 'COMPROBANTE' " +
                  ",[cCliente] AS 'TARJETA CLIENTE' " +
                  ",[cBarCode] AS 'PLAN TARJETA' " + 
                  ",[cPlan] AS 'CPLAN' " + 
                  ",[fTimeSynchro] AS 'FECHA Y HORA' " +
                  ",[vData] AS 'DATOS DEL CLIENTE (TIPO TELEFONO, NRO DE TELEFONO, DNI)' " +
                  "FROM dE_DDMP " +
                  "WHERE vData LIKE '%" + dni + "%'";

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

            lista.Add(dt.ToString());            

            return lista;
        }

        public System.Data.DataTable ReportCashierCreditDataConnections(int iNroPV)
        {
            SqlConnection connection;
            SqlCommand command;
            string sql = "";
            SqlDataReader dataReader;
            System.Data.DataTable dt = new System.Data.DataTable();

            sql = "SELECT ddmp.uId AS 'FORMA DE PAGO' " +
                  ", ddmp.[lTicket] AS 'TICKET TIPRE' " +
                  ",ddmp.[iNroY] AS 'NÚMERO DE Y' " +
                  ",ddmp.[iNroZ] AS 'NÚMERO DE Z' " +
                  ",ddmp.[iNroPos] AS 'NÚMERO DE POS' " +
                  ",ddmp.[iNroSuc] AS 'NÚMERO DE SUCURSAL' " +
                  ",ddmp.[iNroUser] AS 'LEGAJO CAJERO' " +
                  ",ddmp.[cDescripcion] AS 'DESCRIPCIÓN FORMA DE PAGO' " +
                  ",REPLACE(CONVERT(VARCHAR,ddmp.[dImporte]), '.', ',') AS 'IMPORTE' " +
                  ",ddmp.[dRecDesc] AS 'RECARGO/DESCUENTO' " +
                  ",ddmp.[cComprobante] AS 'COMPROBANTE' " +
                  ",ddmp.[cCliente] AS 'TARJETA CLIENTE' " +
                  ",ddmp.[cBarCode] AS 'PLAN TARJETA' " +
                  ",ddmp.[cPlan] AS 'CPLAN' " +
                  ",ddmp.[fTimeSynchro] AS 'FECHA Y HORA' " +
                  ",ddmp.[vData] AS 'DATOS DEL CLIENTE (TIPO TELEFONO, NRO DE TELEFONO, DNI)' " +
                  "FROM [dbo].[dE_DDMP] ddmp " +
                  "WHERE ddmp.[iNroPos] IN (SELECT dtr.iNroPos FROM dE_TResu dtr WHERE dtr.iNroPV = " + iNroPV + ")";


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

        private string SqlAndString(bool flag)
        {
            string sql = "";

            if (flag)
            {
                sql += "AND ";
                flag = false;
            }

            return sql;
        }
    }
}
