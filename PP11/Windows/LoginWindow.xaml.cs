using Microsoft.EntityFrameworkCore;
using PP11.Data;
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
        private ContextDB db;
        public LoginWindow()
        {
            InitializeComponent();
            db = new ContextDB();
            db.Database.EnsureCreated();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Enter();
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


        private void Enter()
        {
            var EnterUser = db.Users.FirstOrDefault(x => x.Login == LoginTextBox.Text);

            if (EnterUser == null)
            {
                ErrorLabel.Content = "Пользователь не существует";
                return;
            }

            if (EnterUser.Password == PasswordPasswordBox.Password)
            {
                EnterUser.LastEnter = DateTime.Now;
                db.SaveChanges();
                MainWindow mainWindow = new MainWindow(EnterUser.Role);
                mainWindow.Show(); this.Close();
            }
            else
            {
                ErrorLabel.Content = "Неверный пароль";
                return;
            }
        }

    }
}
