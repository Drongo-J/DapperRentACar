using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Helpers;
using DapperRentACar.Domain.Services;
using DapperRentACar.Domain.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DapperRentACar.Domain.ViewModels
{
    public class RentCarWindowViewModel : BaseViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand RentCommand { get; set; }

        private string days = "0";

        public string Days
        {
            get { return days; }
            set { days = value; OnPropertyChanged(); SetCost(); }
        }

        private string cost;

        public string Cost
        {
            get { return cost; }
            set { cost = value; OnPropertyChanged(); }
        }

        private void SetCost()
        {
            if (Days == string.Empty)
            {
                Cost = "0 " + Constants.DollarSign;
            }
            else
            {
                var _days = int.Parse(Days);
                Cost = (Car.RentPrice * _days).ToString() + " " + Constants.DollarSign;
            }
        }

        public Car Car { get; private set; }

        public RentCarWindowViewModel(Car _car)
        {
            Car = _car;
            SetCost();
            CloseCommand = new RelayCommand((c) =>
            {
                App.ChildWindow.Close();
                App.Rectangle.Visibility = Visibility.Hidden;
                App.ChildWindow = null;
            });

            RentCommand = new RelayCommand((r) =>
            {
                int randomSecurityCode = new Random().Next(100000, 999999);
                Thread emailThread = new Thread(() =>
                {
                    EmailService.SendEmail(App.CurrentClient.Email, Constants.EmailSubject, $"This is your security code : {randomSecurityCode}. Don't share it with anybody.");
                });
                emailThread.Start();
                CloseCommand.Execute(null);
                var securityWindow = new SecurityWindow();
                var securityWindowVM = new SecurityWindowViewModel(randomSecurityCode, Car.Id, int.Parse(Days));
                securityWindow.DataContext = securityWindowVM;
                App.ChildWindow = securityWindow;
                App.ChildWindow.Owner = App.Current.MainWindow;
                App.Rectangle.Visibility = Visibility.Visible;
                App.ChildWindow.ShowDialog();
            },
             (p) =>
             {
                 if (Days.Trim() == "0" || Days.Trim() == string.Empty)
                 {
                     return false;
                 }
                 return true;
             });
        }

        private static readonly Regex OnlyNumberRegex = new Regex("[0-9]+");
        public void IsAllowedInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            return OnlyNumberRegex.IsMatch(text);
        }
    }
}
