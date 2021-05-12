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
        
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            float total = 0;
            foreach (VentasProductos aCarro in Carro){
                foreach (Producto aProductos in Productos) {
                    if (aCarro.Producto_id == aProductos.Id){
                        total += aProductos.Precio;
                        aProductos.Stock--;
                    }
                }
            }
            textTotal.Text = String.Format("Total : {0}",total);
            Ventas.Add(new Venta(idactual,total,DateTime.Now,Carro));
            idactual++;
            //
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= Int32.Parse(textBoxCantidad.Text); i++)
            {
                Carro.Add(new VentasProductos(idactual, idproducto)); //aca se van a guardar los productos del carro
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Carro.ConvertAll(x => new { Value = x }); ;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBoxProducto_Enter(object sender, EventArgs e)
        {
            if (textBoxProducto.Text == "Producto") textBoxProducto.Clear(); 
        }

        private void textBoxCantidad_Enter(object sender, EventArgs e)
        {
            if (textBoxCantidad.Text == "Cantidad") textBoxCantidad.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Carro.Clear();
        }
    }
}
