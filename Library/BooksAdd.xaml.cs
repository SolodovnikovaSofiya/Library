using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для BooksAdd.xaml
    /// </summary>
    public partial class BooksAdd : Page
    {
        private Books.BookViewModel selectedBook;

        //private Книги _currentUser = new Книги();
        public BooksAdd()
        {
            InitializeComponent();
            //DataContext = _currentUser;

            comboBoxAuthors.ItemsSource = Entities.GetContext().Авторы.ToList();
            comboBoxGenre.ItemsSource = Entities.GetContext().Жанры.ToList();
            comboBoxIzd.ItemsSource = Entities.GetContext().Издательства.ToList();
            comboBoxTiragh.ItemsSource = Entities.GetContext().Тиражи.ToList();

        }

        public BooksAdd(Books.BookViewModel selectedBook)
        {
            this.selectedBook = selectedBook;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public bool Books(string comboBoxAuthorsId, string comboBoxGenreId, string comboBoxIzdId, string comboBoxTiraghId, string Names)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(comboBoxAuthorsId)) errors.AppendLine("Выберите автора");
            if (string.IsNullOrEmpty(comboBoxGenreId)) errors.AppendLine("Выберите жанр");
            if (string.IsNullOrEmpty(comboBoxIzdId)) errors.AppendLine("Выберите издательство");
            if (string.IsNullOrEmpty(comboBoxTiraghId)) errors.AppendLine("Выберите тираж");
            if (string.IsNullOrEmpty(Names)) errors.AppendLine("Введите название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            else
            {
                Entities db = new Entities();

                // Проверяем SelectedValue на null и преобразуем в int
                int comboBoxAuthorsIds = comboBoxAuthors.SelectedValue != null ? (int)comboBoxAuthors.SelectedValue : 0;
                int comboBoxGenreIds = comboBoxGenre.SelectedValue != null ? (int)comboBoxGenre.SelectedValue : 0;
                int comboBoxIzdIds = comboBoxIzd.SelectedValue != null ? (int)comboBoxIzd.SelectedValue : 0;
                int comboBoxTiraghIds = comboBoxTiragh.SelectedValue != null ? (int)comboBoxTiragh.SelectedValue : 0;

                // Создаем новый объект книги
                Книги userObject = new Книги
                {
                    Автор_id = comboBoxAuthorsIds,
                    Жанр_id = comboBoxGenreIds,
                    Издательство_id = comboBoxIzdIds,
                    Тираж_id = comboBoxTiraghIds,
                    Название = Names
                };

                // Добавляем книгу в базу данных
                db.Книги.Add(userObject);
                db.SaveChanges();

                MessageBox.Show("Книга успешно добавлена!");
                return true;
            }

        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string comboBoxAuthorsId = comboBoxAuthors.SelectedValue != null ? comboBoxAuthors.SelectedValue.ToString() : string.Empty;
            string comboBoxGenreId = comboBoxGenre.SelectedValue != null ? comboBoxGenre.SelectedValue.ToString() : string.Empty;
            string comboBoxIzdId = comboBoxIzd.SelectedValue != null ? comboBoxIzd.SelectedValue.ToString() : string.Empty;
            string comboBoxTiraghId = comboBoxTiragh.SelectedValue != null ? comboBoxTiragh.SelectedValue.ToString() : string.Empty;



            Books(comboBoxAuthorsId.ToString(), comboBoxGenreId.ToString(), comboBoxIzdId.ToString(), comboBoxTiraghId.ToString(), Names.Text);
           
        }

        
    }
}
