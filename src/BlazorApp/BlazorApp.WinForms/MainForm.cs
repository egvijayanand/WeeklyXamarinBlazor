using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using WeeklyXamarin.Core;

namespace BlazorApp.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = Startup.Services
            };

            blazor.RootComponents.Add<Main>("#app");
            Controls.Add(blazor);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
