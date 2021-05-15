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
        frmSettings settings = new frmSettings();
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto;
        private bool EDITAR = false;
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
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStockSave_Click(object sender, EventArgs e)
        {
            if (EDITAR == false)
            {
                try
                {
                    objetoCN.InsertarPRod(stkBoxProducto.Text, stkBoxDesc.Text, stkBoxMarca.Text, stkBoxPrecio.Text, stkBoxStock.Text);
                    MessageBox.Show("Producto agregado correctamente");
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(EDITAR== true)
            {
                try
                {
                    objetoCN.EditarProd(stkBoxProducto.Text, stkBoxDesc.Text, stkBoxMarca.Text, stkBoxPrecio.Text, stkBoxStock.Text, idProducto);
                    MessageBox.Show("Producto editado correctamente");
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                btnStockSave.Text = "AGREGAR PRODUCTO";
                EDITAR = false;
            }
        }

        private void btnStockDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    objetoCN.EliminarPRod(idProducto);
                    MessageBox.Show("Producto borrado correctamente");
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnStockEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EDITAR = true;
                btnStockSave.Text = "GUARDAR CAMBIOS";
                stkBoxProducto.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                stkBoxDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                stkBoxMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                stkBoxPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                stkBoxStock.Text = dataGridView1.CurrentRow.Cells["stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else MessageBox.Show("Seleccione una fila a editar!");
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "stock")
            {
                int stock = Convert.ToInt32(e.Value);
                if (stock < settings.stockCritic ) e.CellStyle.ForeColor = Color.Red;
                else if (stock < settings.stockDanger) e.CellStyle.ForeColor = Color.Green;
                else if (stock < settings.stockWarn) e.CellStyle.ForeColor = Color.Cyan;
                else e.CellStyle.ForeColor = Color.White;
            }
        }
    }
}
