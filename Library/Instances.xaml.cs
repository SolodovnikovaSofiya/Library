﻿using System;
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
    /// Логика взаимодействия для Instances.xaml
    /// </summary>
    public partial class Instances : Page
    {
        public Instances()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = Entities.GetContext().Экземпляры.ToList();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
