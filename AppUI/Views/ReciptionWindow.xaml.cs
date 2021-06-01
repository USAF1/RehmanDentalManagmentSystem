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

namespace AppUI.Views
{
    /// <summary>
    /// Interaction logic for ReciptionWindow.xaml
    /// </summary>
    public partial class ReciptionWindow : Window
    {
        public ReciptionWindow()
        {
            InitializeComponent();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Age.Text == "" || Gender.Text == "Gender")
            {
                MessageBox.Show("Please Fill All The Fileds");
            }
            else
            {
                PatientModel model = new PatientModel();

                model.Name = Name.Text;
                if (Convert.ToInt32(Age.Text) >= 5 && Convert.ToInt32(Age.Text) <=100)
                {
                    model.Age =  Convert.ToInt32(Age.Text);
                }
                else
                {
                    MessageBox.Show("The Age Must be grater than 5 and less than 100");
                }
                model.Gender = Gender.Text;
                if(Contact.Text != "" && Contact.Text !=null)
                {
                    model.Contact = Convert.ToInt64(Contact.Text);
                }

                try
                {
                    PatientHandler.AddPatient(PatientHelper.ToEntity(model));
                    Name.Text = "";
                    Age.Text = "";
                    Gender.Text = "Gender";
                    Contact.Text = "";
                    MessageBox.Show("Patient Added");
                }
                catch (Exception error )
                {

                    MessageBox.Show(error.Message);
                }

                try
                {
                    PatientModel patient = PatientHandler.GetRecentPatient().ToModel();
                    MessageBox.Show($"Id: {patient.Id}");
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
            }


            
        }
    }
}
