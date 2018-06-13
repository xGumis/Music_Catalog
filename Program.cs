using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katalog_Muzyki
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Catalog_List model = new Catalog_List();
            Main_Window view = new Main_Window();
            Presenter presenter = new Presenter(view,model);
            Application.Run(view);
        }
    }
}
