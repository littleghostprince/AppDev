using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GridWPF.Model;

namespace GridWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Restaurant> resturants = new ObservableCollection<Restaurant>();
        public MainWindow()
        {
            InitializeComponent();

            resturants = new ObservableCollection<Restaurant>
            {
                new Restaurant { Name = "McDonalds", Type = RestaurantType.AMERICAN, Phone = "(801) 555-5555", Address = "Main St", Rating = 5, Open = true },
                new Restaurant { Name = "Carls Jr", Type = RestaurantType.AMERICAN, Phone = "(801) 444-4444", Address = "Center St", Rating = 3, Open = true },
                new Restaurant { Name = "Pizza Hut", Type = RestaurantType.ITALIAN, Phone = "(801) 333-3333", Address = "Apple St", Rating = 2, Open = false},
            };

          //  ResturantDataGrid.ItemsSource = resturants;
          DataContext = resturants;
        }

        private void AddResturant_Click(object sender, RoutedEventArgs e)
        {
            Restaurant restaurant = new Restaurant
            {
                Name = "Default",
                Type = RestaurantType.UNKNOWN,
                Phone = "(555)111-1111",
                Address = "13th St",
                Rating = 0,
                Open = false
            };
            resturants.Add(restaurant);
        }
    }
}
