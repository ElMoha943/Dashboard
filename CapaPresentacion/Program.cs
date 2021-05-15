using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Dashboard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            //string connectionstring = "server=localhost;database=base1;user id=edgardo;password=chile971;port=3306;";
            //MySqlConnection conexion = new MySqlConnection(connectionstring);
            //string sqlquery = "";
            //MySqlCommand comando = new MySqlCommand(sqlquery, conexion);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
