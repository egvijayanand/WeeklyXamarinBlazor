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
            if (ViewModel is not null && query.ContainsKey(ArticleId))
            {
                await ViewModel.InitializeAsync(query);
            }
        }
    }
}
