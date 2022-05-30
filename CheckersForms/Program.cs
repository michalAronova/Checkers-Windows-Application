using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheckersForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///[STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            ///Application.SetCompatibleTextRenderingDefault(false);
            ///Application.Run(new FormGameSettings());
            ///int x = 5;
            FormGameSettings test = new FormGameSettings();
            test.ShowDialog();
            ///make FormGameSettings
            ///show dialog of it
            ///if dialog result is ok meaning things were chosen
            ///initialize FormGame(FormGameSettings) ?
            ///make FormGame and show dialog
        }
    }
}
