using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class Section10ViewModel : ViewModelBase<MenuSchema>
    {
        override protected string CacheKey
        {
            get { return "DataSource10DataSource"; }
        }

        override protected IDataSource<MenuSchema> CreateDataSource()
        {
            return new DataSource10DataSource(); // MenuDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override protected void NavigateToSelectedItem()
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                if (currentItem.GetValue("Type").EqualNoCase("Section"))
                {
                    NavigationServices.NavigateToPage(currentItem.GetValue("Target"));
                }
                else
                {
                    NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Target"), UriKind.Absolute));
                }
            }
        }
    }
}
