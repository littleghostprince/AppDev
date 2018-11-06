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
using ComboBox.Models;

namespace ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] drinks = { "powerade", "Water" };
            foreach(string drink in drinks)
            {
                DrinkComboBox.Items.Add(drink);
            }

            List<Pokeman> pokemans = new List<Pokeman>
            {
                new Pokeman{name = "GageBoi", type= Pokeman.eType.WATER, index = 1},
                 new Pokeman{name = "SpitFire", type= Pokeman.eType.FIRE, index =2 },
                  new Pokeman{name = "killMe", type= Pokeman.eType.WATER, index =3 },

            };
            PokemonComboBox.ItemsSource = pokemans;

            ColorComboBox.ItemsSource = typeof(Colors).GetProperties();
            ColorComboBox.SelectedIndex = 0;
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            DrinkComboBox.Items.Add(DrinkEntry.Text);
            DrinkEntry.Text = "";
        }

        private void RemoveDrinkButton_Click(object sender, RoutedEventArgs e)
        {
           var selection = DrinkComboBox.SelectedItem;
            if(selection !=null)
            {
                DrinkComboBox.Items.RemoveAt(DrinkComboBox.Items.IndexOf(selection));
            }
        }
    }
}
