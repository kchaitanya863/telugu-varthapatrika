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
    public partial class Section1Detail
    {
        private bool _isDeepLink = false;

        public Section1Detail()
        {
            InitializeComponent();
        }

        public Section1ViewModel Section1Model { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Section1Model = NavigationServices.CurrentViewModel as Section1ViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    Section1Model = new Section1ViewModel();
                    NavigationServices.CurrentViewModel = Section1Model;
                    Section1Model.LoadItem(id);
                }
            }
            if (Section1Model != null)
            {
                Section1Model.ViewType = ViewTypes.Detail;
            }
            DataContext = Section1Model;
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
