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
    public partial class frmStock : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto;
        public frmStock()
        {
            InitializeComponent();
        }

        private void MostrarProductos()
        {
            CN_Productos objetoCN = new CN_Productos(); //para refrescar el objeto.
            dataGridView1.DataSource = objetoCN.MostrarProd();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarProductos();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStockSave_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.InsertarPRod(stkBoxProducto.Text, stkBoxDesc.Text, stkBoxMarca.Text, stkBoxPrecio.Text, stkBoxStock.Text);
                MessageBox.Show("Producto agregado correctamente");
                MostrarProductos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStockDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.EliminarPRod("");
                MessageBox.Show("Producto borrado correctamente");
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStockEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                stkBoxProducto.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                stkBoxDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                stkBoxMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                stkBoxPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                stkBoxStock.Text = dataGridView1.CurrentRow.Cells["stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                //try
                //{
                //    objetoCN.EditarProd(stkBoxProducto.Text, stkBoxDesc.Text, stkBoxMarca.Text, stkBoxPrecio.Text, stkBoxStock.Text, idProducto);
                //    MessageBox.Show("Producto editado correctamente");
                //    MostrarProductos();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else MessageBox.Show("Seleccione una fila a editar!");
        }
    }
}
