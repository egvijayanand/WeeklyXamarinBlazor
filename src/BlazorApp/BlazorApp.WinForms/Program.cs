using Microsoft.Extensions.DependencyInjection;
using WeeklyXamarin.Core.Helpers;

namespace BlazorApp.WinForms
{
    static class Program
    {
        internal static readonly Dictionary<string, Form> Routes = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Startup.Init();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var webForm = Startup.Services.GetService<WebForm>();
            Routes.Add(Paths.Article, webForm);
            Routes.Add(Paths.Web, webForm);

            webForm.Show();

            while (!webForm.Initialized)
            {
                Application.DoEvents();
            }

            Application.Run(new MainForm());
        }
    }
}
