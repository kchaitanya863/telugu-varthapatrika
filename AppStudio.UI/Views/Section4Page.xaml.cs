using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public partial class Section4Page
    {
        private bool _isDeepLink = false;

        public Section4Page()
        {
            InitializeComponent();
            Section4Model = new Section4ViewModel();
        }

        public Section4ViewModel Section4Model { get; private set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                _isDeepLink = true;
            }
            Section4Model.ViewType = ViewTypes.List;
            NavigationServices.CurrentViewModel = null;
            DataContext = Section4Model;
            await Section4Model.LoadItems(NetworkInterface.GetIsNetworkAvailable());

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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_isDeepLink)
            {
                _isDeepLink = false;
                NavigationServices.NavigateToPage("MainPage");
            }
        }
    }
}
