using DapperRentACar.DataAccess.Entitites;
using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Helpers;
using DapperRentACar.Domain.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace DapperRentACar.Domain.ViewModels
{
    public class RentCarUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand LocationCommand { get; set; }
        public RelayCommand AutosalonCommand { get; set; }
        public RelayCommand RentCarCommand { get; set; }

        public Car Car { get; set; }

        public string RentPrice { get; set; }
        public string Mileage { get; set; }
        public string IsNew { get; set; }
        public string Announcements { get; set; }

        public RentCarUCViewModel(Car _car)
        {
            Car = _car;
            RentPrice = Car.RentPrice + " " + Constants.DollarSign + Constants.PerDay;
            Mileage = Car.Mileage.ToString() + " " + Constants.Kilometer;
            Announcements = App.Database.CarRepository.GetAll().Count().ToString() + " announcements";

            if (Car.IsNew)
                IsNew = "Yes";
            else
                IsNew = "No";

            BackCommand = new RelayCommand((b) =>
            {
                App.GoToPreviousPage();
            });

            LocationCommand = new RelayCommand((l) =>
            {
                Process.Start("https://www.google.com/maps?q=40.408569%2C49.824268&ll=40.408569%2C49.824268&z=15");
            });

            AutosalonCommand = new RelayCommand((l) =>
            {
                Process.Start("https://turbo.az/avtosalonlar/avtosalon-rh");
            });

            RentCarCommand = new RelayCommand((r) =>
            {
                var text = File.ReadAllText(Constants.HasSignedUpFilePath);

                if (text == Constants.True)
                {

                }
                else
                {
                    var signUpWindow = new SignUpWindow();
                    var signUpWindowVM = new SignUpWindowViewModel();
                    signUpWindow.DataContext = signUpWindowVM;
                    App.ChildWindow = signUpWindow;
                    App.Rectangle.Visibility = Visibility.Visible;
                    signUpWindow.ShowDialog();
                }
            });
        }
    }
}
    