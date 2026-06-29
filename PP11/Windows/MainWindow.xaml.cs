using IronWord;
using IronWord.Models;
using Microsoft.Win32;
using PP11.Data;
using PP11.Enums;
using PP11.Models;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paragraph = IronWord.Models.Paragraph;

namespace PP11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContextDB db;
        private List<string> WorkTime = new List<string> { "5/2 8.00 - 17.00",
            "2/2 8.00 - 20.00",
            "4/4 8.00 - 18.00",
            "5/2 17.00 - 8.00",
            "2/2 20.00 - 8.00",
            "4/4 18.00 - 8.00"
        };
        public MainWindow()
        {
            InitializeComponent();
            db = new ContextDB();
            LoadDataGridsData();
            LoadData();
            
        }

        private void LoadData()
        {
            PostEmployeeComboBox.ItemsSource = Enum.GetValues(typeof(Post));
            TimeOfWorkEmployeeComboBox.ItemsSource = WorkTime;

            OborudovanieTypeObjectComboBox.ItemsSource = Enum.GetValues(typeof(OborudovanieType));
            ObjectsTypeObjectComboBox.ItemsSource = Enum.GetValues(typeof(ObjectsType));
            ZonesObjectComboBox.ItemsSource = Enum.GetValues(typeof(Zones));
            StatusOborudovaniyaObjectTextBox.ItemsSource = Enum.GetValues(typeof(StatusOborudovaniya));
        }
        private void LoadDataGridsData()
        {
            Abonent_DataGrid.ItemsSource = db.Abonents.ToList();
            Appoinment_DataGrid.ItemsSource = db.Appoinments.ToList();
            Brigade_DataGrid.ItemsSource = db.Brigades.ToList();
            Employee_DataGrid.ItemsSource = db.Employees.ToList();
            MembersOfBrigade_DataGrid.ItemsSource = db.MembersOfBrigades.ToList();
            Object_DataGrid.ItemsSource = db.Objects.ToList();
            Reguest_DataGrid.ItemsSource = db.Requests.ToList();
            ReguestClose_DataGrid.ItemsSource = db.Requests.ToList();
            FullReguest_DataGrid.ItemsSource = db.Requests.ToList();
            TypeOfSituation_DataGrid.ItemsSource = db.TypesOfSituation.ToList();
            User_DataGrid.ItemsSource = db.Users.ToList();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (TabItem item in ((TabControl)sender).Items)
            {
                if (item.IsSelected)
                {
                    item.Foreground = new SolidColorBrush(Colors.Black);
                    item.FontWeight = FontWeights.Bold;
                }
                else
                {
                    item.Foreground = new SolidColorBrush(Colors.White);
                    item.FontWeight = FontWeights.Normal;
                }
            }
        }



        private void RefreshButton1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #region Abonent
        private void DeleteButtonAbonent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonAbonent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonAbonent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        #endregion
        #region Employee
        private void AddButtonEmployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonEmployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteButtonEmployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region Object
        private void DeleteButtonObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region Brigade
        private void DeleteButtonBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region MembersOfBrigade
        private void AddButtonMembersOfBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonMembersOfBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteButtonMembersOfBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region users
        private void DeleteButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeletePasswordButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region TypeOfSituation
        private void DeleteButtonTypeOfSituation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonTypeOfSituation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonTypeOfSituation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region RequestCreate
        private void AddButtonReguestCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonReguestCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteButtonReguestCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region RequestClose
        private void DeleteButtonReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region requestFull
        private void DeleteButtonFullReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DocButtonFullReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            User user = (User)User_DataGrid.SelectedItem;

            // 1. Показываем диалог сохранения файла
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx"; 
            saveFileDialog.FileName = "МойДокумент.docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                // 2. Создаем новый документ
                var doc = new WordDocument();

                // 3. Создаем текст с форматированием
                // В IronWord стиль применяется к объекту Run
                var textRun = new IronWord.Models.Run(new TextContent($"Id Пользователя:{user.Id}"));
                textRun.AddText($"Id Пользователя:{user.Id}\nФИО Пользователя: {user.FIO}");

                // Настраиваем стиль шрифта
                textRun.Style = new TextStyle()
                {
                    FontSize = 14, // Размер шрифта в пунктах [citation:6]
                    IsBold = false, // Жирный шрифт [citation:6]
                    Color = System.Drawing.Color.Black, // Цвет текста [citation:6]
                    TextFont = new Font()
                    {
                        FontFamily = "Times New Roman" // Название шрифта [citation:6]
                    }
                };

                // 4. Создаем абзац и добавляем в него наш текст
                var paragraph = new Paragraph();
                paragraph.AddChild(textRun);

                // 5. Добавляем абзац в документ
                doc.AddParagraph(paragraph);

                // 6. Сохраняем документ по пути, который выбрал пользователь
                doc.SaveAs(saveFileDialog.FileName);

                MessageBox.Show("Документ Word успешно создан!", "Успех");
            }



            
        }
        #endregion
        #region Appoinment
        private void AddButtonAppoinment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateButtonAppoinment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteButtonAppoinment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
    }
}