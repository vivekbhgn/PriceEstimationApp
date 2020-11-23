using EstimationApp.Utilities;
using ModelsLibrary.Models;
using Services.AuthenticationService;
using System.Windows.Input;

namespace EstimationApp.ViewModels
{
    public class LoginScreenViewModel : ViewModelBase
    {
        private ICommand authenticateUserCommand;
        private bool isUserNotFound;
        private ChangeCurrentViewHandler changeViewHandler;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsUserNotFound
        {
            get
            {
                return isUserNotFound;
            }
            set
            {
                isUserNotFound = value;
                NotifyPropertyChanged("IsUserNotFound");
            }
        }

        public ICommand AuthenticateUserCommand
        {
            get
            {
                return authenticateUserCommand;
            }
            set
            {
                authenticateUserCommand = value;
            }
        }
        private ICommand closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                return closeCommand;
            }
            set
            {
                closeCommand = value;
            }
        }

        public LoginScreenViewModel(ChangeCurrentViewHandler changeViewHandler)
        {
            this.changeViewHandler = changeViewHandler;
            AuthenticateUserCommand = new RelayCommand(AuthenticateUser, CanAuthenticateUSer);
            CloseCommand = new RelayCommand(CloseWindow, CanCloseWindow);
        }

        private bool CanCloseWindow(object arg)
        {
            return true;
        }

        private void CloseWindow(object obj)
        {
        }

        private bool CanAuthenticateUSer(object arg)
        {
            return true;
        }

        private void AuthenticateUser(object obj)
        {
            IsUserNotFound = false;
            UserAuthenticationService userService = new UserAuthenticationService();
            User user = userService.AuthenticateUser(UserName, Password);
            if (user != null)
            {
                DiscountStrategy discountStrategy = null;
                switch (user.UserType)
                {
                    case ModelsLibrary.Enums.UserTypeEnum.NormalUser:
                        discountStrategy = new NormalUserDiscountStrategy();
                        break;
                    case ModelsLibrary.Enums.UserTypeEnum.PrivilegedUser:
                        discountStrategy = new PrivilegedUserDiscountStrategy();
                        break;
                }
                EstimationScreenViewModel estimationScreenViewModel = new EstimationScreenViewModel(discountStrategy, user);
                changeViewHandler(estimationScreenViewModel);
            }
            else
            {
                IsUserNotFound = true;
            }
        }
    }
}
