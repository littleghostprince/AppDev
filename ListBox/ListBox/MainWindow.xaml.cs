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
using System.Windows.Forms;

namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DirectorySelection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DirectorySelection = dialog.SelectedPath;
                ListBoxInfo.Text = dialog.SelectedPath;
             //   UpdateListBox(dialog.SelectedPath);
            }

        }

        private void UpdateListBox(string path)
        {
            ListBox.Items.Clear();
            if(path != null)
            {
                if(Files.IsChecked == true)
                {
                    string[] files = Directory.GetFiles(path);
                    foreach(string file in files)
                    {
                        ListBox.Items.Add(file);
                    }
                }
                if (Directories.IsChecked == true)
                {
                    string[] directories = Directory.GetDirectories(path);
                    foreach (string directory in directories)
                    {
                        ListBox.Items.Add(directory);
                    }
                }
            }
        }


        private void Files_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListBox(DirectorySelection);
        }

        private void Directories_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListBox(DirectorySelection);
        }

        private void Directories_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void Files_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int number = 0;
            long size = 0;
            System.Windows.Controls.ListBox listbox = (System.Windows.Controls.ListBox)sender;
            foreach (var item in listbox.SelectedItems)
            {
                if (File.Exists(item.ToString()))
                {
                    FileInfo f = new FileInfo(item.ToString());
                    size = f.Length;
                    number++;
                }
            }

            ListBoxInfo.Text = "size: " + size.ToString("N0") + " - " + number + "files(s)";
        }
    }
}
