using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppUI.Extras
{
    class Gender : ObservableCollection<string>
    {
        public Gender()
        {

            Add("Male");
            Add("Female");
            Add("Other");
        }
    }
}
