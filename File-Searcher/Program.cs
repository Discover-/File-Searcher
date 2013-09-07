using System;
using System.Runtime;
using System.Windows.Forms;

namespace File_Searcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProfileOptimization.SetProfileRoot(Environment.CurrentDirectory);
            ProfileOptimization.StartProfile("filesearch.profile");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
