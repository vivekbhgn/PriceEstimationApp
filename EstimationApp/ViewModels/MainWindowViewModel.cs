using EstimationApp.Utilities;
using System;
using System.Windows.Input;

namespace EstimationApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        public ICommand CloseWindowCommand { get; set; }
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                NotifyPropertyChanged("CurrentViewModel");
            }
        }
        public EstimationScreenViewModel EstimationScreenViewModel { get; set; }

        public LoginScreenViewModel LoginWindowViewModel { get; set; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new LoginScreenViewModel(ChangeCurrentView);
            CloseWindowCommand = new RelayCommand(CloseWindow, (object obj)=> { return true; });
        }

        private void CloseWindow(object obj)
        {
            CloseAction();
        }

        private void ChangeCurrentView(ViewModelBase viewModelToSwitchTo)
        {
            CurrentViewModel = viewModelToSwitchTo;
        }
    }
}
