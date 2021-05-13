using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Dashboard
{
    public partial class frmDashboard : Form
    {
        uint idproducto, idactual;
        List<VentasProductos> Carro = new List<VentasProductos>();
        List<Producto> Productos = new List<Producto>();
        List<Venta> Ventas = new List<Venta>();
        float total = 0;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void agregarAlCarro()
        {
            uint aux = 0, cant;
            try
            {
                cant = UInt32.Parse(textBoxCantidad.Text);
            }
            catch
            {
                cant = 1;
            }
            for (int i = 1; i <= cant; i++)
            {
                try
                {
                    idproducto = UInt32.Parse(textBoxProducto.Text);
                }
                catch
                {

                }
                foreach (Producto aProductos in Productos)
                {
                    if (idproducto == aProductos.Id || textBoxProducto.Text == aProductos.Nombre)
                    {
                        total += aProductos.Precio;
                        aux = 1;
                        dataGridView1.Rows.Add(aProductos.Nombre, aProductos.Precio);
                        Carro.Add(new VentasProductos(idactual, idproducto)); //aca se van a guardar los productos del carro
                    }
                }
            }
            if (aux != 1) MessageBox.Show("Producto no encontrado!");
            textTotal.Text = String.Format("Total: {0}", total);
            textBoxProducto.Clear();
            textBoxCantidad.Clear();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            Productos.Add(new Producto(1, "Cocacola", 500, 100));
            dataGridView1.Columns.Add("producto", "producto");
            dataGridView1.Columns.Add("precio", "precio");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            foreach (VentasProductos aCarro in Carro){
                foreach (Producto aProductos in Productos) {
                    if (aCarro.Producto_id == aProductos.Id){
                        total += aProductos.Precio;
                        aProductos.Stock--;
                    }
                }
            }
            total = 0;
            textTotal.Text = String.Format("Total: {0}", total);
            Ventas.Add(new Venta(idactual,total,DateTime.Now,Carro));
            Carro.Clear();
            idactual++;
            dataGridView1.Rows.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarAlCarro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Carro.Clear();
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
