using AppUI.Controllers;
using EntityLibrary.PatientManagment;
using EntityLibrary.XRayManagment;
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

namespace AppUI.Views
{
    /// <summary>
    /// Interaction logic for XRayWindow.xaml
    /// </summary>
    public partial class XRayWindow : Window
    {
        public ObservableCollection<BoolStringClass> myItemList { get; set; }

        public List<Xray> Xrays = XrayHandler.GetXRays();

        public static Patient patient = PatientHandler.GetPatient(GetUserInfo.Id);

        public Patient pt = patient;

        public XRayWindow()
        {
            InitializeComponent();
            GetMyItemList();
        }

        public class BoolStringClass
        {
            public string itemText { get; set; }
            public int itemValue { get; set; }
        }

        public void GetMyItemList()
        {
            myItemList = new ObservableCollection<BoolStringClass>();
            foreach (var Xray in Xrays)
            {
                myItemList.Add(new BoolStringClass { itemText = Xray.Name, itemValue = Xray.Id });
            }
            this.DataContext = this;
        }

        private void chkItem_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkSelecttedItem = (CheckBox)sender;
            Xray find = Xrays.Find(x => x.Name == chkSelecttedItem.Content.ToString());
            patient.XRays.Add(new Xray() { Id = find.Id, Name = find.Name, Price = find.Price});
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            PatientHandler.UpdatePatientXRay(patient);
            Patient py = PatientHandler.GetPatient(patient.Id);
            MessageBox.Show($"{py.Name} is Updated");
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
