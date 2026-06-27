using PP11.Data;
using PP11.Enums;
using PP11.Models;
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
        private ContextDB db = new ContextDB();
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
            string error = "";
            if (FIOTextBox.Text == "") error += "Заполните поле \"ФИО\"\n";
            if (LoginTextBox.Text == "") error += "Заполните поле \"Логин\"\n";
            if (PasswordPasswordBox.Password == "") error += "Заполните поле \"Пароль\"\n";
            if (Password2PasswordBox.Password == "") error += "Повторите пароль\n";
            if (RolesComboBox.Text == "") error += "Выберите роль\n";
            if (FilialComboBox.Text == "") error += "Выберите филиал\n";
            if (EmailTextBox.Text == "") error += "Заполните поле \"Эл.Почта\"\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            try
            {
                var user = db.Users.FirstOrDefault(x => x.Login == LoginTextBox.Text);
                if (user != null)
                {
                    ErrorLabel.Content = "Пользователь с таким Логином уже существует"; return;
                }

                if (PasswordPasswordBox.Password != Password2PasswordBox.Password) {
                    ErrorLabel.Content = "Пароли не совпадают"; return;
                }

                User user1 = new User(FIOTextBox.Text, LoginTextBox.Text, PasswordPasswordBox.Password, RolesComboBox.Text, FilialComboBox.Text, EmailTextBox.Text, null, null);

                db.Users.Add(user1);
                db.SaveChanges();
                MessageBox.Show("Вы зарегистрировались!\nВойдите в аккаунт", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show(); this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
