using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для BiblioPage.xaml
    /// </summary>
    public partial class BiblioPage : Page
    {
        public BiblioPage()
        {
            InitializeComponent();
        }

        private void ButtonReaders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Readers());
        }

        private void ButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Books());
        }

        private void ButtonDistribution_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Distribution());
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Return());
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
