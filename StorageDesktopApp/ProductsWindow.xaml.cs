using StorageDesktopApp.Models;
using StorageDesktopApp.StorageAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Xml.Linq;

namespace StorageDesktopApp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public Product? SelectedProduct
        {
            get { try { return (Product)dgProducts.SelectedItem; } catch { return null; } }
            set { }
        }
        public ProductsWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Product.ProductsList = await Products.GetAllProducts(StorageHTTPClient.Instance.HttpClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR while attempting to get Products: \n\n{ex.Message}");
            }
            dgProducts.ItemsSource = Product.ProductsList;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnChooseProduct_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private async void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if ((tbName.Text.Length == 0) || (tbCost.Text.Length == 0))
            {
                return;
            }
            HttpResponseMessage response = null;
            try
            {
                Product newProduct = new Product()
                {
                    Name = tbName.Text,
                    Cost = Decimal.Parse(tbCost.Text),
                };
                response = await Products.AddProduct(StorageHTTPClient.Instance.HttpClient, newProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK,  MessageBoxImage.Error);
                return;
            }
            if ((response != null) && (response.StatusCode != HttpStatusCode.OK))
            {
                MessageBox.Show($"Something went wrong. \n" +
                    $"StatusCode: {(int)(response.StatusCode)} ({response.StatusCode})",
                    "Unexpected result", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            MessageBox.Show("Successfully added!");
            tbName.Text = "";
            tbCost.Text = "";
            SelectedProduct = null;
            dgProducts.SelectedItem = null;
            Product.ProductsList = await Products.GetAllProducts(StorageHTTPClient.Instance.HttpClient);
            dgProducts.ItemsSource = Product.ProductsList;
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet =(");
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet =(");
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedItem == null)
            {
                return;
            }
            SelectedProduct = (Product)(dgProducts.SelectedItem);
            tbId.Text = SelectedProduct.Id.ToString();
            tbName.Text = SelectedProduct.Name;
            tbCost.Text = SelectedProduct.Cost.ToString();
        }
    }
}
