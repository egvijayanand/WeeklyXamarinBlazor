﻿using VijayAnand.MauiToolkit.Core.Services;
//using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace BlazorApp.Wasm.Services
{
    public class ShareService : IShareService
    {
        public Task ShareTextAsync(string title, string text)
        {
            throw new NotImplementedException();
        }

        public Task ShareUriAsync(string title, string text, string url)
        {
            throw new NotImplementedException();
        }
    }
}
