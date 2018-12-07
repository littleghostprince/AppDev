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
        private void Eye4_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye4.Source;
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
        private void Hair4_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair4.Source;
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

        private void Mouth4_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth4.Source;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = null;
            Mouth.Source = null;
            Hair.Source = null;
            HairAcessory.Source = null;
            Clothes.Source = null;
            Background.Source = Bg1.Source;
        }

        private void A1_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = a1.Source;
        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = a2.Source;
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = a3.Source;
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

                PresentationSource source = PresentationSource.FromVisual(Canvas);
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)Canvas.RenderSize.Width,(int)Canvas.RenderSize.Height, 96, 96, PixelFormats.Default);

                VisualBrush sourceBrush = new VisualBrush(Canvas);
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext drawingContext = drawingVisual.RenderOpen();

                using (drawingContext)
                {
                    drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Windows.Point(0, 0),
                          new System.Windows.Point(Canvas.RenderSize.Width, Canvas.RenderSize.Height)));
                }
                rtb.Render(drawingVisual);

                encoder.Frames.Add(BitmapFrame.Create(rtb));

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

        private void A4_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = a4.Source;
        }

        private void A5_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = a5.Source;
        }

        private void A6_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = a6.Source;
        }

        private void Mouth5_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth5.Source;
        }

        private void Mouth6_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth6.Source;
        }

        private void Mouth7_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth7.Source;
        }

        private void Mouth8_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth8.Source;
        }

        private void Mouth9_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth9.Source;
        }

        private void Mouth10_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth10.Source;
        }

        private void Mouth11_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth11.Source;
        }

        private void Mouth12_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = mouth12.Source;
        }

        private void Hair5_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair5.Source;
        }

        private void Hair6_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair6.Source;
        }

        private void Hair7_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair7.Source;
        }

        private void Hair8_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = hair8.Source;
        }

        private void Eye5_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye5.Source;
        }

        private void Eye6_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye6.Source;
        }

        private void Eye7_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye7.Source;
        }

        private void Eye8_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = eye8.Source;
        }

        private void Clothes1_Click(object sender, RoutedEventArgs e)
        {
            Clothes.Source = shirt1.Source;
        }

        private void Clothes2_Click(object sender, RoutedEventArgs e)
        {
            Clothes.Source = shirt2.Source;
        }

        private void Clothes3_Click(object sender, RoutedEventArgs e)
        {
            Clothes.Source = shirt3.Source;
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Background.Source = Bg1.Source;
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Background.Source = Bg2.Source;
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Background.Source = Bg3.Source;
        }

        private void A7_Click(object sender, RoutedEventArgs e)
        {
            HairAcessory.Source = null;
        }

        private void Clothes4_Click(object sender, RoutedEventArgs e)
        {
            Clothes.Source = null;
        }

        private void Eye9_Click(object sender, RoutedEventArgs e)
        {
            Eyes.Source = null;
        }

        private void Hair9_Click(object sender, RoutedEventArgs e)
        {
            Hair.Source = null;
        }

        private void Mouth13_Click(object sender, RoutedEventArgs e)
        {
            Mouth.Source = null;
        }
    }
}
