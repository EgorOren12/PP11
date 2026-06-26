using PP11.Enums;
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
        public RegistrationWindow()
        {
            InitializeComponent();
            RolesComboBox.ItemsSource = Enum.GetValues(typeof(Roles));
            FilialComboBox.ItemsSource = Enum.GetValues(typeof(Filials));
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
