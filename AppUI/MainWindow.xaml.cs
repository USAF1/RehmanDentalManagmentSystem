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
using AppUI.Helpers;
using AppUI.Models;
using EntityLibrary.UsersManagment;
using AppUI.Views;

namespace AppUI
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text != null && Password.Text != null)
            {
               
                User entity = new User() { UserName = UserName.Text, Password = Password.Text };
                UserModel user = UsersHandler.GetUser(entity).ToModel();

                if (user.Role.Name == "Reciption")
                {
                    ReciptionWindow window = new ReciptionWindow();
                    window.Show();
                    this.Close();
                }else if (user.Role.Name == "Doctor")
                {
                    DoctorWindow window = new DoctorWindow();
                    window.Show();
                    this.Close();
                }
                else if (user.Role.Name == "Lab")
                {
                    LabWindow window = new LabWindow();
                    window.Show();
                    this.Close();
                }else if (user.Role.Name == "Admin")
                {
                    AdminWindow window = new AdminWindow();
                    window.Show();
                    this.Close();
                }

            }
        }
    }
}
