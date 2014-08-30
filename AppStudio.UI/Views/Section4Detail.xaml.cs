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
    public partial class Section4Detail
    {
        private bool _isDeepLink = false;

        public Section4Detail()
        {
            InitializeComponent();
        }

        public Section4ViewModel Section4Model { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Section4Model = NavigationServices.CurrentViewModel as Section4ViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    Section4Model = new Section4ViewModel();
                    NavigationServices.CurrentViewModel = Section4Model;
                    Section4Model.LoadItem(id);
                }
            }
            if (Section4Model != null)
            {
                Section4Model.ViewType = ViewTypes.Detail;
            }
            DataContext = Section4Model;
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
