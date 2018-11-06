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

namespace WpfUserControls.UserControls
{
    /// <summary>
    /// Interaction logic for UCButton.xaml
    /// </summary>
    public partial class UCButton : UserControl
    {

        ///propdb double tap tab


        public object revealProperty
        {
            get { return (object)GetValue(revealPropertyProperty); }
            set { SetValue(revealPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for revealProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty revealPropertyProperty =
            DependencyProperty.Register("revealProperty", typeof(object), typeof(UCButton), new PropertyMetadata(0));





        public UCButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            revealGrid.Visibility = (revealGrid.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
           contentGrid.Visibility = (contentGrid.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
