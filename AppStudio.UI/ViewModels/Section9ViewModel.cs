using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class Section9ViewModel : ViewModelBase<RssSchema>
    {
        override protected string CacheKey
        {
            get { return "DataSource9DataSource"; }
        }

        override protected IDataSource<RssSchema> CreateDataSource()
        {
            return new DataSource9DataSource(); // RssDataSource
        }

        override public bool IsGoToSourceVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void GoToSource()
        {
            base.GoToSource("{FeedUrl}");
        }

        override public bool IsRefreshVisible
        {
            get { return ViewType == ViewTypes.List; }
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("Section9Detail");
        }
    }
}
