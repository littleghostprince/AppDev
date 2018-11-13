using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AshleyDBEntities dataEntities = new AshleyDBEntities();
        ObservableCollection<Product> ProductCollection;

        public bool IsPerishable { get; set; }
        public decimal MinPrice { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductCollection = new ObservableCollection<Product>(dataEntities.Products);
            DatabaseDisplay.ItemsSource = ProductCollection;
        }

        private void SaveDatabse_Click(object sender, RoutedEventArgs e)
        {
            dataEntities.SaveChanges();
            MessageBox.Show("Saved", "Database", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateDatabse_Click(object sender, RoutedEventArgs e)
        {
            var query = from Product in ProductCollection
                        where Product.Perishable == IsPerishable
                        where Product.Price >= MinPrice
                        orderby Product.Name
                        select Product;

            DatabaseDisplay.ItemsSource = query.ToList();
        }

        private void ResetDatabase_Click(object sender, RoutedEventArgs e)
        {
            DatabaseDisplay.ItemsSource = ProductCollection;
        }
    }
}
