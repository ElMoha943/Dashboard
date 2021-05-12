using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Dashboard
{
    public partial class frmDashboard : Form
    {
        float total;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server=localhost; Database=base1; User Id=edgardo; Password=chile971; Trusted_Connection=False; MultipleActiveResultSets=true");
            //SqlCommand command = new SqlCommand("select from productos where id equals {id}");
            SqlCommand command = new SqlCommand("insert into productos(nombre,precio,stock) values ('coca',100,50);");
            conexion.Open();
            MessageBox.Show("conexion abierta");
            conexion.Close();
            //Ventas.Add(new Venta(total,DateTime.Now,Productos));
            //Productos.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
