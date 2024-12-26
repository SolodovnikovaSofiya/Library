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
    /// Логика взаимодействия для AllPages.xaml
    /// </summary>
    public partial class AllPages : Page
    {
        public AllPages()
        {
            InitializeComponent();
        }

        private void ButtonBook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Books());
        }

        private void ButtonReader_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Readers());
        }

        private void ButtonStaff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Staff());
        }

        private void ButtonGrade_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Grade());
        }

        private void ButtonDist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Distribution());
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Return());
        }

        private void ButtonGenre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Genre());
        }

        private void ButtonIzd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Izd());
        }

        private void ButtonAuthor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Author());
        }

        private void ButtonTir_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Tir());
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Instances());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authors_Books());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Otchet());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Otchet1());
        }
    }
}
