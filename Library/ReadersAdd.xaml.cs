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
    /// Логика взаимодействия для ReadersAdd.xaml
    /// </summary>
    public partial class ReadersAdd : Page
    {
        private Читатели _currentUser = new Читатели();

        /// <summary>
        /// Инициализирует новый экземпляр класса ReadersAdd и устанавливает контекст данных для текущего читателя.
        /// </summary>
        public ReadersAdd()
        {
            InitializeComponent();
            DataContext = _currentUser;
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки "Отмена".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки "Сохранить".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверка введенных данных читателя.
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.Фамилия)) errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentUser.Имя)) errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentUser.Телефон)) errors.AppendLine("Введите телефон");
            else if (!Regex.IsMatch(_currentUser.Телефон, @"^\d{11}$")) errors.AppendLine("Телефон должен содержать 11 цифр");

            // Если есть ошибки, выводим сообщение и выходим из метода.
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            // Добавление нового читателя в базу данных.
            Entities.GetContext().Читатели.Add(_currentUser);
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