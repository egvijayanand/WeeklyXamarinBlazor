﻿using System.Windows;
using VijayAnand.MauiToolkit.Core;

namespace BlazorApp.Wpf.Services
{
    public class DialogService : IDialogService
    {
        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            throw new NotImplementedException();
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            _ = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
            return Task.FromResult(true);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Information);
            return Task.FromResult(result == MessageBoxResult.OK);
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
        {
            throw new NotImplementedException();
        }
    }
}