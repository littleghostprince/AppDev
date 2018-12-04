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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace AvatarMaking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Eye2_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye2.Source;
        }

        private void Eye1_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye1.Source;
        }

        private void Eye3_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye3.Source;
        }

        private void Hair1_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair1.Source;
        }

        private void Hair2_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair2.Source;
        }

        private void Hair3_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair3.Source;
        }

        private void Mouth1_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth1.Source;
        }

        private void Mouth2_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth2.Source;
        }

        private void Mouth3_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth3.Source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = null;
            Mouth.Source = null;
            Hair.Source = null;
        }

        private void A1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var fileDirectory = new System.Windows.Forms.SaveFileDialog();
            fileDirectory.RestoreDirectory = true;
            fileDirectory.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDirectory.DefaultExt = ".jpg";

            if (fileDirectory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var encoder = new PngBitmapEncoder();

                RenderTargetBitmap renderBitmap1 = new RenderTargetBitmap((int)Canvas.ActualWidth, (int)Canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
                
                // needed otherwise the image output is black
                Canvas.Measure(new System.Windows.Size((int)Canvas.ActualWidth, (int)Canvas.ActualHeight));
                Canvas.Arrange(new Rect(new System.Windows.Size((int)Canvas.ActualWidth, (int)Canvas.ActualHeight)));

                renderBitmap1.Render(Canvas);

                encoder.Frames.Add(BitmapFrame.Create(renderBitmap1));

                //encoder.Frames.Add(BitmapFrame.Create((BitmapSource)Canvas.con));
                // encoder.Frames.Add(BitmapFrame.Create((BitmapSource)Background.Source)); //Saves the background

                using (FileStream stream = new FileStream(fileDirectory.FileName, FileMode.Create))
                {
                    encoder.Save(stream);
                }
                Bitmap newBitmap;
                using (var bitmap = (Bitmap)System.Drawing.Image.FromFile(fileDirectory.FileName))
                {
                    newBitmap = new Bitmap(bitmap);
                }
                newBitmap.Save(fileDirectory.FileName);
                newBitmap.Dispose();
            }
        }
    }
}
