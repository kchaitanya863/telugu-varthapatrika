using System.Threading.Tasks;
using System.Windows.Input;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public class MainViewModels : BindableBase
    {
       private Section1ViewModel _section1Model;
       private Section2ViewModel _section2Model;
       private Section10ViewModel _section10Model;

        private ViewModelBase _selectedItem = null;
        private PrivacyViewModel _privacyModel;

        public MainViewModels()
        {
            _selectedItem = Section1Model;
            _privacyModel = new PrivacyViewModel();
        }
 
        public Section1ViewModel Section1Model
        {
            get { return _section1Model ?? (_section1Model = new Section1ViewModel()); }
        }
 
        public Section2ViewModel Section2Model
        {
            get { return _section2Model ?? (_section2Model = new Section2ViewModel()); }
        }
 
        public Section10ViewModel Section10Model
        {
            get { return _section10Model ?? (_section10Model = new Section10ViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            Section1Model.ViewType = viewType;
            Section2Model.ViewType = viewType;
            Section10Model.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public bool IsAppBarVisible
        {
            get
            {
                if (SelectedItem == null || SelectedItem == Section1Model)
                {
                    return true;
                }
                return SelectedItem != null ? SelectedItem.IsAppBarVisible : false;
            }
        }

        public bool IsLockScreenVisible
        {
            get { return SelectedItem == null || SelectedItem == Section1Model; }
        }

        public bool IsAboutVisible
        {
            get { return SelectedItem == null || SelectedItem == Section1Model; }
        }

        public bool IsPrivacyVisible
        {
            get { return SelectedItem == null || SelectedItem == Section1Model; }
        }


        public void UpdateAppBar()
        {
            OnPropertyChanged("IsAppBarVisible");
            OnPropertyChanged("IsLockScreenVisible");
            OnPropertyChanged("IsAboutVisible");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                Section1Model.LoadItems(isNetworkAvailable),
                Section2Model.LoadItems(isNetworkAvailable),
                Section10Model.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }

        public ICommand LockScreenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LockScreenServices.SetLockScreen("/Assets/LockScreenImage.png");
                });
            }
        }
    }
}
