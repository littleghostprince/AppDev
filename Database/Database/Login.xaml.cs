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
using System.Windows.Shapes;

namespace Database
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        AshleyDBEntities dataEntities = new AshleyDBEntities();
        ObservableCollection<User> users;

        public Login()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var query = from user in users
                        where (user.Name == UserName) 
                        where (user.Password == UserPassword)
                        select user;
            if(query.Count() > 0)
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            newUser.Name = UserName;
            newUser.Password = UserPassword;

            users.Add(newUser);
            dataEntities.Users.Add(newUser);
            dataEntities.SaveChanges();
            MessageBox.Show("Saved!");
           
                       
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>(dataEntities.Users);
            // trim the white space from the users
            foreach (User user in users)
            {
                user.Name = user.Name.Trim();
                user.Password = user.Password.Trim();
            }
        }
        
    }
}
