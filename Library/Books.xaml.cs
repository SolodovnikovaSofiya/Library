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
    /// Логика взаимодействия для Books.xaml
    /// </summary>
    public partial class Books : Page
    {
        public Books()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = Entities.GetContext().Книги.ToList();

            var books = Entities.GetContext().Книги.ToList();
            var bookViewModels = books.Select(b => new BookViewModel
            {
                Id = b.id,
                Название = b.Название,
                Автор = b.Авторы.Фамилия, 
                Жанр = b.Жанры.Название,
                Издательство = b.Издательства.Название, 
                Тираж = b.Тиражи.Количество 
            }).ToList();

            DataGridUser.ItemsSource = bookViewModels;
        }
        public class BookViewModel
        {
            public int Id { get; set; }
            public string Название { get; set; }
            public string Автор { get; set; } // Фамилия автора
            public string Жанр { get; set; }
            public string Издательство { get; set; }
            public string Тираж { get; set; }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BooksAdd());
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DataGridUser.SelectedItems.Cast<Книги>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {usersForRemoving.Count} элементов?", "Внимание",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Книги.RemoveRange(usersForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridUser.ItemsSource = Entities.GetContext().Книги.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
