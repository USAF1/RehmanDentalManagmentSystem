using AppUI.Controllers;
using AppUI.Helpers;
using AppUI.Models;
using EntityLibrary.PatientManagment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppUI.Views
{
    /// <summary>
    /// Interaction logic for LabWindow.xaml
    /// </summary>
    public partial class LabWindow : Window
    {
        public LabWindow()
        {
            InitializeComponent();
        }

        private void PatientSearch_Click(object sender, RoutedEventArgs e)
        {
            if (Search.Text != " " && Convert.ToInt32(Search.Text) > 0)
            {
                GetUserInfo.Id = Convert.ToInt32(Search.Text);

                PatientModel model = PatientHandler.GetPatient(Convert.ToInt32(Search.Text)).ToModel();
                if (model != null)
                {
                    Name.Text = model.Name;
                    Age.Text = Convert.ToString(model.Age);
                    Gender.Text = model.Gender;
                    if (model.Contact > 0)
                    {
                        Contact.Text = Convert.ToString(model.Contact);
                    }
                    AddItemsToTestList();
                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            else
            {
                MessageBox.Show("Please Enter a Patient Id");
            }

        }

        public void AddItemsToTestList()
        {
            TestList.Items.Clear();

            double total = 0;

            Patient patient = new Patient();
            if (GetUserInfo.Id > 0)
            {
                patient = PatientHandler.GetPatient(GetUserInfo.Id);
            }
            if (patient != null)
            {
                if (patient.Tests != null)
                {
                    foreach (var test in patient.Tests)
                    {

                        TestList.Items.Add(test.Name);
                        total = total + test.Price;
                    }
                    Total.Content = total;

                }
                else
                {
                    TestList.Items.Add("No Tests Assign");
                    Total.Content = total;
                }
            }




        }
    }
}
