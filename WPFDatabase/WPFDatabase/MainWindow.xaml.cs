using System;
using System.Collections.Generic;
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

namespace WPFDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeacherDataSet teacher = new TeacherDataSet();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         DbSet<TeacherDataSet> teachers = dataEntries.Teachers;

            var query = from teacher in teachers
                        where teacher.Salary > 70000
                        orderby teacher.Name
                        select teacher;

          TeacherDataSet.ItemsSource Teacher.ToList();

        }
    }

}
