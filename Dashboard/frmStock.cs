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
        public frmStock()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void MostrarProductos()
        {
            dataGridView1.DataSource = objetoCN.MostrarProd();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarProductos();
            }
            catch (Exception a){
                MessageBox.Show(a.Message);
            }
        }
    }
}
