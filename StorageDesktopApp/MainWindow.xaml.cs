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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddStateOfStorage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet =(");
        }

        private void btnChangeQuantity_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet =(");
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet =(");
        }

        private async void btnRefreshStatesOfStorages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatesOfStorages = await StorageAPIClient.StatesOfStorages.GetAllStatesOfStorages(StorageHTTPClient.Instance.HttpClient);
                dgStatesOfProducts.ItemsSource = StatesOfStorages;
                Product.ProductsList = await StorageAPIClient.Products.GetAllProducts(StorageHTTPClient.Instance.HttpClient);
                Storage.StoragesList = await StorageAPIClient.Storages.GetAllStorages(StorageHTTPClient.Instance.HttpClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnShowProduct_Click(object sender, RoutedEventArgs e)
        {
            var productsWindow = new ProductsWindow();
            productsWindow.Owner = this;
            if (productsWindow.ShowDialog() != true)
            {
                return;
            }
            Product selectedProduct = productsWindow.SelectedProduct;
            StatesOfStorages = await StorageAPIClient.StatesOfStorages.GetStatesFilteredByProduct(StorageHTTPClient.Instance.HttpClient, selectedProduct.Id);
            dgStatesOfProducts.ItemsSource = StatesOfStorages;
        }

        private void btnShowStorage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet =(");
        }
    }
}
