using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Ventas
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //MUESTRA LAS VENTAS
        public DataTable Mostrar(DateTime fromdate, DateTime todate)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM ventas WHERE fecha BETWEN '"+fromdate+"' and '"+todate+"';";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //CREA UNA VENTA EN LA BASE DE DATOS
        public void Insertar(double monto, DateTime fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO ventas VALUES("+monto+",'"+fecha+"')";
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        //CARGA LOS ARTICULOS DE CADA VENTA
        public void Cargar(int idv, int idp)
        {
            comando.CommandText = "INSERT INTO ventas_productos VALUES("+idv+","+idp+")";
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public int getId()
        {
            int id;
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT IDENT_CURRENT('ventas')";
            id = comando.ExecuteNonQuery();
            return id;
        }
    }
}
