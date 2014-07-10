using System;
using System.Windows.Forms;

namespace TerrariaWorldViewer
{
    static class Program
    {
        /// <summary>
        /// Main entry point for application
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize Manager
            ResourceManager.Instance.Initialize();
            SettingsManager.Instance.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WorldViewForm());

            SettingsManager.Instance.Shutdown();
        }
    }
}
