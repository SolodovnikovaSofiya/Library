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
    /// Логика взаимодействия для AuthorAdd.xaml
    /// </summary>
    public partial class AuthorAdd : Page
    {
        private Авторы _currentUser = new Авторы();
        public AuthorAdd()
        {
            InitializeComponent();
            DataContext = _currentUser;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.Фамилия)) errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentUser.Имя)) errors.AppendLine("Введите имя");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            Entities.GetContext().Авторы.Add(_currentUser);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
