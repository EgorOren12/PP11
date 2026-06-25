using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PP11
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private List<string> roles = new List<string>() {
            "Администратор",
            "Диспетчер",
            "Руководитель"
        };
        private List<string> filials = new List<string>()
        {
            "Оренбург",
            "Бузулук",
            "Орск",
            "Медногорск",
            "Новотроицк",
            "Кувандык",
            "Гай",
            "Сорочинск",
            "Абдулино",
            "Бугуруслан"

        };

        public RegistrationWindow()
        {
            InitializeComponent();
            RolesComboBox.ItemsSource = roles;
            FilialComboBox.ItemsSource = filials;
        }


        private void EnterLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show(); this.Close();
        }

        private void EnterLabel_MouseEnter(object sender, MouseEventArgs e) => EnterLabel.FontWeight = FontWeights.Bold;

        private void EnterLabel_MouseLeave(object sender, MouseEventArgs e) => EnterLabel.FontWeight = FontWeights.Normal;

        private void RegistrButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "Error";
        }

        private void RegistrButton_MouseEnter(object sender, MouseEventArgs e)
        {
            RegistrButton.Foreground = Brushes.Black;
        }

        private void RegistrButton_MouseLeave(object sender, MouseEventArgs e)
        {
            RegistrButton.Foreground = Brushes.White;
        }
    }
}
