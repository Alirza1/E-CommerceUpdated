using E_CommerceDapper.DataAccess.Entities;
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
    public class LoginUcViewModel : BaseViewModel
    {
        public RelayCommand LoginCommand { get; set; }

        private string emailTb;

        public string EmailTb   
        {
            get { return emailTb; }
            set { emailTb = value; OnPropertyChanged(); }
        }

        private string passwordTb;

        public string PasswordTb
        {
            get { return passwordTb; }
            set { passwordTb = value; OnPropertyChanged(); }
        }

        public List<User> Users { get; set; }

        public LoginUcViewModel()
        {
            Login();
        }

        public void Login()
        {
            var users = App.DB.UserRepository.GetAll();
            LoginCommand = new RelayCommand(async (e) =>
            {
                foreach (var item in await users)
                {
                    if (item.Email == EmailTb && item.Password == PasswordTb)
                    {
                        var vm = new CategoriesUcViewModel();
                        var uc = new CategoriesUc();
                        uc.DataContext = vm;
                        App.MyGrid.Children.RemoveAt(0);
                        App.MyGrid.Children.Add(uc);
                        break;
                    }

                }
            });
        }
    }
}
