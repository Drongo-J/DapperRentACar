using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Helpers;
using DapperRentACar.Domain.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace DapperRentACar.Domain.ViewModels
{
    public class SignInWindowViewModel : BaseViewModel
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

        public SignInWindowViewModel()
        {
            CloseCommand = new RelayCommand((c) =>
            {
                App.ChildWindow.Close();
                App.Rectangle.Visibility = Visibility.Hidden;
                App.ChildWindow = null;
            });

            SignUpCommand = new RelayCommand((s) =>
            {
                CloseCommand.Execute(null);
                var signUpWindow = new SignUpWindow();
                var signUpWindowVM = new SignUpWindowViewModel();
                signUpWindow.DataContext = signUpWindowVM;
                signUpWindowVM.PasswordBox = signUpWindow.PasswordBox;
                App.ChildWindow = signUpWindow;
                App.ChildWindow.Owner = App.Current.MainWindow;
                App.Rectangle.Visibility = Visibility.Visible;
                App.ChildWindow.ShowDialog();
            });

            SignInCommand = new RelayCommand((s) =>
            {
                var clients = App.Database.ClientRepository.GetAll();
                bool hasError = false;

                var _username = Username.Trim();
                var _password = PasswordBox.Password.Trim();

                UsernameWarningColor = Brushes.Transparent;
                PasswordWarningColor = Brushes.Transparent;

                if (_username == string.Empty)
                {
                    hasError = true;
                    UsernameWarningColor = Brushes.Red;
                    UsernameWarning = Constants.EmptyUsernameError;
                }
                if (_password == string.Empty)
                {
                    hasError = true;
                    PasswordWarningColor = Brushes.Red;
                    PasswordWarning = Constants.EmptyPasswordError;
                }

                if (hasError)
                    return;

                var client = clients.FirstOrDefault(c => c.Username == _username && c.Password == _password);

                if (client == null)
                {
                    // user does not exist
                    MessageBox.Show("User does not exist!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show($"Welcome {client.Username}!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                App.CurrentClient = client;

                // successfull sign in

                // how many days rent
            });
        }
    }
}
