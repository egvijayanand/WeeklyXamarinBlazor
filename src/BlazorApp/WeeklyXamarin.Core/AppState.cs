using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyXamarin.Core
{
    public class AppState
    {
        public event Action OnChanged;

        public string PreviousPage { get; private set; }

        public bool HasBackButton { get; private set; }

        public string PageTitle { get; private set; }

        public void SetBackButtonState(bool visible)
        {
            HasBackButton = visible;
            NotifyStateChanged();
        }

        public void SetPageTitle(string title)
        {
            PageTitle = title;
            NotifyStateChanged();
        }

        public void SetPreviousPage(string page)
        {
            PreviousPage = page;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChanged?.Invoke();
        }
    }
}
