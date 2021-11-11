using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
