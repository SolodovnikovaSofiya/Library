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
    /// Логика взаимодействия для ReturnAdd.xaml
    /// </summary>
    public partial class ReturnAdd : Page
    {
        public ReturnAdd()
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

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (comboBoxReaders.SelectedItem == null) errors.AppendLine("Выберите читателя");
            if (comboBoxBooks.SelectedItem == null) errors.AppendLine("Выберите книгу");
            if (comboBoxStaff.SelectedItem == null) errors.AppendLine("Выберите сотрудника");
            if (string.IsNullOrEmpty(Date_Ret.Text)) errors.AppendLine("Введите дату возврата");

            DateTime distributionDate;
            if (!DateTime.TryParse(Date_Ret.Text, out distributionDate))
            {
                errors.AppendLine("Некорректный формат даты возврата. Используйте формат ММ.ДД.ГГГГ");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return; // Выходим из метода, если есть ошибки
            }

            var selectedReader = comboBoxReaders.SelectedItem as Читатели;
            var selectedBook = comboBoxBooks.SelectedItem as Книги;
            var selectedStaff = comboBoxStaff.SelectedItem as Сотрудники;

            var newDistribution = new Возврат
            {
                Читатель_id = selectedReader.id,
                Экземпляр_id = selectedBook.id,
                Сотрудник_id = selectedStaff.id,
                Дата_возврата = distributionDate
            };

            using (var context = new Entities())
            {
                context.Возврат.Add(newDistribution);
                context.SaveChanges();
            }

            MessageBox.Show("Возврат успешно добавлен!");
        }

    }
}
