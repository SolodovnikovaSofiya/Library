using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
        }

        private void ButtonMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllPages());
        }

        private void ButtonBiblio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BiblioPage());
        }

        private void ButtonChit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChitPage());
        }

        private void Button_btn(object sender, RoutedEventArgs e)
        {
            Process.Start("ПР12.chm");
        }
    }
}
