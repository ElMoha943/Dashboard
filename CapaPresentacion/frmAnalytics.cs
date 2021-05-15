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

    public partial class frmAnalytics : Form
    {
        private CN_Ventas objetoCNV = new CN_Ventas();
        public frmAnalytics()
        {
            InitializeComponent();
        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            DataTable dt = objetoCNV.MostrarVent(DateTime.Today.AddMonths(-1),DateTime.Today);
            chart1.DataBindTable(dt.DefaultView,"fecha");
        }
    }
}
