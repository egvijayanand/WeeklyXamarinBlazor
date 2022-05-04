namespace BlazorApp.ViewModels
{
    public interface IViewModel
    {
        string Title { get; set; }

        Task InitializeAsync(IDictionary<string, object> parameters);
    }
}
