using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Open Text File";
            openDialog.RestoreDirectory = true; //this will start where you left off 
           if( openDialog.ShowDialog() == true )
            {
                TextDoc.Text = File.ReadAllText(openDialog.FileName);
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveDialog = new OpenFileDialog();
            saveDialog.Title = "Save Text File";
            saveDialog.RestoreDirectory = true;
           if( saveDialog.ShowDialog() == true )
            {
                File.WriteAllText(saveDialog.FileName, TextDoc.Text);
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuFontTimes_Click(object sender, RoutedEventArgs e)
        {
            menuFontAriel.IsChecked = false;
            menuFontCourier.IsChecked = false;
            TextDoc.FontFamily = new FontFamily("Times New Roman");
        }

        private void menuFontCourier_Click(object sender, RoutedEventArgs e)
        {
            menuFontAriel.IsChecked = false;
            menuFontTimes.IsChecked = false;
            TextDoc.FontFamily = new FontFamily("Courier New");
        }

        private void menuFontAriel_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontTimes.IsChecked = false;
            TextDoc.FontFamily = new FontFamily("Arial");
        }
        private void UpdateFontSize(object sender)
        {
            string text = ((ComboBox)sender).Text;
            if(text != "")
            {
                int size = int.Parse(text);
                TextDoc.FontSize = size;
            }
        }
        private void comboFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFontSize(sender);
        }

        private void comboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            UpdateFontSize(sender);
        }
    }
}
