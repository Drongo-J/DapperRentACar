using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DapperRentACar.Domain.ViewModels
{
    public class SecurityWindowViewModel : BaseViewModel
    {
        public RelayCommand ConfirmCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        // This is bound to the user input
        private int verificationCode = 0;

        public int VerificationCode
        {
            get { return verificationCode; }
            set { verificationCode = value; }
        }

        // This is the real verification code
        private int SECURITY_CODE = 0;

        public SecurityWindowViewModel(int _securityCode, int car_id, int day_count)
        {
            SECURITY_CODE = _securityCode;

            CloseCommand = new RelayCommand((c) =>
            {
                App.ChildWindow.Close();
                App.Rectangle.Visibility = Visibility.Hidden;
                App.ChildWindow = null;
            });

            ConfirmCommand = new RelayCommand((c) =>
            {
                var newrent = new Rent()
                {
                    Car_Id = car_id,
                    Client_Id = App.CurrentClient.Id,
                    RentStartDate = DateTime.Now,
                    RentEndDate = DateTime.Now.AddDays(day_count)
                };
                App.Database.RentRepository.Add(newrent);
                MessageBox.Show($"Car was successfully rented!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseCommand.Execute(null);
            },
            (p) =>
            {
                if (VerificationCode == SECURITY_CODE)
                {
                    return true;
                }
                return false;
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
