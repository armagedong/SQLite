using MySQL.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductDbContext dbContext;
        Product newProduct = new Product();
        public MainWindow(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            DGProduct.ItemsSource = dbContext.Products.ToList();

            DGAdd.DataContext = newProduct;
        }

        public void GetProduct()
        {
            DGProduct.ItemsSource = dbContext.Products.ToList();
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
            GetProduct();
            newProduct = new Product();
            DGAdd.DataContext = newProduct;
        }

        Product selectedProduct = new Product();
        private void UpdateClickForEdit(object sender, RoutedEventArgs e)
        {
            selectedProduct = (sender as FrameworkElement).DataContext as Product;
            DGUpdate.DataContext = selectedProduct;
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            dbContext.Update(selectedProduct);
            dbContext.SaveChanges();
            GetProduct();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var productForDelete = (sender as FrameworkElement).DataContext as Product;
            dbContext.Products.Remove(productForDelete);
            dbContext.SaveChanges();
            GetProduct();
        }
    }
}