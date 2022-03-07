using WeeklyXamarin.Core.Helpers;

namespace BlazorApp.Views
{
    public partial class ArticlePage : MauiPage, IQueryAttributable
    {
        public ArticlePage()
        {
            InitializeComponent();
        }

        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(Constants.Navigation.ParameterNames.ArticleId))
            {
                await ViewModel.InitializeAsync(query);
            }
        }
    }
}
