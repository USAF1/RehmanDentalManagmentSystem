using System;
using System.Collections.Generic;
using System.Text;

namespace AppUI.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public long Contact { get; set; }

        public List<TestModel> Tests { get; set; }

    }
}
