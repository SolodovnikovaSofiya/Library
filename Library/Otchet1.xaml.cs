using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Otchet1.xaml
    /// </summary>
    public partial class Otchet1 : Page
    {
        private string connectionString = "data source=WIN-BGMEVL74NQI\\SQLEXPRESS;initial catalog=Библиотека;integrated security=True;";
        public Otchet1()
        {
            InitializeComponent();
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = @"
                        SELECT 
                            Выдача.id AS [№_Выдачи],
                            Книги.Название AS [Книга],
                            Читатели.Фамилия AS [Фамилия_читателя],
                            Читатели.Имя AS [Имя_читателя],
                            Читатели.Телефон AS [Телефон_читателя],
                            Выдача.Дата_Выдачи AS [Дата_выдачи],
                            Сотрудники.Фамилия AS [Ответственный]
                        FROM 
                            Выдача
                        INNER JOIN 
                            Книги ON Выдача.Экземпляр_id = Книги.id
                        INNER JOIN 
                            Читатели ON Выдача.Читатель_id = Читатели.id
                        INNER JOIN 
                            Сотрудники ON Выдача.Сотрудник_id = Сотрудники.id
                        ORDER BY 
                            Выдача.id ASC";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            IssuanceDataGrid.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
    }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
