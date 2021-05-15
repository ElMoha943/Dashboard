using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_Ventas
    {
        private CD_Ventas objetoCD = new CD_Ventas();

        public DataTable MostrarVent(DateTime fromdate, DateTime todate)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(fromdate,todate);
            return tabla;
        }
        public void InsertarVent(double monto)
        {
            objetoCD.Insertar(monto, DateTime.Now);
        }

        public void CargarVent(string idv, int idp)
        {
            objetoCD.Cargar(Convert.ToInt32(idv), idp);
        }

        public int GetIdVent()
        {
            return objetoCD.getId();
        }
    }
}
