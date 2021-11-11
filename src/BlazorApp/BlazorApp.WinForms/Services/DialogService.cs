using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.WinForms.Services
{
    public class DialogService : IDialogService
    {
        public Task DisplayAlert(string title, string message, string cancel)
        {
            _ = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(true);
        }
    }
}
