using StorageDesktopApp.Models;
using System;
using System.Collections;
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
using StorageDesktopApp.StorageAPIClient;

namespace StorageDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<StateOfStorage> StatesOfStorages;
        public List<Storage> Storages;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddStateOfStorage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnRefreshStatesOfStorages_Click(object sender, RoutedEventArgs e)
        {
            StatesOfStorages = await StorageAPIClient.StatesOfStorages.GetAllStatesOfStorages(StorageHTTPClient.Instance.HttpClient);
            dgStatesOfProducts.ItemsSource = StatesOfStorages;
        }

        private void btnShowProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowStorage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
