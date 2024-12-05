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
using System.Windows.Shapes;
using WpfApp1.Data;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для HistoryProductsSales.xaml
    /// </summary>
    public partial class HistoryProductsSales : Window
    {
        public HistoryProductsSales(Partners _currentPartner)
        {
            InitializeComponent();
            if (_currentPartner != null )
            {
                ListHistoryProductsSales.ItemsSource = Core.GetContext().PartnerProducts.Where(x => x.PartnerID == _currentPartner.ID).ToList();
                if (ListHistoryProductsSales.Items.Count == 0)
                {
                    // Вывод предупреждения, если у партнера еще нет данных о реализации продукции
                    MessageBox.Show("Информация", "Данный партнер еще не реализовывал продукцию", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else
            {
                // Вывод ошибки если небыл передан партнер для получения истории
                MessageBox.Show("Информация", "Выберите партнера, чтобы отобразилась история", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
