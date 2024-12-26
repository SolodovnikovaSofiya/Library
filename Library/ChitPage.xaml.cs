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
    /// Логика взаимодействия для ChitPage.xaml
    /// </summary>
    public partial class ChitPage : Page
    {
        public ChitPage()
        {
            InitializeComponent();
        }

        private void ButtonAddReaders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadersAdd());
        }

        private void ButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChitBooks());

        }

        private void ButtonGrade_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GradeAdd());
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
