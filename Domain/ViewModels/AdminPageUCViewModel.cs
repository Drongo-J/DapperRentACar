using DapperRentACar.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.Domain.ViewModels
{
    public class AdminPageUCViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        public AdminPageUCViewModel()
        {
            BackCommand = new RelayCommand((b) =>
            {
                App.GoToPreviousPage();
            });
        }
    }
}
