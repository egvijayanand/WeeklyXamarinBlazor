using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Wpf.Services
{
    public class DialogService : IDialogService
    {
        public Task DisplayAlert(string title, string message, string cancel)
        {
            _ = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            return Task.FromResult(true);
        }
    }
}
