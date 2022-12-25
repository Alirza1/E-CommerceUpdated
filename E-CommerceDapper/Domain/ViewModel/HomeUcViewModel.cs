using E_CommerceDapper.Domain.Command;
using E_CommerceDapper.Domain.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_CommerceDapper.Domain.ViewModel
{
    public class HomeUcViewModel:BaseViewModel
    {
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RegistrCommand { get; set; }

        public HomeUcViewModel()
        {
            Login();
            Registr();
        }

        public void Login()
        {
            LoginCommand = new RelayCommand((e) =>
            {
                App.MyGrid.Children.RemoveAt(0);
                var vm=new LoginUcViewModel();
                var uc = new LoginUC();
                uc.DataContext = vm;

                App.MyGrid.Children.Add(uc);
            });
        }
        public void Registr()
        {
            RegistrCommand = new RelayCommand((e) =>
            {
                App.MyGrid.Children.RemoveAt(0);
                var vm = new RegistrUcViewModel();
                var uc = new RegistrUc();
                uc.DataContext = vm;

                App.MyGrid.Children.Add(uc);
            });
        }
    }
}
