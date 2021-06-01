using System;
using System.Collections.Generic;
using System.Text;
using AppUI.Models;

namespace AppUI.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
      
        public int Price { get; set; }

        public List<PatientModel> Patients { get; set; }
    }
}
