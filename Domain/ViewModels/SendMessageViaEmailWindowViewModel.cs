using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DapperRentACar.Domain.ViewModels
{
    public class SendMessageViaEmailWindowViewModel : BaseViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SendCommand { get; set; }

        private string message = string.Empty;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public SendMessageViaEmailWindowViewModel(string toEmail)
        {
            CloseCommand = new RelayCommand((c) =>
            {
                App.ChildWindow.Close();
                App.Rectangle.Visibility = Visibility.Hidden;
                App.ChildWindow = null;
            });

            SendCommand = new RelayCommand((s) =>
            {
                var result = MessageBox.Show($"Do you really want to send message to {toEmail}?", "Send Message", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Thread emailThread = new Thread(() =>
                    {
                        EmailService.SendEmail(toEmail, "Email from RH Car Dealership | Rent A Car", Message);
                    });
                    CloseCommand.Execute(null);
                    MessageBox.Show($"Mail was sent successfully!", "Message was sent");
                }
            },
            (p) =>
            {
                if (Message.Trim().Length > 0)
                    return true;
                return false;
            });
        }
    }
}
