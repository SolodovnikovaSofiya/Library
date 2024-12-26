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
using static Library.Books;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для ChitBooks.xaml
    /// </summary>
    public partial class ChitBooks : Page
    {
        public ChitBooks()
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

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
