using BlazorApp.Views;
using System.Globalization;
using System.Reflection;

namespace BlazorApp.ViewModels
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached(nameof(AutoWireViewModelProperty),
                                            typeof(bool),
                                            typeof(ViewModelLocator),
                                            default(bool),
                                            propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is not MauiPage view)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName;
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

            var viewModelName = viewName.Replace(".Views.", ".ViewModels.").Replace("Page", "ViewModel");
            var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, $"{viewModelName}, {viewAssemblyName}");
            var viewModelType = Type.GetType(viewModelTypeName);

            if (viewModelType == null)
            {
                return;
            }

            view.ViewModel = App.Instance.Services.GetService(viewModelType) as ViewModelBase;
            view.BindingContext = view.ViewModel;
        }
    }
}
