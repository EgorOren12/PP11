using IronWord;
using IronWord.Models;
using Microsoft.EntityFrameworkCore;
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
        private List<Models.Object> currentAbonentObjects = new List<Models.Object>();
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
            LoadAllData();
            
        }
        private void LoadAllData()
        {
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


            ZonesBrigadeComboBox.ItemsSource = Enum.GetValues(typeof(Zones));
            FilialBrigadeComboBox.ItemsSource = Enum.GetValues(typeof(Filials));

            RoleInBrigadeMembersOfBrigadeComboBox.ItemsSource = Enum.GetValues(typeof(Post));

            RoleUserComboBox.ItemsSource = Enum.GetValues( typeof(Roles));
            FIlialUserComboBox.ItemsSource = Enum.GetValues(typeof(Filials));

            DangerTypeOfSituationTextBox.ItemsSource = Enum.GetValues(typeof(Danger));

            SourceOfReguestReguestTextBox.ItemsSource = Enum.GetValues(typeof(SourceOfReguest));
            StatusReguestTextBox.ItemsSource = Enum.GetValues(typeof(RequestStatus));

            ResultOfAppoinmentReguestCloseTextBox.ItemsSource = Enum.GetValues(typeof(ResultOfAppoinment));

            StatusOfAppointmentAppoinmentTextBox.ItemsSource = Enum.GetValues(typeof(StatusOfAppoinment));
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
            string error = "";
            if (FIOAbonentTextBox.Text == "") error += "Заполните ФИО";
            if (BirthsdayAbonentDatePicker.Text == "") error += "Выберите дату рождения";
            if (LichesevoiSchetAbonentTextBox.Text == "") error += "Заполните лицевой счет";
            if (PassportSerAbonentTextBox.Text == "") error += "Заполните серию паспорта";
            if (PassportNumAbonentTextBox.Text == "") error += "Заполните номер паспорта";
            if (PassportNumAbonentTextBox.Text == "") error += "Заполните номер паспорта";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var abonent = new Abonent(FIOAbonentTextBox.Text, DateTime.Parse(BirthsdayAbonentDatePicker.Text), int.Parse(LichesevoiSchetAbonentTextBox.Text), int.Parse(PassportSerAbonentTextBox.Text), int.Parse(PassportNumAbonentTextBox.Text), DopInformationNumAbonentTextBox.Text);
                db.Abonents.Add(abonent);
                db.SaveChanges();
                LoadAllData();
                MessageBox.Show("Абонент успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка, проверьте корректность своих данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx"; 
            saveFileDialog.FileName = "МойДокумент.docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                var doc = new WordDocument();

                var textRun = new IronWord.Models.Run(new TextContent($"Id Пользователя:{user.Id}"));
                textRun.AddText($"Id Пользователя:{user.Id}\nФИО Пользователя: {user.FIO}");

                textRun.Style = new TextStyle()
                {
                    FontSize = 14, 
                    IsBold = false, 
                    Color = System.Drawing.Color.Black,
                    TextFont = new Font()
                    {
                        FontFamily = "Times New Roman" 
                    }
                };

                var paragraph = new Paragraph();
                paragraph.AddChild(textRun);

                doc.AddParagraph(paragraph);

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

        #region SelectidChanged
        private void Abonent_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Abonent_DataGrid.SelectedItem is Abonent selected)
            {
                FIOAbonentTextBox.Text = selected.FIO;
                BirthsdayAbonentDatePicker.SelectedDate = selected.Birthsday;
                LichesevoiSchetAbonentTextBox.Text = selected.LichesevoiSchet.ToString();
                PassportSerAbonentTextBox.Text = selected.PassportSer.ToString();
                PassportNumAbonentTextBox.Text = selected.PassportNum.ToString();
                DopInformationNumAbonentTextBox.Text = selected.DopInformation;
            }
        }


        private void Employee_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Employee_DataGrid.SelectedItem is Employee selected)
            {
                FIOEmployeeTextBox.Text = selected.FIO;
                PostEmployeeComboBox.SelectedItem = selected.Post;
                CvalificationEmployeeTextBox.Text = selected.Cvalification;
                TimeOfWorkEmployeeComboBox.SelectedItem = selected.TimeOfWork;
            }
        }


        private void Object_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Object_DataGrid.SelectedItem is Models.Object selected)
            {
                AdressObjectTextBox.Text = selected.Adress;
                ZonesObjectComboBox.SelectedItem = selected.Zones;
                ObjectsTypeObjectComboBox.SelectedItem = selected.ObjectsType;
                OborudovanieTypeObjectComboBox.SelectedItem = selected.OborudovanieType;
                YearExpluatationObjectTextBox.Text = selected.YearExpluatation.ToString();
                StatusOborudovaniyaObjectTextBox.SelectedItem = selected.StatusOborudovaniya;
                AbonentIDObjectTextBox.Text = selected.AbonentID.ToString();
            }
        }

        private void Brigade_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Brigade_DataGrid.SelectedItem is Brigade selected)
            {
                NameBrigadeTextBox.Text = selected.Name;
                ZonesBrigadeComboBox.SelectedItem = selected.Zones;
                TransportBrigadeTextBox.Text = selected.Transport;
                FilialBrigadeComboBox.SelectedItem = selected.Filials;
                EmployeeIDBrigadeTextBox.Text = selected.EmployeeID.ToString();
                IsBusyBrigadeCheckBox.IsChecked = selected.IsBusy;
            }
        }

        private void MembersOfBrigade_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MembersOfBrigade_DataGrid.SelectedItem is MembersOfBrigade selected)
            {
                RoleInBrigadeMembersOfBrigadeComboBox.SelectedItem = selected.RoleInBrigade;
                BrigadeIdMembersOfBrigadeTextBox.Text = selected.BrigadeId.ToString();
                EmployeeIdMembersOfBrigadeTextBox.Text = selected.EmployeeId.ToString();
            }
        }

        private void User_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (User_DataGrid.SelectedItem is User selected)
            {
                FIOUserTextBox.Text = selected.FIO;
                LoginUserTextBox.Text = selected.Login;
                PasswordUserTextBox.Text = selected.Password;
                RoleUserComboBox.SelectedItem = selected.Role;
                FIlialUserComboBox.SelectedItem = selected.Filial;
                EmailUserTextBox.Text = selected.Email;
                // LastEnter не редактируется
                ActivityUserCheckBox.IsChecked = selected.Activity;
            }
        }


        private void TypeOfSituation_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeOfSituation_DataGrid.SelectedItem is TypesOfSituation selected)
            {
                NameTypeOfSituationTextBox.Text = selected.Name;
                DescriptionTypeOfSituationTextBox.Text = selected.Description;
                DangerTypeOfSituationTextBox.SelectedItem = selected.Danger;
                ABSTimeTypeOfSituationTextBox.Text = selected.ABSTime.ToString();
            }
        }

        private void Reguest_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Reguest_DataGrid.SelectedItem is Request selected)
            {
                DateOfEnterReguestTextBox.SelectedDate = selected.DateOfEnter;
                DescriptionOfProblemReguestTextBox.Text = selected.DescriptionOfProblem;
                SourceOfReguestReguestTextBox.SelectedItem = selected.SourceOfReguest;
                StatusReguestTextBox.SelectedItem = selected.Status;
                AbonentIdReguestTextBox.Text = selected.AbonentId.ToString();
                ObjectIdReguestTextBox.Text = selected.ObjectId.ToString();
                TypeIdReguestTextBox.Text = selected.TypeId.ToString();
            }
        }

        private void ReguestClose_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReguestClose_DataGrid.SelectedItem is Request selected)
            {
                DateOfStartReguestCloseTextBox.SelectedDate = selected.DateOfStart;
                DateOfEndReguestCloseTextBox.SelectedDate = selected.DateOfEnd;
                DescriptionOfWorkReguestCloseTextBox.Text = selected.DescriptionOfWork;
                UsingMaterialsReguestCloseTextBox.Text = selected.UsingMaterials;
                DateOfClosingReguestCloseTextBox.SelectedDate = selected.DateOfClosing;
                ResultOfAppoinmentReguestCloseTextBox.SelectedItem = selected.ResultOfAppoinment;
                CommentOfCloseReguestCloseTextBox.Text = selected.CommentOfClose;
                InformingOfAbonentReguestCloseTextBox.IsChecked = selected.InformingOfAbonent;
            }
        }

        private void Appoinment_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Appoinment_DataGrid.SelectedItem is Appoinment selected)
            {
                NameAppoinmentTextBox.Text = selected.Name;
                DiscriptionAppoinmentComboBox.Text = selected.Discription;
                StatusOfAppointmentAppoinmentTextBox.SelectedItem = selected.StatusOfAppointment;
                RequestIdAppoinmentComboBox.Text = selected.RequestId.ToString();
                BrigadeIdAppoinmentTextBox.Text = selected.BrigadeId.ToString();
            }
        }
        #endregion

        private void ToDocumentButtonOformit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButtonOformit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ClearButtonOformit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void FIOOformitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fio = FIOOformitTextBox.Text.Trim();


            if (string.IsNullOrEmpty(fio))
            {
                AdresOformitComboBox.ItemsSource = null;
                AdresOformitComboBox.Text = "";
                ZoneOformietTextBox.Text = "";
                AdresOformitComboBox.IsEnabled = false;
                currentAbonentObjects.Clear();
                return;
            }

            // Ищем абонента по ФИО (точное совпадение)
            var abonent = db.Abonents
                .FirstOrDefault(a => a.FIO == fio);

            if (abonent == null)
            {
                // Абонент НЕ найден
                MessageBox.Show(
                    "Абонент с таким ФИО не найден в базе данных.\n" +
                    "Пожалуйста, зарегистрируйте его на вкладке 'Абоненты'.",
                    "Абонент не найден",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                AdresOformitComboBox.ItemsSource = null;
                AdresOformitComboBox.Text = "";
                ZoneOformietTextBox.Text = "";
                AdresOformitComboBox.IsEnabled = false;
                currentAbonentObjects.Clear();
                return;
            }
            var objects = db.Objects
    .Where(o => o.AbonentID == abonent.Id)
    .ToList();
            // Абонент найден — загружаем его объекты
            currentAbonentObjects = objects;

            if (currentAbonentObjects.Any())
            {
                // Заполняем ComboBox адресами
                AdresOformitComboBox.ItemsSource = currentAbonentObjects.Select(o => o.Adress).ToList();
                AdresOformitComboBox.IsEnabled = true;
                AdresOformitComboBox.Text = "";
                ZoneOformietTextBox.Text = "";
            }
            else
            {
                // У абонента нет объектов
                MessageBox.Show(
                    "У данного абонента нет зарегистрированных объектов.\n" +
                    "Добавьте объект на вкладке 'Объекты'.",
                    "Нет объектов",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                AdresOformitComboBox.ItemsSource = null;
                AdresOformitComboBox.IsEnabled = false;
                ZoneOformietTextBox.Text = "";
            }
        }

        private void AdresOformitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedAdress = AdresOformitComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedAdress))
            {
                ZoneOformietTextBox.Text = "";
                return;
            }

            // Ищем объект по адресу
            var selectedObject = currentAbonentObjects
                .FirstOrDefault(o => o.Adress == selectedAdress);

            if (selectedObject != null)
            {
                // Подставляем район
                ZoneOformietTextBox.Text = selectedObject.Zones.ToString();
            }
            else
            {
                ZoneOformietTextBox.Text = "";
            }
        }

    }
}