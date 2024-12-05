using System;
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
using WpfApp1.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Partners _currentPartner = null;

        public MainWindow()
        {
            InitializeComponent();
            UpdateListPartners();
        }

        private void UpdateListPartners()
        {
            ListViewPartners.ItemsSource = Core.GetContext().Partners.ToList();
        }

        private void ListViewPartners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewPartners.SelectedItems.Count == 0)
            {
                HistoryProductsSaleBtn.Visibility = Visibility.Collapsed;
                _currentPartner = null;
                return;
            }

            HistoryProductsSaleBtn.Visibility = Visibility.Visible;
            _currentPartner = ListViewPartners.SelectedItems[0] as Partners;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }

        private void AddPartnerBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditPartners addEditPartners = new Windows.AddEditPartners();
            addEditPartners.HeaderTitleTextBox.Text = "Добавление партнера";  // Изменим заголовок открываемого окна
            addEditPartners.ShowDialog();
            UpdateListPartners();  // Обновление списка партнеров на главной форме
        }

        private void EditPartnerBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditPartners addEditPartners = new Windows.AddEditPartners(_currentPartner);
            addEditPartners.HeaderTitleTextBox.Text = "Редактирование партнера";  // Изменим заголовок открываемого окна
            addEditPartners.ShowDialog();
            UpdateListPartners();  // Обновление списка партнеров на главной форме
        }

        private void HistoryProductsSaleBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.HistoryProductsSales historyProductsSales = new Windows.HistoryProductsSales(_currentPartner);
            historyProductsSales.ShowDialog();
        }

        private void ListViewPartners_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_currentPartner != null)  // Условие необходимо, чтобы форма не открывалась при клике на пустое место
            {
                Windows.AddEditPartners addEditPartners = new Windows.AddEditPartners(_currentPartner);
                addEditPartners.HeaderTitleTextBox.Text = "Редактирование партнера";
                addEditPartners.ShowDialog();
                UpdateListPartners();
            }
        }
    }
}
