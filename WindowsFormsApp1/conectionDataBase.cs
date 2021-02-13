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
        public System.Data.DataTable UserDataConnections(string name, int legajo, int tipo, int nroSucursal)
        {
            string connetionString = "";
            SqlConnection connection;
            SqlCommand command;
            string sql = "";
            SqlDataReader dataReader;
            System.Data.DataTable dt = new System.Data.DataTable();

            sql = "SELECT usu.Tipo AS 'TIPO', usu.Nombre AS 'NOMBRE', usu.Legajo AS 'LEGAJO', usu.Clave AS 'CLAVE', suc.Descripcion AS 'SUCURSAL' " +
                  "FROM UsuariosPos usu INNER JOIN Sucursales suc " +
                  "ON usu.Sucursal = suc.Id " +
                  "WHERE ";

            if (!name.Equals(""))
                sql += "usu.Nombre LIKE '%" + name + "%' ";


            if (legajo != -1)
                sql += "usu.Legajo = " + legajo + " ";

            if (nroSucursal != -1)
                sql += "usu.NroSucursal = " + nroSucursal + " ";

            if(tipo != -1)
                sql += "and usu.Tipo = " + (tipo + 1);
            

            connection = new SqlConnection(connetionString);

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

    }
}
