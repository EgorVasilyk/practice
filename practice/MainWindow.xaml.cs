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
using practice.airDataSetTableAdapters;

namespace practice
{
    public partial class MainWindow : Window
    {
        usersTableAdapter users = new usersTableAdapter();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LogBox.Text;
            string password = PassBox.Password;
            var checkAdmin = users.GetData().FirstOrDefault(element => element.users_login == login && element.users_password == password && element.users_role == "admin");
            var checkUser = users.GetData().FirstOrDefault(element => element.users_login == login && element.users_password == password && element.users_role == "user");
            if (checkAdmin != null)
            {
                WrongData.Content = "";
                Frame.Visibility = Visibility.Visible;
                Frame.Content = new AdminPage();
                RB.Visibility = Visibility.Visible;
            }
            else if (checkUser != null)
            {
                WrongData.Content = "";
                Frame.Visibility = Visibility.Visible;
                Frame.Content = new CustomerPage();
                RB.Visibility = Visibility.Visible;
            }
            else
            {
                WrongData.Content = "неверный логин \n" + "или пароль";
            }
        }

        private void RB_Click(object sender, RoutedEventArgs e)
        {
            Frame.Visibility = Visibility.Collapsed;
            RB.Visibility = Visibility.Collapsed;
        }
    }
}
