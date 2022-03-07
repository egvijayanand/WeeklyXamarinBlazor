namespace BlazorApp.WinForms
{
    public partial class BrowserForm : Form
    {
        WebBrowser browser;
        static readonly BrowserForm form = new();

        public BrowserForm()
        {
            InitializeComponent();
            browser = new WebBrowser()
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(browser);
        }

        public WebBrowser View => browser;

        public static BrowserForm Instance => form;
    }
}
