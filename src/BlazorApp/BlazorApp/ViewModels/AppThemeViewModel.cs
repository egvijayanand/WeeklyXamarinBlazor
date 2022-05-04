namespace BlazorApp.ViewModels
{
    public partial class AppThemeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = string.Empty;
        private readonly IPreferences preferences;
        private readonly IThemeService theme;

        public AppThemeViewModel(IPreferences preferences, IThemeService theme)
        {
            Title = "Theme";
            this.preferences = preferences;
            this.theme = theme;
        }

        public int Theme
        {
            get => theme?.Theme ?? 0;
            set
            {
                preferences?.Set(nameof(Theme), value, null);
                theme?.SetTheme();
            }
        }

        public bool UseSystem
        {
            get => Theme == 0;
            set
            {
                if (value)
                {
                    Theme = 0;
                }
            }
        }

        public bool LightTheme
        {
            get => Theme == 1;
            set
            {
                if (value)
                {
                    Theme = 1;
                }
            }
        }

        public bool DarkTheme
        {
            get => Theme == 2;
            set
            {
                if (value)
                {
                    Theme = 2;
                }
            }
        }
    }
}
