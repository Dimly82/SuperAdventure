using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperAdventure {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // var culture = CultureInfo.GetCultureInfo("ru");
            // CultureInfo.DefaultThreadCurrentCulture = culture;
            // CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SuperAdventure());
        }
    }
}