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
using AppUI.Models;
using AppUI.Helpers;
using EntityLibrary.PatientManagment;
using AppUI.Controllers;
using EntityLibrary.TestManagment;

namespace AppUI.Views
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
            AddItemsToTestList();
        }

        private void PatientSearch_Click(object sender, RoutedEventArgs e)
        {
            if (Search.Text != " " && Convert.ToInt32(Search.Text)>0)
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
                }
                else
                {
                    MessageBox.Show("No Record Found");
                }

                AddItemsToTestList();
            }
            else
            {
                MessageBox.Show("Please Enter a Patient Id");
            }
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            PatientModel model = PatientHandler.GetPatient(GetUserInfo.Id).ToModel();
            
            if (model !=null)
            {
                TestWindow tw = new TestWindow();
                tw.Show();
                tw.PatientName.Text = model.Name;
            }
            else
            {
                MessageBox.Show("Please Search A Patient");
            }

            
        }

        public void AddItemsToTestList()
        {
            TestList.Items.Clear();

            Patient patient = new Patient();
            if (GetUserInfo.Id > 0)
            {
                 patient = PatientHandler.GetPatient(GetUserInfo.Id);
            }
            if (patient !=null)
            {
                if (patient.Tests != null)
                {
                    foreach (var test in patient.Tests)
                    {

                        TestList.Items.Add(test.Name);
                    }

                }
                else
                {
                    TestList.Items.Add("No Tests Assign");
                }
            }


           

        }

        private void XRay_Click(object sender, RoutedEventArgs e)
        {
            PatientModel model = PatientHandler.GetPatient(GetUserInfo.Id).ToModel();

            if (model != null)
            {
                XRayWindow window = new XRayWindow();
                window.Show();
                window.PatientName.Text = model.Name;
            }
            else
            {
                MessageBox.Show("Please Search A Patient");
            }



        }
    }
}
