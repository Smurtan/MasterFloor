using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Data;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditPartners.xaml
    /// </summary>
    public partial class AddEditPartners : Window
    {
        // Изначально присваиваем партнера как новый элемент,
        // чтобы при открытии формы для добавления новый партнер с пустыми данными уже был создан
        Partners _currentPartners = new Partners();

        public AddEditPartners(Partners currentPartners = null)
        {
            InitializeComponent();
            // Если передан экземпляр партнера, значит выполняется редактирование данных и необходимо заполнить текущие данные
            if (currentPartners != null)
            {
                _currentPartners = currentPartners;
            }
            // Заполняем выпадающий список типов партнера возможными значениями
            TypeComboBox.ItemsSource = new List<string>() { "ЗАО", "ООО", "ПАО", "ОАО"};
            // Заполнение формы данными редактируемого или нового партнера
            this.DataContext = _currentPartners;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            // Очистка всех полей по клику на кнопку очистки
            TitlePartnerTextBox.Text = "";
            TypeComboBox.SelectedIndex = 0;
            RatingTextBox.Text = "";
            LegalAddressTextBox.Text = "";
            DirectorTextBox.Text = "";
            PhoneTextBox.Text = "";
            EmailTextBox.Text = "";
            INNTextBox.Text = "";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных с формы
            string title = TitlePartnerTextBox.Text.Trim();  // метод .Trim() в конце используется чтобы убрат пустые символы (пробел) в начале и конце строки
            string type = TypeComboBox.SelectedValue.ToString();
            string ratingStr = RatingTextBox.Text;
            string legalAddress = LegalAddressTextBox.Text;
            string director = DirectorTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            string inn = INNTextBox.Text;

            // Проверка что введены все данные
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введите название партнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Выберите тип пратнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(ratingStr))
            {
                MessageBox.Show("Введите рейтинг пратнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(legalAddress))
            {
                MessageBox.Show("Введите адрес пратнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(director))
            {
                MessageBox.Show("Введите ФИО директора", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Введите телефон пратнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите почту пратнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(inn))
            {
                MessageBox.Show("Введите ИНН пратнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка что название не слишком длинное
            if (title.Length > 255)
            {
                MessageBox.Show("Название партнера слишком длинное", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что тип партнера соответствует одному из возможных значений
            if (type != "ЗАО" && type != "ООО" && type != "ОАО" && type != "ПАО")
            {
                MessageBox.Show("Выберите верный тип партнера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что рейтинг партнера является целым числом
            if (!int.TryParse(ratingStr, out int rating))
            {
                MessageBox.Show("Рейтинг партнера должен быть целым числом", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что адрес партнера не слишком длинный
            if (legalAddress.Length > 255)
            {
                MessageBox.Show("Адрес партнера слишком длинный", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что ФИО директора не слишком короткое
            if (director.Length < 4)
            {
                MessageBox.Show("ФИО директора слишком Короткое", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что ФИО директора не слишком дилнное
            if (director.Length > 255)
            {
                MessageBox.Show("ФИО директора слишком длинное", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что номер телефона имеет необходимое количетсов цифр
            if (phone.Length > 13 || phone.Length < 10)
            {
                MessageBox.Show("Телефон партнера слишком длинный", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что номер телефона не содержит букв
            if (phone.All(char.IsLetter))
            {
                MessageBox.Show("Телефон партнера не должен содержать буквы", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что email не слишком длинный
            if (email.Length > 255)
            {
                MessageBox.Show("Email партнера слишком длинный", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что email содержит символ @
            if (!email.Contains("@"))
            {
                MessageBox.Show("Email введен неверно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что ИНН имеет необходимое количество цифр
            if (inn.Length != 10)
            {
                MessageBox.Show("ИНН партнера введен неверно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Проверка что ИНН является числом
            if (!inn.All(char.IsDigit))
            {
                MessageBox.Show("ИНН партнера должен содержать только цифры", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            /*
             Многострочный для описания блока
             */
            try
            {
                if (_currentPartners.ID == 0)
                {
                    // Проверка намерения пользователя выполнить действие
                    if (MessageBox.Show("Вы точно хотите добавить партнера?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    {
                        return;
                    }
                    
                    // Если у партнера нет ID, значит добавляется новый партнер
                    Core.GetContext().Partners.Add(_currentPartners);
                } else
                {
                    // Проверка намерения пользователя выполнить действие
                    if (MessageBox.Show("Вы точно хотите изменить данные партнера?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    {
                        return;
                    }
                }
                // Сохраняем изменения данных партнера или добавление нового партнера
                Core.GetContext().SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show("При сохранении данных произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RatingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = RatingTextBox.Text.Trim();
            if (!int.TryParse(text, out int value))
            {
                MessageBox.Show("Рейтинг партнера должен быть целым числом", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
