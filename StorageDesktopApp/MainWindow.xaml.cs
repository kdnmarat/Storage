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

            Storages = new List<Models.Storage>();
            Storages.Add(new Models.Storage() { Id = 1, Name = "Storage1", KindOfStorage = "Fruits", Address = "Somewhere", IsChecked = true});
            Storages.Add(new Models.Storage() { Id = 2, Name = "Storage2", KindOfStorage = "Fruits", Address = "Somewhere", IsChecked = true });
            Storages.Add(new Models.Storage() { Id = 3, Name = "Storage3", KindOfStorage = "Fruits", Address = "Somewhere", IsChecked = false });
            Storages.Add(new Models.Storage() { Id = 4, Name = "Storage4", KindOfStorage = "Fruits", Address = "Somewhere", IsChecked = true });
            lbFilterByStorages.ItemsSource = Storages;
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
    }
}
