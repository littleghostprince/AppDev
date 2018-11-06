using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace WpfPaint
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

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radiobutton = (RadioButton)sender;
            string name = radiobutton.Name;
            switch(name)
            {
                case "DrawButton":
                   this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "EraseButton":
                    this.DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "SelectionButton":
                    this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        private void SetBrushSize(object sender)
        {
            string text = ((ComboBox)sender).Text;

            if(text!="")
            {
                int size = Int32.Parse(text);
                BrushAttrib.Width = size;
                BrushAttrib.Height = size;
            }
        }


        private void BrushSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetBrushSize(sender);
        }

        private void BrushSize_DropDownClosed(object sender, EventArgs e)
        {
            SetBrushSize(sender);
        }

        private void Color_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            if(colorPicker!=null)
            {
                BrushAttrib.Color = (Color)colorPicker.SelectedColor;
            }
        }
    }
}
