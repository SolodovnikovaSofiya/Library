using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для DistributionAdd.xaml
    /// </summary>
    public partial class DistributionAdd : Page
    {
        public DistributionAdd()
        {
            InitializeComponent();

            comboBoxReaders.ItemsSource = Entities.GetContext().Читатели.ToList();
            comboBoxBooks.ItemsSource = Entities.GetContext().Книги.ToList();
            comboBoxStaff.ItemsSource = Entities.GetContext().Сотрудники.ToList();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonSave_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (comboBoxReaders.SelectedItem == null) errors.AppendLine("Выберите читателя");
            if (comboBoxBooks.SelectedItem == null) errors.AppendLine("Выберите книгу");
            if (comboBoxStaff.SelectedItem == null) errors.AppendLine("Выберите сотрудника");
            if (string.IsNullOrEmpty(Date_Dist.Text)) errors.AppendLine("Введите дату выдачи");

            DateTime distributionDate;
            if (!DateTime.TryParse(Date_Dist.Text, out distributionDate))
            {
                errors.AppendLine("Некорректный формат даты выдачи. Используйте формат ММ.ДД.ГГГГ");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return; // Выходим из метода, если есть ошибки
            }

            var selectedReader = comboBoxReaders.SelectedItem as Читатели;
            var selectedBook = comboBoxBooks.SelectedItem as Книги;
            var selectedStaff = comboBoxStaff.SelectedItem as Сотрудники;

            var newDistribution = new Выдача
            {
                Читатель_id = selectedReader.id,
                Экземпляр_id = selectedBook.id,
                Сотрудник_id = selectedStaff.id,
                Дата_выдачи = distributionDate
            };

            using (var context = new Entities())
            {
                context.Выдача.Add(newDistribution);
                context.SaveChanges();
            }

            MessageBox.Show("Выдача успешно добавлена!");
          
        }
    }
}
