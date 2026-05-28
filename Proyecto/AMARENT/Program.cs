using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace AMARENT
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists("Content\\Data\\DataBase") == false)
            {
                Application.Run(new UI_BD_Select());
            }
            else
            {
                Application.Run(new UI_Menu_44MM());
            }
        }
    }
}
