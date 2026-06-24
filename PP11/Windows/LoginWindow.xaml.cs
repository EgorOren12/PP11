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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "Error";
        }

        private void Reg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show(); this.Close();
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e) => regLabel.FontWeight = FontWeights.Bold;

        private void regLabel_MouseLeave(object sender, MouseEventArgs e) => regLabel.FontWeight = FontWeights.Normal;

        private void Button_MouseEnter(object sender, MouseEventArgs e) => ENterButton.Foreground = Brushes.Black;

        private void ENterButton_MouseLeave(object sender, MouseEventArgs e) => ENterButton.Foreground = Brushes.White;
    }
}
