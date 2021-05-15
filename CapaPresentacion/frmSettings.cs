using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class frmSettings : Form
    {
        public int stockCritic=10, stockDanger=30, stockWarn=50;
        public string connectionString = "";

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            string[] settings = { "connectionString = Data Source = localhost; Initial Catalog = base1; Integrated Security = True; Pooling = False", "stockCritic = 10", "stockDanger = 30", "stockWarn = 50" };
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileSettings = Path.Combine(docPath, "Settings.txt");
            if (File.Exists(Path.Combine(fileSettings)) == false) 
            {
                File.Create(Path.Combine(fileSettings));
                using (StreamWriter outputFile = new StreamWriter(fileSettings))
                {
                    foreach (string line in settings)
                        outputFile.WriteLine(line);
                }
            }
            settings = File.ReadAllLines(fileSettings);
            connectionString = settings[0];
            stockCritic = Convert.ToInt32(settings[1]);
            stockDanger = Convert.ToInt32(settings[2]);
            stockWarn = Convert.ToInt32(settings[3]);
        }
    }
}
