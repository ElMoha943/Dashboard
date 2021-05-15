using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //MUESTRA TODOS LOS PRODUCTOS
        public DataTable Mostrar() { 
       
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from productos;";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //CREA UN PRODUCTO NUEVO
        public void Insertar(string nombre,string desc,string marca,double precio, int stock ) {
            
            comando.Connection = conexion.AbrirConexion();
            //insert into productos values('coca','1 litro','Cocacola',100,10);
            comando.CommandText = "INSERT INTO productos VALUES('"+nombre+"','"+desc+"','"+marca+"',"+precio+","+stock+")";
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        //EDITA UN PRODUCTO
        public void Editar(string nombre, string desc, string marca, double precio, int stock,int id)
        {
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UPDATE productos SET nombre= '" + nombre + "', descripcion= '" + desc + "', marca= '" + marca + "', precio= " + precio + ", stock= " + stock + " WHERE id = " + id + ";";
            comando.ExecuteNonQuery();
        }

        //ELIMINA UN PRODUCTO
        public void Eliminar(int id) {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DELETE FROM productos WHERE id="+id+";";
            comando.ExecuteNonQuery();
        }

        //BUSCA UN PRODUCTO EN ESPECIFICO
        public DataTable Buscar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * from productos WHERE id=" + id + ";";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
