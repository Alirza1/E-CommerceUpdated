using E_CommerceDapper.DataAccess.Abstractions;
using E_CommerceDapper.DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace E_CommerceDapper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityOfWork DB;
        public static Grid MyGrid;
        public App()
        {
            DB = new UnitOfWork();
        }
    }
}
