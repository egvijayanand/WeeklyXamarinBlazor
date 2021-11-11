using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyXamarin.Core.Services;

namespace BlazorApp.Services
{
    public class DialogService : IDialogService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
#if WINDOWS || ANDROID
            await Shell.Current.DisplayAlert(title, message, cancel);
#else
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
#endif
        }
    }
}
