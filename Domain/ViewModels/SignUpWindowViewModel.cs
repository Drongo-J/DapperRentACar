using DapperRentACar.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DapperRentACar.Domain.ViewModels
{
    public class SignUpWindowViewModel : BaseViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand PayCommand { get; set; }

        private Brush usernameBorderBrush;

        public Brush UsernameBorderBrush
        {
            get { return usernameBorderBrush; }
            set { usernameBorderBrush = value; OnPropertyChanged(); }
        }

        private Brush emailBorderBrush;

        public Brush EmailBorderBrush
        {
            get { return emailBorderBrush; }
            set { emailBorderBrush = value; OnPropertyChanged(); }
        }

        private Brush passwordBorderBrush;

        public Brush PasswordBorderBrush
        {
            get { return passwordBorderBrush; }
            set { passwordBorderBrush = value; OnPropertyChanged(); }
        }

        private Brush reEnterPasswordBorderBrush;

        public Brush ReEnterPasswordBorderBrush
        {
            get { return reEnterPasswordBorderBrush; }
            set { reEnterPasswordBorderBrush = value; OnPropertyChanged(); }
        }

        public SignUpWindowViewModel()
        {
            UsernameBorderBrush = Brushes.Red;

            CloseCommand = new RelayCommand((c) =>
            {
                App.ChildWindow.Close();
                App.Rectangle.Visibility = Visibility.Hidden;
                App.ChildWindow = null;
            });
        }
    }
}
