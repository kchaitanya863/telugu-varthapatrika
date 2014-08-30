using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Microsoft.Phone.Controls;

using MyToolkit.Paging;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public partial class Section6Detail
    {
        private bool _isDeepLink = false;

        public Section6Detail()
        {
            InitializeComponent();
        }

        public Section6ViewModel Section6Model { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Section6Model = NavigationServices.CurrentViewModel as Section6ViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    Section6Model = new Section6ViewModel();
                    NavigationServices.CurrentViewModel = Section6Model;
                    Section6Model.LoadItem(id);
                }
            }
            if (Section6Model != null)
            {
                Section6Model.ViewType = ViewTypes.Detail;
            }
            DataContext = Section6Model;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationServices.CurrentViewModel = null;
            }
            SpeechServices.Stop();
            base.OnNavigatedFrom(e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (_isDeepLink)
            {
                _isDeepLink = false;
                NavigationServices.NavigateToPage("MainPage");
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeechServices.Stop();
        }
    }
}
