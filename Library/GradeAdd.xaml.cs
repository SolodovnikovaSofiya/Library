using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для GradeAdd.xaml
    /// </summary>
    public partial class GradeAdd : Page
    {
        //private Оценка_книг _currentUser = new Оценка_книг();
        public GradeAdd()
        {
            InitializeComponent();
            //DataContext = _currentUser;

            comboBoxReaders.ItemsSource = Entities.GetContext().Читатели.ToList();
            comboBoxBooks.ItemsSource = Entities.GetContext().Книги.ToList();
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
            if (string.IsNullOrEmpty(grade.Text)) errors.AppendLine("Введите оценку");
            else if (!Regex.IsMatch(grade.Text, @"^[1-5]$"))
            {
                errors.AppendLine("Оценка должна содержать цифру от 1 до 5");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return; // Выходим из метода, если есть ошибки
            }

            var selectedReader = comboBoxReaders.SelectedItem as Читатели;
            var selectedBook = comboBoxBooks.SelectedItem as Книги;

            if (selectedReader == null || selectedBook == null)
            {
                MessageBox.Show("Необходимо выбрать читателя и книгу.");
                return; // Выходим из метода, если читатель или книга не выбраны
            }

            var newGrade = new Оценка_книг
            {
                Читатель_id = selectedReader.id,
                Книга_id = selectedBook.id,
                Оценка = grade.Text
            };

            using (var context = new Entities())
            {
                context.Оценка_книг.Add(newGrade);
                context.SaveChanges();
            }

            MessageBox.Show("Оценка успешно добавлена!");
          
        }
    }
}
