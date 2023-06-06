using StorageDesktopApp.Models;
using StorageDesktopApp.StorageAPIClient;
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

namespace StorageDesktopApp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public Product SelectedProduct
        {
            get { try { return (Product)dgProducts.SelectedItem; } catch { return null; } }
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
    }
}
