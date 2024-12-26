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
    /// Логика взаимодействия для TirAdd.xaml
    /// </summary>
    public partial class TirAdd : Page
    {
        private Тиражи _currentUser = new Тиражи();
        public TirAdd()
        {
            InitializeComponent();
            DataContext = _currentUser;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void ButtonSave_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.Количество)) errors.AppendLine("Введите количество");
            else if (!int.TryParse(_currentUser.Количество, out int quantity)) errors.AppendLine("Количество должно быть числом");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                using (var context = new Entities())
                {
                    context.Тиражи.Add(_currentUser);
                    context.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
