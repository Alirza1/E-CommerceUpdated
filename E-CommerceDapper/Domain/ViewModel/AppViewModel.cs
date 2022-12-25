using E_CommerceDapper.DataAccess.Entities;
using E_CommerceDapper.Domain.Command;
using E_CommerceDapper.Domain.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace E_CommerceDapper.Domain.ViewModel
{
    public class AppViewModel:BaseViewModel
    {

        public AppViewModel()
		{
            var homeUcVm = new HomeUcViewModel();
            var homeUc = new HomeUc();
            homeUc.DataContext = homeUcVm;

            App.MyGrid.Children.Add(homeUc);
        }
	}
}
