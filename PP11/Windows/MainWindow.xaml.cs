using Azure.Identity;
using IronWord;
using IronWord.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PP11.Data;
using PP11.Enums;
using PP11.Models;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = IronWord.Models.Color;
using Paragraph = IronWord.Models.Paragraph;

namespace PP11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> DangerList = new List<string>
    {
        "Высокий",
        "Средний",
        "Низкий"
    };
        private List<string> FilialsList = new List<string>
    {
        "Оренбург",
        "Бузулук",
        "Орск",
        "Новотроицк",
        "Медногорск",
        "Кувандык",
        "Сорочинск",
        "Гай",
        "Абдулино",
        "Бугуруслан"
    };
        private List<string> ObjectsTypeList = new List<string>
    {
        "Жилой_Дом",
        "Квартира",
        "Частный_Дом",
        "Социальный_Объект"
    };
        private List<string> OborudovanieTypeList = new List<string>
    {
        "Газовый_Котел",
        "Газовая_Плита",
        "Водонагреватель",
        "Счетчик"
    };
        private List<string> PostList = new List<string>
    {
        "Слесарь",
        "Мастер",
        "Диспетчер",
        "Инженер",
        "Начальник_Участка"
    };
        private List<string> RequestStatusList = new List<string>
    {
        "Новая",
        "В_Работе",
        "Выполнена",
        "Закрыта"
    };
        private List<string> ResultOfAppointmentList = new List<string>
    {
        "Устранено",
        "Требуется_Замена",
        "Требуется_Повторная_Проверка"
    };
        private List<string> RolesList = new List<string>
    {
        "Администратор",
        "Диспетчер",
        "Руководитель"
    };
        private List<string> SourceOfRequestList = new List<string>
    {
        "Телефон_04",
        "Телефон_104",
        "Личный_Прием"
    };
        private List<string> StatusOborudovaniyaList = new List<string>
    {
        "Исправно",
        "Требуется_Ремонт",
        "Аварийное"
    };
        private List<string> StatusOfAppointmentList = new List<string>
    {
        "Назначено",
        "В_Пути",
        "Прибыли",
        "Выполняется"
    };
        private List<string> ZonesList = new List<string>
    {
        "Центральный",
        "Дзержинский",
        "Промышленный",
        "Ленинский",
        "Октябрьский",
        "Северный",
        "Южный",
        "Западный",
        "Восточный",
        "Степной"
    };

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
            PostEmployeeComboBox.ItemsSource = PostList;
            TimeOfWorkEmployeeComboBox.ItemsSource = WorkTime;

            OborudovanieTypeObjectComboBox.ItemsSource = OborudovanieTypeList;
            ObjectsTypeObjectComboBox.ItemsSource = ObjectsTypeList;
            ZonesObjectComboBox.ItemsSource = ZonesList;
            StatusOborudovaniyaObjectTextBox.ItemsSource = StatusOborudovaniyaList;


            ZonesBrigadeComboBox.ItemsSource = ZonesList;
            FilialBrigadeComboBox.ItemsSource = FilialsList;

            RoleInBrigadeMembersOfBrigadeComboBox.ItemsSource = PostList;

            RoleUserComboBox.ItemsSource = RolesList;
            FIlialUserComboBox.ItemsSource = FilialsList;

            DangerTypeOfSituationTextBox.ItemsSource = DangerList;

            SourceOfReguestReguestTextBox.ItemsSource = SourceOfRequestList;
            StatusReguestTextBox.ItemsSource = RequestStatusList;

            ResultOfAppoinmentReguestCloseTextBox.ItemsSource = ResultOfAppointmentList;

            StatusOfAppointmentAppoinmentTextBox.ItemsSource = StatusOfAppointmentList;

            TypeOfSituationOformitTextBox.ItemsSource = (from t in db.TypesOfSituation select t.Name).ToList();
            StatusOborudovaniyaOformitTextBox.ItemsSource = StatusOborudovaniyaList;
            FIOOformitTextBox.ItemsSource = (from t in db.Abonents select t.FIO).ToList();

            #region Foreginkey
            AbonentIDObjectTextBox.ItemsSource = (from t in db.Abonents select t.Id).ToList();

            EmployeeIDBrigadeTextBox.ItemsSource = (from t in db.Employees select t.Id).ToList();

            BrigadeIdMembersOfBrigadeTextBox.ItemsSource = (from t in db.Brigades select t.Id).ToList();

            EmployeeIdMembersOfBrigadeTextBox.ItemsSource =
    (from e in db.Employees
     where !db.MembersOfBrigades.Any(m => m.EmployeeId == e.Id) 
     select e.Id)
     .ToList();

            AbonentIdReguestTextBox.ItemsSource = (from t in db.Abonents select t.Id).ToList();

            ObjectIdReguestTextBox.ItemsSource = (from t in db.Objects select t.Id).ToList();

            TypeIdReguestTextBox.ItemsSource = (from t in db.TypesOfSituation select t.ID).ToList();

            RequestIdAppoinmentComboBox.ItemsSource = (from t in db.Requests select t.Id).ToList();

            BrigadeIdAppoinmentTextBox.ItemsSource = (from t in db.Brigades where t.IsBusy==false select t.Id).ToList();
            #endregion
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

        private void ResetContext()
        {
            db.ChangeTracker.Clear();
            LoadAllData();
        }


        private void RefreshButton1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            db.ChangeTracker.Clear();
            LoadAllData();
        }
        #region Abonent
        private void DeleteButtonAbonent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Abonent_DataGrid.SelectedItem is not Abonent selected)
            {
                MessageBox.Show("Выберите абонента для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить абонента '{selected.FIO}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Abonents.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearAbonent();
                    MessageBox.Show("Абонент удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ResetContext();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void UpdateButtonAbonent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Abonent_DataGrid.SelectedItem is not Abonent selected)
            {
                MessageBox.Show("Выберите абонента для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (FIOAbonentTextBox.Text == "") error += "Заполните ФИО\n";
            if (BirthsdayAbonentDatePicker.Text == "") error += "Выберите дату рождения\n";
            if (LichesevoiSchetAbonentTextBox.Text == "") error += "Заполните лицевой счет\n";
            if (PassportSerAbonentTextBox.Text == "") error += "Заполните серию паспорта\n";
            if (PassportNumAbonentTextBox.Text == "") error += "Заполните номер паспорта\n";
            if (PassportSerAbonentTextBox.Text.Length != 4) error += "Серия паспорта должна содержать 4 цифры\n";
            if (PassportNumAbonentTextBox.Text.Length != 6) error += "Номер паспорта должн содержать 6 цифр\n";

            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.FIO = FIOAbonentTextBox.Text;
                selected.Birthsday = Convert.ToDateTime(BirthsdayAbonentDatePicker.Text);
                selected.LichesevoiSchet = Convert.ToInt32(LichesevoiSchetAbonentTextBox.Text);
                selected.PassportSer = Convert.ToInt32(PassportSerAbonentTextBox.Text);
                selected.PassportNum = Convert.ToInt32(PassportNumAbonentTextBox.Text);
                selected.DopInformation = DopInformationNumAbonentTextBox.Text;

                db.SaveChanges();
                LoadAllData();
                ClearAbonent();

                MessageBox.Show("Абонент Изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void AddButtonAbonent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (FIOAbonentTextBox.Text == "") error += "Заполните ФИО\n";
            if (BirthsdayAbonentDatePicker.Text == "") error += "Выберите дату рождения\n";
            if (LichesevoiSchetAbonentTextBox.Text == "") error += "Заполните лицевой счет\n";
            if (PassportSerAbonentTextBox.Text == "") error += "Заполните серию паспорта\n";
            if (PassportNumAbonentTextBox.Text == "") error += "Заполните номер паспорта\n";
            if (PassportSerAbonentTextBox.Text.Length != 4) error += "Серия паспорта должна содержать 4 цифры\n";
            if (PassportNumAbonentTextBox.Text.Length != 6) error += "Номер паспорта должн содержать 6 цифр\n";
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
                ClearAbonent();
                MessageBox.Show("Абонент успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность своих данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
        #region Employee
        private void AddButtonEmployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (FIOEmployeeTextBox.Text == "") error += "Заполните ФИО\n";
            if (PostEmployeeComboBox.Text == "") error += "Выберите пост\n";
            if (CvalificationEmployeeTextBox.Text == "") error += "Заполните квалификацию\n";
            if (TimeOfWorkEmployeeComboBox.Text == "") error += "Выберите время работы\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var employee = new Employee(FIOEmployeeTextBox.Text, PostEmployeeComboBox.Text, CvalificationEmployeeTextBox.Text, TimeOfWorkEmployeeComboBox.Text);
                db.Employees.Add(employee);
                db.SaveChanges();
                LoadAllData();
                ClearEmployee();
                MessageBox.Show("Сотрудник успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButtonEmployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Employee_DataGrid.SelectedItem is not Employee selected)
            {
                MessageBox.Show("Выберите абонента для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (FIOEmployeeTextBox.Text == "") error += "Заполните ФИО\n";
            if (PostEmployeeComboBox.Text == "") error += "Выберите пост\n";
            if (CvalificationEmployeeTextBox.Text == "") error += "Заполните квалификацию\n";
            if (TimeOfWorkEmployeeComboBox.Text == "") error += "Выберите время работы\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.FIO = FIOEmployeeTextBox.Text;
                selected.Post = PostEmployeeComboBox.Text;
                selected.Cvalification = CvalificationEmployeeTextBox.Text;
                selected.TimeOfWork = TimeOfWorkEmployeeComboBox.Text;

                db.SaveChanges();
                LoadAllData();
                ClearEmployee();

                MessageBox.Show("Сотрудник Изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButtonEmployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Employee_DataGrid.SelectedItem is not Employee selected)
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить сотрудника '{selected.FIO}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Employees.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearEmployee();
                    MessageBox.Show("Сотрудник удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ResetContext();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion
        #region Object
        private void DeleteButtonObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Object_DataGrid.SelectedItem is not Models.Object selected)
            {
                MessageBox.Show("Выберите объект для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить объект '{selected.Id}, {selected.Adress}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Objects.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearObject();
                    MessageBox.Show("Объект удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ResetContext();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateButtonObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Object_DataGrid.SelectedItem is not Models.Object selected)
            {
                MessageBox.Show("Выберите объект для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (AdressObjectTextBox.Text == "") error += "Заполните Адрес\n";
            if (ZonesObjectComboBox.Text == "") error += "Выберите район\n";
            if (ObjectsTypeObjectComboBox.Text == "") error += "Выберите тип оборудования\n";
            if (OborudovanieTypeObjectComboBox.Text == "") error += "Выберите тип объекта\n";
            if (YearExpluatationObjectTextBox.Text == "") error += "Заполните год ввода в эксплуатацию\n";
            if (YearExpluatationObjectTextBox.Text.Length != 4) error += "Год содержит 4 цифры\n";
            if (StatusOborudovaniyaObjectTextBox.Text == "") error += "Выберите статус оборудования\n";
            if (AbonentIDObjectTextBox.Text == "") error += "Заполните ID Абонента\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.Adress = AdressObjectTextBox.Text;
                selected.Zones = ZonesObjectComboBox.Text;
                selected.ObjectsType = ObjectsTypeObjectComboBox.Text;
                selected.OborudovanieType = OborudovanieTypeObjectComboBox.Text;
                selected.YearExpluatation = Convert.ToInt32(YearExpluatationObjectTextBox.Text);
                selected.StatusOborudovaniya = StatusOborudovaniyaObjectTextBox.Text;
                selected.AbonentID = Convert.ToInt32(AbonentIDObjectTextBox.Text);

                db.SaveChanges();
                LoadAllData();
                ClearObject();

                MessageBox.Show("Объект Изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButtonObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (AdressObjectTextBox.Text == "") error += "Заполните Адрес\n";
            if (ZonesObjectComboBox.Text == "") error += "Выберите район\n";
            if (ObjectsTypeObjectComboBox.Text == "") error += "Выберите тип оборудования\n";
            if (OborudovanieTypeObjectComboBox.Text == "") error += "Выберите тип объекта\n";
            if (YearExpluatationObjectTextBox.Text == "") error += "Заполните год ввода в эксплуатацию\n";
            if (YearExpluatationObjectTextBox.Text.Length != 4) error += "Год содержит 4 цифры\n";
            if (StatusOborudovaniyaObjectTextBox.Text == "") error += "Выберите статус оборудования\n";
            if (AbonentIDObjectTextBox.Text == "") error += "Заполните ID Абонента\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var objectt = new Models.Object(AdressObjectTextBox.Text, ZonesObjectComboBox.Text, ObjectsTypeObjectComboBox.Text, OborudovanieTypeObjectComboBox.Text,
                    Convert.ToInt32(YearExpluatationObjectTextBox.Text), StatusOborudovaniyaObjectTextBox.Text, Convert.ToInt32(AbonentIDObjectTextBox.Text));
                db.Objects.Add(objectt);
                db.SaveChanges();
                LoadAllData();
                ClearObject();
                MessageBox.Show("Объект успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Brigade
        private void DeleteButtonBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Brigade_DataGrid.SelectedItem is not Brigade selected)
            {
                MessageBox.Show("Выберите бригаду для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить бригаду '{selected.Name}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Brigades.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearBrigade();
                    MessageBox.Show("Бригада удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    db.ChangeTracker.Clear();
                    LoadAllData();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateButtonBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Brigade_DataGrid.SelectedItem is not Brigade selected)
            {
                MessageBox.Show("Выберите бригаду для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (NameBrigadeTextBox.Text == "") error += "Заполните наименование\n";
            if (ZonesBrigadeComboBox.Text == "") error += "Выберите район\n";
            if (TransportBrigadeTextBox.Text == "") error += "Заполните транспорт\n";
            if (FilialBrigadeComboBox.Text == "") error += "Выберите филиал\n";
            if (EmployeeIDBrigadeTextBox.Text == "") error += "Заполните Id старшего в бригаде\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.Name = NameBrigadeTextBox.Text;
                selected.Zones = ZonesBrigadeComboBox.Text;
                selected.Transport = TransportBrigadeTextBox.Text;
                selected.Filials = FilialBrigadeComboBox.Text;
                selected.EmployeeID = Convert.ToInt32(EmployeeIDBrigadeTextBox.Text);
                selected.IsBusy = IsBusyBrigadeCheckBox.IsChecked.Value;

                db.SaveChanges();
                LoadAllData();
                ClearBrigade();

                MessageBox.Show("Бригада Изменена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                db.ChangeTracker.Clear();
                LoadAllData();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButtonBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (NameBrigadeTextBox.Text == "") error += "Заполните наименование\n";
            if (ZonesBrigadeComboBox.Text == "") error += "Выберите район\n";
            if (TransportBrigadeTextBox.Text == "") error += "Заполните транспорт\n";
            if (FilialBrigadeComboBox.Text == "") error += "Выберите филиал\n";
            if (EmployeeIDBrigadeTextBox.Text == "") error += "Заполните Id старшего в бригаде\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var brigade = new Brigade(NameBrigadeTextBox.Text, ZonesBrigadeComboBox.Text, TransportBrigadeTextBox.Text, FilialBrigadeComboBox.Text, Convert.ToInt32(EmployeeIDBrigadeTextBox.Text), IsBusyBrigadeCheckBox.IsChecked.Value);
                db.Brigades.Add(brigade);
                db.SaveChanges();
                LoadAllData();
                ClearBrigade();
                MessageBox.Show("Бригада успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                db.ChangeTracker.Clear();
                LoadAllData();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region MembersOfBrigade
        private void AddButtonMembersOfBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (RoleInBrigadeMembersOfBrigadeComboBox.Text == "") error += "Быберите роль в бригаде\n";
            if (BrigadeIdMembersOfBrigadeTextBox.Text == "") error += "Заполните Id Бригады\n";
            if (EmployeeIdMembersOfBrigadeTextBox.Text == "") error += "Заполните Id Сотрудника\n";

            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var chelen = new MembersOfBrigade(RoleInBrigadeMembersOfBrigadeComboBox.Text, Convert.ToInt32(EmployeeIdMembersOfBrigadeTextBox.Text), Convert.ToInt32(BrigadeIdMembersOfBrigadeTextBox.Text));
                db.MembersOfBrigades.Add(chelen);
                db.SaveChanges();
                LoadAllData();
                ClearMembers();
                MessageBox.Show("Член бригады успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButtonMembersOfBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MembersOfBrigade_DataGrid.SelectedItem is not MembersOfBrigade selected)
            {
                MessageBox.Show("Выберите Члена бригады для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (RoleInBrigadeMembersOfBrigadeComboBox.Text == "") error += "Быберите роль в бригаде\n";
            if (BrigadeIdMembersOfBrigadeTextBox.Text == "") error += "Заполните Id Бригады\n";
            if (EmployeeIdMembersOfBrigadeTextBox.Text == "") error += "Заполните Id Сотрудника\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.RoleInBrigade = RoleInBrigadeMembersOfBrigadeComboBox.Text;
                selected.BrigadeId = Convert.ToInt32(BrigadeIdMembersOfBrigadeTextBox.Text);
                selected.EmployeeId = Convert.ToInt32(EmployeeIdMembersOfBrigadeTextBox.Text);

                db.SaveChanges();
                LoadAllData();
                ClearMembers(); ;

                MessageBox.Show("Член бригады Изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            { MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void DeleteButtonMembersOfBrigade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MembersOfBrigade_DataGrid.SelectedItem is not MembersOfBrigade selected)
            {
                MessageBox.Show("Выберите Члена бригады для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить Члена бригады '{selected.Id}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.MembersOfBrigades.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearMembers();
                    MessageBox.Show("Член бригады удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
        #endregion
        #region users
        private void DeleteButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (User_DataGrid.SelectedItem is not User selected)
            {
                MessageBox.Show("Выберите Пользователя для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить Пользователя '{selected.FIO}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Users.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearUsers();
                    MessageBox.Show("Пользователь удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ResetContext();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (User_DataGrid.SelectedItem is not User selected)
            {
                MessageBox.Show("Выберите Пользователя для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (FIOUserTextBox.Text == "") error += "Заполните ФИО\n";
            if (LoginUserTextBox.Text == "") error += "Заполните Логин\n";
            if (PasswordUserTextBox.Text == "") error += "Заполните поле Пароль\n";
            if (RoleUserComboBox.Text == "") error += "Выберите роль\n";
            if (FIlialUserComboBox.Text == "") error += "Выберите филиал\n";
            if (EmailUserTextBox.Text == "") error += "Заполните поле Эл.Почта\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.FIO = FIOUserTextBox.Text;
                selected.Login = LoginUserTextBox.Text;
                selected.Password = PasswordUserTextBox.Text;
                selected.Role = RoleUserComboBox.Text;
                selected.Filial = FIlialUserComboBox.Text;
                selected.Email = EmailUserTextBox.Text;
                selected.Activity = ActivityUserCheckBox.IsChecked;

                db.SaveChanges();
                LoadAllData();
                ClearUsers(); ;

                MessageBox.Show("Пользователь Изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (FIOUserTextBox.Text == "") error += "Заполните ФИО\n";
            if (LoginUserTextBox.Text == "") error += "Заполните Логин\n";
            if (PasswordUserTextBox.Text == "") error += "Заполните поле Пароль\n";
            if (RoleUserComboBox.Text == "") error += "Выберите роль\n";
            if (FIlialUserComboBox.Text == "") error += "Выберите филиал\n";
            if (EmailUserTextBox.Text == "") error += "Заполните поле Эл.Почта\n";

            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var user = new User(FIOUserTextBox.Text, LoginUserTextBox.Text, PasswordUserTextBox.Text, RoleUserComboBox.Text, FIlialUserComboBox.Text, EmailUserTextBox.Text, null, true);
                db.Users.Add(user);
                db.SaveChanges();
                LoadAllData();
                ClearUsers();
                MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePasswordButtonUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (User_DataGrid.SelectedItem is not User selected)
            {
                MessageBox.Show("Выберите Пользователя для сбороса пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                selected.Password = "";


                db.SaveChanges();
                LoadAllData();
                ClearUsers(); ;

                MessageBox.Show($"Пароль пользователя {selected.FIO}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        #endregion
        #region TypeOfSituation
        private void DeleteButtonTypeOfSituation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TypeOfSituation_DataGrid.SelectedItem is not TypesOfSituation selected)
            {
                MessageBox.Show("Выберите Тип ситуации для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить Тип ситуации '{selected.Name}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.TypesOfSituation.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearType();
                    MessageBox.Show("Тип ситуации удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ResetContext();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateButtonTypeOfSituation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TypeOfSituation_DataGrid.SelectedItem is not TypesOfSituation selected)
            {
                MessageBox.Show("Выберите Тип ситуации для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (NameTypeOfSituationTextBox.Text == "") error += "Заполните Наименование\n";
            if (DangerTypeOfSituationTextBox.Text == "") error += "Выберите категорию опасности\n";
            if (ABSTimeTypeOfSituationTextBox.Text == "") error += "Заполните среднее время устранения\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.Name = NameTypeOfSituationTextBox.Text;
                selected.Danger = DangerTypeOfSituationTextBox.Text;
                selected.ABSTime = (Convert.ToDateTime(ABSTimeTypeOfSituationTextBox.Text).TimeOfDay);
                selected.Description = DescriptionTypeOfSituationTextBox.Text;

                db.SaveChanges();
                LoadAllData();
                ClearType();

                MessageBox.Show("Тип ситуации Изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButtonTypeOfSituation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (NameTypeOfSituationTextBox.Text == "") error += "Заполните Наименование\n";
            if (DangerTypeOfSituationTextBox.Text == "") error += "Выберите категорию опасности\n";
            if (ABSTimeTypeOfSituationTextBox.Text == "") error += "Заполните среднее время устранения\n";

            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var type = new TypesOfSituation(NameTypeOfSituationTextBox.Text, DescriptionTypeOfSituationTextBox.Text, DangerTypeOfSituationTextBox.Text, Convert.ToDateTime(ABSTimeTypeOfSituationTextBox.Text).TimeOfDay);
                db.TypesOfSituation.Add(type);
                db.SaveChanges();
                LoadAllData();
                ClearType();
                MessageBox.Show("Тип ситуации добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region RequestCreate
        private void AddButtonReguestCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (DateOfEnterReguestTextBox.Text == "") error += "Заполните Дату поступления\n";
            if (DescriptionOfProblemReguestTextBox.Text == "") error += "Заполните описание проблемы\n";
            if (SourceOfReguestReguestTextBox.Text == "") error += "Выберите источник заявки\n";
            if (StatusReguestTextBox.Text == "") error += "Выбирете статус заявки\n";
            if (AbonentIdReguestTextBox.Text == "") error += "Заполните Id Абонента\n";
            if (ObjectIdReguestTextBox.Text == "") error += "Заполните Id Объекта\n";
            if (TypeIdReguestTextBox.Text == "") error += "Заполните Id Типа\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var request = new Request(Convert.ToDateTime(DateOfEnterReguestTextBox.Text), DescriptionOfProblemReguestTextBox.Text, SourceOfReguestReguestTextBox.Text, StatusReguestTextBox.Text, null, null, null, null, null, null, null, false, Convert.ToInt32(AbonentIdReguestTextBox.Text), Convert.ToInt32(ObjectIdReguestTextBox.Text), Convert.ToInt32(TypeIdReguestTextBox.Text));
                db.Requests.Add(request);
                db.SaveChanges();
                LoadAllData();
                ClearRequestCreate();
                MessageBox.Show("Заявка добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButtonReguestCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Reguest_DataGrid.SelectedItem is not Request selected)
            {
                MessageBox.Show("Выберите Заявку для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (DateOfEnterReguestTextBox.Text == "") error += "Заполните Дату поступления\n";
            if (DescriptionOfProblemReguestTextBox.Text == "") error += "Заполните описание проблемы\n";
            if (SourceOfReguestReguestTextBox.Text == "") error += "Выберите источник заявки\n";
            if (StatusReguestTextBox.Text == "") error += "Выбирете статус заявки\n";
            if (AbonentIdReguestTextBox.Text == "") error += "Заполните Id Абонента\n";
            if (ObjectIdReguestTextBox.Text == "") error += "Заполните Id Объекта\n";
            if (TypeIdReguestTextBox.Text == "") error += "Заполните Id Типа\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.DateOfEnter = Convert.ToDateTime(DateOfEnterReguestTextBox.Text);
                selected.DescriptionOfProblem = DescriptionOfProblemReguestTextBox.Text;
                selected.SourceOfReguest = SourceOfReguestReguestTextBox.Text;
                selected.Status = StatusReguestTextBox.Text;
                selected.AbonentId = Convert.ToInt32(AbonentIdReguestTextBox.Text);
                selected.ObjectId = Convert.ToInt32(ObjectIdReguestTextBox.Text);
                selected.TypeId = Convert.ToInt32(TypeIdReguestTextBox.Text);

                db.SaveChanges();
                LoadAllData();
                ClearRequestCreate();

                MessageBox.Show("Заявка Изменена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
        #region RequestClose

        private void UpdateButtonReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ReguestClose_DataGrid.SelectedItem is not Request selected)
            {
                MessageBox.Show("Выберите Заявку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (DateOfStartReguestCloseTextBox.Text == "") error += "Заполните Дату начала устранения\n";
            if (DateOfEndReguestCloseTextBox.Text == "") error += "Заполните Дату окончания устранения\n";
            if (DescriptionOfWorkReguestCloseTextBox.Text == "") error += "Заполните описание работы\n";
            if (UsingMaterialsReguestCloseTextBox.Text == "") error += "Заполните используемые материалы\n";
            if (DateOfClosingReguestCloseTextBox.Text == "") error += "Заполните Дату закрытия заявки\n";
            if (ResultOfAppoinmentReguestCloseTextBox.Text == "") error += "Заполните результат выполнения\n";
            if (CommentOfCloseReguestCloseTextBox.Text == "") error += "Заполните комментарий закрытия\n";
            if (error != "")
            {
                ResetContext();
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.DateOfStart = Convert.ToDateTime(DateOfStartReguestCloseTextBox.Text);
                selected.DateOfEnd = Convert.ToDateTime(DateOfEndReguestCloseTextBox.Text);
                selected.DescriptionOfWork = DescriptionOfWorkReguestCloseTextBox.Text;
                selected.UsingMaterials = UsingMaterialsReguestCloseTextBox.Text;
                selected.DateOfClosing = Convert.ToDateTime(DateOfClosingReguestCloseTextBox.Text);
                selected.ResultOfAppoinment = ResultOfAppoinmentReguestCloseTextBox.Text;
                selected.CommentOfClose = CommentOfCloseReguestCloseTextBox.Text;
                selected.InformingOfAbonent = InformingOfAbonentReguestCloseTextBox.IsChecked.Value;

                db.SaveChanges();
                LoadAllData();
                ClearRequestClose();

                MessageBox.Show("Заявка Изменена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            { MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void AddButtonReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ReguestClose_DataGrid.SelectedItem is not Request selected)
            {
                MessageBox.Show("Выберите Заявку для закрытия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (DateOfStartReguestCloseTextBox.Text == "") error += "Заполните Дату начала устранения\n";
            if (DateOfEndReguestCloseTextBox.Text == "") error += "Заполните Дату окончания устранения\n";
            if (DescriptionOfWorkReguestCloseTextBox.Text == "") error += "Заполните описание работы\n";
            if (UsingMaterialsReguestCloseTextBox.Text == "") error += "Заполните используемые материалы\n";
            if (DateOfClosingReguestCloseTextBox.Text == "") error += "Заполните Дату закрытия заявки\n";
            if (ResultOfAppoinmentReguestCloseTextBox.Text == "") error += "Заполните результат выполнения\n";
            if (CommentOfCloseReguestCloseTextBox.Text == "") error += "Заполните комментарий закрытия\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                selected.DateOfStart = Convert.ToDateTime(DateOfStartReguestCloseTextBox.Text);
                selected.DateOfEnd = Convert.ToDateTime(DateOfEndReguestCloseTextBox.Text);
                selected.DescriptionOfWork = DescriptionOfWorkReguestCloseTextBox.Text;
                selected.UsingMaterials = UsingMaterialsReguestCloseTextBox.Text;
                selected.DateOfClosing = Convert.ToDateTime(DateOfClosingReguestCloseTextBox.Text);
                selected.ResultOfAppoinment = ResultOfAppoinmentReguestCloseTextBox.Text;
                selected.CommentOfClose = CommentOfCloseReguestCloseTextBox.Text;
                selected.InformingOfAbonent = InformingOfAbonentReguestCloseTextBox.IsChecked.Value;

                db.SaveChanges();
                LoadAllData();
                ClearRequestClose();

                MessageBox.Show("Заявка закрыта", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region requestFull
        private void DeleteButtonFullReguestCloseCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ReguestClose_DataGrid.SelectedItem is not Request selected)
            {
                MessageBox.Show("Выберите Заявку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = MessageBox.Show($"Удалить заявку '{selected.Id}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Requests.Remove(selected);
                    db.SaveChanges();

                    LoadAllData();
                    ClearBrigade();
                    MessageBox.Show("заявка удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    db.ChangeTracker.Clear();
                    LoadAllData();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
            string error = "";
            if (NameAppoinmentTextBox.Text == "") error += "Заполните Наименование\n";
            if (StatusOfAppointmentAppoinmentTextBox.Text == "") error += "Выберите статус назначения\n";
            if (RequestIdAppoinmentComboBox.Text == "") error += "Заполните Id заявки\n";
            if (BrigadeIdAppoinmentTextBox.Text == "") error += "Заполните Id бригады\n";

            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var bri = db.Brigades.FirstOrDefault(b => b.Id == Convert.ToInt32(BrigadeIdAppoinmentTextBox.Text));
            if (bri != null)
            {
                if (bri.IsBusy == true)
                {
                    MessageBox.Show("Данная бригада занята, выберите другую", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
            }
            try
            {

                var appointment = new Appoinment(NameAppoinmentTextBox.Text, DiscriptionAppoinmentComboBox.Text, StatusOfAppointmentAppoinmentTextBox.Text, Convert.ToInt32(RequestIdAppoinmentComboBox.Text), Convert.ToInt32(BrigadeIdAppoinmentTextBox.Text));

                db.Appoinments.Add(appointment);
                db.SaveChanges();
                LoadAllData();


                bri.IsBusy = true;
                ClearAppointment();
                MessageBox.Show("Назначение добавлено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButtonAppoinment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Appoinment_DataGrid.SelectedItem is not Appoinment selected)
            {
                MessageBox.Show("Выберите Назначение для Редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string error = "";
            if (NameAppoinmentTextBox.Text == "") error += "Заполните Наименование\n";
            if (StatusOfAppointmentAppoinmentTextBox.Text == "") error += "Выберите статус назначения\n";
            if (RequestIdAppoinmentComboBox.Text == "") error += "Заполните Id заявки\n";
            if (BrigadeIdAppoinmentTextBox.Text == "") error += "Заполните Id бригады\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var bri = db.Brigades.FirstOrDefault(b => b.Id == Convert.ToInt32(BrigadeIdAppoinmentTextBox.Text));
            if (bri != null)
            {
                if (bri.IsBusy == true)
                {
                    MessageBox.Show("Данная бригада занята, выберите другую", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {

                selected.Name = NameTypeOfSituationTextBox.Text;
                selected.StatusOfAppointment = StatusOfAppointmentAppoinmentTextBox.Text;
                selected.RequestId = Convert.ToInt32(RequestIdAppoinmentComboBox.Text);
                selected.BrigadeId = Convert.ToInt32(BrigadeIdAppoinmentTextBox.Text);
                selected.Discription = DescriptionTypeOfSituationTextBox.Text;

                db.SaveChanges();
                LoadAllData();
                ClearAppointment();

                MessageBox.Show("Назначение Изменено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButtonAppoinment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Appoinment_DataGrid.SelectedItem is not Appoinment selected)
            {
                MessageBox.Show("Выберите Назначение для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Удалить Назначение '{selected.Name}'?\n", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    db.Appoinments.Remove(selected);
                    db.SaveChanges();

                    ClearAppointment();
                    LoadAllData();
                    MessageBox.Show("Назначение удалено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ResetContext();
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion
        #region Clear
        private void ClearAbonent()
        {
            FIOAbonentTextBox.Text = null;
            BirthsdayAbonentDatePicker.SelectedDate = null;
            LichesevoiSchetAbonentTextBox.Text = null;
            PassportSerAbonentTextBox.Text = null;
            PassportNumAbonentTextBox.Text = null;
            DopInformationNumAbonentTextBox.Text = null;
        }

        private void ClearEmployee()
        {
            FIOEmployeeTextBox.Text = null;
            PostEmployeeComboBox.SelectedItem = null;
            CvalificationEmployeeTextBox.Text = null;
            TimeOfWorkEmployeeComboBox.SelectedItem = null;
        }
        private void ClearObject()
        {
            AdressObjectTextBox.Text = null;
            ZonesObjectComboBox.SelectedItem = null;
            ObjectsTypeObjectComboBox.SelectedItem = null;
            OborudovanieTypeObjectComboBox.SelectedItem = null;
            YearExpluatationObjectTextBox.Text = null;
            StatusOborudovaniyaObjectTextBox.SelectedItem = null;
            AbonentIDObjectTextBox.Text = null;
        }

        private void ClearBrigade()
        {
            NameBrigadeTextBox.Text = null;
            ZonesBrigadeComboBox.SelectedItem = null;
            TransportBrigadeTextBox.Text = null;
            FilialBrigadeComboBox.SelectedItem = null;
            EmployeeIDBrigadeTextBox.Text = null;
            IsBusyBrigadeCheckBox.IsChecked = false;
        }

        private void ClearMembers()
        {
            RoleInBrigadeMembersOfBrigadeComboBox.SelectedItem = null;
            BrigadeIdMembersOfBrigadeTextBox.Text = null;
            EmployeeIdMembersOfBrigadeTextBox.Text = null;
        }
        private void ClearUsers()
        {
            FIOUserTextBox.Text = null;
            LoginUserTextBox.Text = null;
            PasswordUserTextBox.Text = null;
            RoleUserComboBox.SelectedItem = null;
            FIlialUserComboBox.SelectedItem = null;
            EmailUserTextBox.Text = null;

            ActivityUserCheckBox.IsChecked = null;
        }
        private void ClearType()
        {
            NameTypeOfSituationTextBox.Text = null;
            DescriptionTypeOfSituationTextBox.Text = null;
            DangerTypeOfSituationTextBox.SelectedItem = null;
            ABSTimeTypeOfSituationTextBox.Text = null;
        }

        private void ClearRequestCreate()
        {
            DateOfEnterReguestTextBox.SelectedDate = null;
            DescriptionOfProblemReguestTextBox.Text = null;
            SourceOfReguestReguestTextBox.SelectedItem = null;
            StatusReguestTextBox.SelectedItem = null;
            AbonentIdReguestTextBox.Text = null;
            ObjectIdReguestTextBox.Text = null;
            TypeIdReguestTextBox.Text = null;
        }
        private void ClearRequestClose()
        {
            DateOfStartReguestCloseTextBox.SelectedDate = null;
            DateOfEndReguestCloseTextBox.SelectedDate = null;
            DescriptionOfWorkReguestCloseTextBox.Text = null;
            UsingMaterialsReguestCloseTextBox.Text = null;
            DateOfClosingReguestCloseTextBox.SelectedDate = null;
            ResultOfAppoinmentReguestCloseTextBox.SelectedItem = null;
            CommentOfCloseReguestCloseTextBox.Text = null;
            InformingOfAbonentReguestCloseTextBox.IsChecked = null;
        }

        private void ClearAppointment()
        {
            NameAppoinmentTextBox.Text = null;
            DiscriptionAppoinmentComboBox.Text = null;
            StatusOfAppointmentAppoinmentTextBox.SelectedItem = null;
            RequestIdAppoinmentComboBox.Text = null;
            BrigadeIdAppoinmentTextBox.Text = null;
        }

        private void ClearOformit()
        {
            FIOOformitTextBox.Text = null;
            AdresOformitComboBox.Text = null;
            ZoneOformietTextBox.Text = null;
            TypeOfSituationOformitTextBox.Text = null;
            StatusOborudovaniyaOformitTextBox.Text= null;
            DiscribingProblemOformitgTextBox.Text = null;
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
                RoleUserComboBox.SelectedItem = selected.Role;
                FIlialUserComboBox.SelectedItem = selected.Filial;
                EmailUserTextBox.Text = selected.Email;

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
        #region oformint
        private void ToDocumentButtonOformit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.FileName = "МойДокумент.docx";



            if (saveFileDialog.ShowDialog() == true)
            {
                var doc = new WordDocument();
                var lines = new string[] { "Фамилия Имя Отчество(если есть):________________________________________________________________________",
                "Адрес объекта:__________________________________________________________________________________________________________________________________________________",
                "Район объекта:__________________________________________________________________________________________________________________________________________________",
                "Тип аварийной ситуаци(можно свой):_______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________",
                "Статус оборудования на объекте(Отметьте галочкой):"," • Исправно ❒"," • ТребуетсяРемонт ❒"," • Аварийное ❒",
                "Опишите свою проблему ниже:"};

                var Title = new string[] { "Заявка",
                ""};
                
                foreach (string title in Title)
                {
                    var paragraph = new Paragraph();
                    paragraph.Alignment = IronSoftware.Abstractions.Word.TextAlignment.Center;
                    var textRun = new IronWord.Models.Run(new TextContent(title));
                    textRun.Style = new TextStyle()
                    {
                        FontSize = 16,
                        Color = Color.Black,
                        TextFont = new Font() { FontFamily = "Times New Roman" },
                        Spacing = 0,
                        IsBold = true,
                    };
                    paragraph.AddChild(textRun);
                    doc.AddParagraph(paragraph);
                }

                foreach (string line in lines)
                {

                    var par = new Paragraph();
                    var textRunn = new IronWord.Models.Run(new TextContent(line));
                    textRunn.Style = new TextStyle()
                    {
                        FontSize = 12,
                        Color = Color.Black,
                        TextFont = new Font() { FontFamily = "Times New Roman" },
                        Spacing = 0,
                    };

                    par.AddChild(textRunn);
                    doc.AddParagraph(par);
                }

                doc.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Документ Word успешно сохранен");
            }
        }
        

        private void AddButtonOformit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string error = "";
            if (FIOOformitTextBox.Text == "") error += "Выбирете ФИО Абонента\n";
            if (AdresOformitComboBox.Text == "") error += "Выберите адрес объекта\n";
            if (ZoneOformietTextBox.Text == "") error += "Заполните район, выбрав объект\n";
            if (TypeOfSituationOformitTextBox.Text == "") error += "Выбирете тип аварийной ситуации\n";
            if (StatusOborudovaniyaOformitTextBox.Text == "") error += "Выбирете статус оборудования\n";
            if (DiscribingProblemOformitgTextBox.Text == "") error += "Опишите проблему\n";
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int idAb = (db.Abonents.FirstOrDefault(a => a.FIO == FIOOformitTextBox.Text).Id);
                int idOb = (db.Objects.FirstOrDefault(a => a.Adress == AdresOformitComboBox.Text).Id);
                int idTy = (db.TypesOfSituation.FirstOrDefault(a => a.Name == TypeOfSituationOformitTextBox.Text).ID);
                var request = new Request(DateTime.Now, DiscribingProblemOformitgTextBox.Text, SourceOfRequestList[2], RequestStatusList[0],null,null,null,null,null,null,null,false,idAb,idOb,idTy);
                db.Requests.Add(request);
                db.SaveChanges();
                LoadAllData();
                ClearOformit();
                MessageBox.Show("Заявка добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                int idreg = db.Requests.Max(r => r.Id);
                var brigade = (from b in db.Brigades where b.IsBusy == false select b).ToList();
                if (brigade != null)
                {
                    Random random = new Random();
                    int br = random.Next(0, brigade.Count);
                    var brig = new Appoinment($"Назначение по заявке {idreg}", null, StatusOfAppointmentList[0], idreg, brigade[br].Id);
                    db.Appoinments.Add(brig);
                    brigade[br].IsBusy = true;
                    db.SaveChanges();
                    LoadAllData();
                    MessageBox.Show("По вашей заявке была назначена бригада, ожидайте", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("В данный момент нет свободных бригад, ожидайте назначения бригады оператором", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (Exception ex)
            {
                ResetContext();
                MessageBox.Show("Ошибка, проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButtonOformit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearOformit();
        }

        
        #endregion

        private void FIOOformitTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (FIOOformitTextBox.SelectedItem == null)
            {
                AdresOformitComboBox.ItemsSource = null;
                AdresOformitComboBox.Text = "";
                ZoneOformietTextBox.Text = "";
                AdresOformitComboBox.IsEnabled = false;
                currentAbonentObjects.Clear();
                return;
            }

            string fio = FIOOformitTextBox.SelectedItem.ToString().Trim();

            if (string.IsNullOrEmpty(fio))
            {
                AdresOformitComboBox.ItemsSource = null;
                AdresOformitComboBox.Text = "";
                ZoneOformietTextBox.Text = "";
                AdresOformitComboBox.IsEnabled = false;
                currentAbonentObjects.Clear();
                return;
            }

            try
            {
                // Ищем абонента по ФИО
                var abonent = db.Abonents
                    .FirstOrDefault(a => a.FIO == fio);

                if (abonent == null)
                {
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

                // ✅ Загружаем объекты абонента
                var objects = db.Objects
                    .Where(o => o.AbonentID == abonent.Id)
                    .ToList();

                currentAbonentObjects = objects;

                if (currentAbonentObjects.Any())
                {
                    // ✅ Заполняем ComboBox адресами
                    AdresOformitComboBox.ItemsSource = currentAbonentObjects
                        .Select(o => o.Adress)
                        .ToList();
                    AdresOformitComboBox.IsEnabled = true;
                    AdresOformitComboBox.Text = "";
                    ZoneOformietTextBox.Text = "";
                }
                else
                {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке объектов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AdresOformitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранный адрес как строку
            string selectedAdress = AdresOformitComboBox.SelectedItem as string;

            // Если адрес не выбран или пустой — очищаем поле района
            if (string.IsNullOrEmpty(selectedAdress))
            {
                ZoneOformietTextBox.Text = "";
                return;
            }

            // Ищем объект с таким адресом в заранее загруженном списке currentAbonentObjects
            var selectedObject = currentAbonentObjects
                .FirstOrDefault(o => o.Adress == selectedAdress);

            if (selectedObject != null)
            {
                // Подставляем район в текстовое поле
                ZoneOformietTextBox.Text = selectedObject.Zones;
            }
            else
            {
                // Если объект не найден — очищаем поле
                ZoneOformietTextBox.Text = "";
            }
        }
    }
}