using System;
using System.Windows.Forms;
using N9.Data;

namespace N9
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize database on startup
            DatabaseInitializer.Initialize();
            
            // Start with login form
            Application.Run(new FormDangNhap());
        }
    }
}
