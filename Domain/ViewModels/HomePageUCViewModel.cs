using DapperRentACar.Domain.Commands;
using DapperRentACar.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DapperRentACar.Domain.ViewModels
{
    public class HomePageUCViewModel : BaseViewModel
    {
        public RelayCommand AdminCommand { get; set; }
        public RelayCommand ClientCommand { get; set;}

        public HomePageUCViewModel()
        {
            AdminCommand = new RelayCommand((a) =>
            {
                var adminPageUC = new AdminPageUC();
                var adminPageUCVM = new AdminPageUCViewModel();
                adminPageUC.DataContext = adminPageUCVM;
                App.ChangePage(adminPageUC);
            });

            ClientCommand = new RelayCommand((c) =>
            {
                var clientPageUC = new ClientPageUC();
                var clientPageUCVM = new ClientPageUCViewModel();
                clientPageUC.DataContext = clientPageUCVM;
                App.ChangePage(clientPageUC);
            });
        }
    }
}
