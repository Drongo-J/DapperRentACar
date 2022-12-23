using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Helpers;
using DapperRentACar.Domain.Views.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace DapperRentACar.Domain.ViewModels
{
    public class SignUpWindowViewModel : BaseViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SignUpCommand { get; set; }
        public RelayCommand SignInCommand { get; set; }

        #region Username Related
        private string username = string.Empty;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private SolidColorBrush usernameWarningColor;

        public SolidColorBrush UsernameWarningColor
        {
            get { return usernameWarningColor; }
            set { usernameWarningColor = value; OnPropertyChanged(); }
        }

        private string usernameWarning;

        public string UsernameWarning
        {
            get { return usernameWarning; }
            set { usernameWarning = value; OnPropertyChanged(); }
        }
        #endregion

        #region EmailRelated
        private string email = string.Empty;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private SolidColorBrush emailWarningColor;

        public SolidColorBrush EmailWarningColor
        {
            get { return emailWarningColor; }
            set { emailWarningColor = value; OnPropertyChanged(); }
        }

        private string emailWarning;

        public string EmailWarning
        {
            get { return emailWarning; }
            set { emailWarning = value; OnPropertyChanged(); }
        }
        #endregion

        #region Password Related

        public PasswordBox PasswordBox { get; set; }

        private SolidColorBrush passwordWarningColor;

        public SolidColorBrush PasswordWarningColor
        {
            get { return passwordWarningColor; }
            set { passwordWarningColor = value; OnPropertyChanged(); }
        }

        private string passwordWarning;

        public string PasswordWarning
        {
            get { return passwordWarning; }
            set { passwordWarning = value; OnPropertyChanged(); }
        }
        #endregion

        private static readonly Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public SignUpWindowViewModel()
        {
            CloseCommand = new RelayCommand((c) =>
            {
                App.ChildWindow.Close();
                App.Rectangle.Visibility = Visibility.Hidden;
                App.ChildWindow = null;
            });

            SignInCommand = new RelayCommand((s) =>
            {
                CloseCommand.Execute(null);

                var signInWindow = new SignInWindow();
                var signInWindowVM = new SignInWindowViewModel();
                signInWindow.DataContext = signInWindowVM;
                signInWindowVM.PasswordBox = signInWindow.PasswordBox;
                App.ChildWindow = signInWindow;
                App.ChildWindow.Owner = App.Current.MainWindow;
                App.Rectangle.Visibility = Visibility.Visible;
                App.ChildWindow.ShowDialog();
            });

            SignUpCommand = new RelayCommand((s) =>
            {
                var clients = App.Database.ClientRepository.GetAll();
                bool hasError = false;

                var _username = Username.Trim();
                var _email = Email.Trim();
                var _password = PasswordBox.Password.Trim();

                UsernameWarningColor = Brushes.Transparent;
                EmailWarningColor = Brushes.Transparent;
                PasswordWarningColor = Brushes.Transparent;

                if (_username == string.Empty)
                {
                    hasError = true;
                    UsernameWarningColor = Brushes.Red;
                    UsernameWarning = Constants.EmptyUsernameError;
                }
                if (_email == string.Empty)
                {
                    hasError = true;
                    EmailWarningColor = Brushes.Red;
                    EmailWarning = Constants.EmptyEmailError;
                }
                if (_password == string.Empty)
                {
                    hasError = true;
                    PasswordWarningColor = Brushes.Red;
                    PasswordWarning = Constants.EmptyPasswordError;
                }

                if (clients.Any(c => c.Username == _username))
                {
                    hasError = true;
                    UsernameWarningColor = Brushes.Red;
                    UsernameWarning = Constants.UsernameTakenError;
                }
                if (clients.Any(c => c.Email == _email))
                {
                    hasError = true;
                    EmailWarningColor = Brushes.Red;
                    EmailWarning = Constants.EmailAlreadyRegisteredError;
                }
                if (!EmailRegex.IsMatch(_email))
                {
                    hasError = true;
                    EmailWarningColor = Brushes.Red;
                    EmailWarning = Constants.IncorrectEmailError;
                }
                if (_username.Length < 3)
                {
                    hasError = true;
                    UsernameWarningColor = Brushes.Red;
                    UsernameWarning = Constants.UsernameLengthError;
                }
                if (_password.Length < 8)
                {
                    hasError= true;
                    PasswordWarningColor = Brushes.Red;
                    PasswordWarning = Constants.PasswordLengthError;
                }

                if (hasError)
                    return;

                var client = new Client()
                {
                     Username = _username,
                     Email = _email,
                     Password = _password
                }; 

                App.Database.ClientRepository.Add(client);
                App.CurrentClient = App.Database.ClientRepository.GetAll().Where(c => c.Email == this.Email).First();
                
                // successfull sign up

                // how many days rent
                
                // add database
            });
        }
    }
}
