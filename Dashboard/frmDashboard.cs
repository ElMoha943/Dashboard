using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace Dashboard
{
    public partial class frmDashboard : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        CN_Ventas objetoCNV = new CN_Ventas();
        List<Producto> Productos = new List<Producto>();
        Double total = 0;
        DataTable busqueda;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void agregarAlCarro()
        {
            uint cant;
            try
            {
                cant = UInt32.Parse(textBoxCantidad.Text);
            }
            catch
            {
                cant = 1;
            }
            busqueda = objetoCN.BuscarProd(textBoxProducto.Text);
            if (busqueda.Rows.Count > 0)  //chequea que los productos existan
            {
                //añade los productos al carro
                for (uint i = 1;i<=cant;i++)
                {
                    Productos.Add(new Producto(busqueda.Rows[0][0].ToString(), busqueda.Rows[0][1].ToString(), 
                        busqueda.Rows[0][2].ToString(), busqueda.Rows[0][3].ToString(),
                        busqueda.Rows[0][4].ToString(), busqueda.Rows[0][5].ToString()));
                    total +=Convert.ToDouble(busqueda.Rows[0][4].ToString());
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado!");
            }
            dataGridView1.Update();
            textTotal.Text = String.Format("Total: {0}", total);
            textBoxProducto.Clear();
            textBoxCantidad.Clear();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Productos;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (Productos != null)
            {
                objetoCNV.InsertarVent(total);
                int idv = objetoCNV.GetIdVent();
                foreach (Producto aProducto in Productos)
                {
                    objetoCNV.CargarVent(aProducto.Id,idv);
                }
                MessageBox.Show("Venta Exitosa");
                Productos.Clear();
                total = 0;
                textTotal.Text = String.Format("Total: {0}", total);
            }
            else
            {
                MessageBox.Show("El carro esta vacio");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarAlCarro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Productos.Clear();
            dataGridView1.Rows.Clear();
            total = 0;
            textTotal.Text = String.Format("Total: {0}", total);
        }

        private void textBoxProducto_Enter(object sender, EventArgs e)
        {
            if (textBoxProducto.Text == "Producto") textBoxProducto.Clear();
        }

        private void textBoxCantidad_Enter(object sender, EventArgs e)
        {
            if (textBoxCantidad.Text == "Cantidad") textBoxCantidad.Clear();
        }

        private void textBoxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter) agregarAlCarro();
        }

        private void textBoxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter) agregarAlCarro();
        }

    }
}
