using EntityLibrary.UsersManagment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppUI.Views.AdminView
{
    /// <summary>
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Window
    {

        public ObservableCollection<UsersListClass> UsersList { get; set; }
        List<User> users = UsersHandler.GetUsers();


        public AdminUsers()
        {
            InitializeComponent();
            UpdateUsersList();

        }

        public class UsersListClass
        {
            public string itemText { get; set; }
            public string itemRole { get; set; }
        }

        public void UpdateUsersList()
        {
            UsersList = new ObservableCollection<UsersListClass>();
            foreach (var user in users)
            {
                UsersList.Add(new UsersListClass { itemText = user.UserName, itemRole = user.Role.Name });
            }
            this.DataContext = this;
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkedUser = (CheckBox)sender;
            MessageBox.Show($"{ checkedUser.Content.ToString()}");
        }
        private void UserChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkedUser = (CheckBox)sender;
            MessageBox.Show($"{checkedUser.Content.ToString()}");
        }
    }
}
