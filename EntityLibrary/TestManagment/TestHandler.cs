using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.TestManagment
{
    public class TestHandler
    {
        public static List<Test> GetTests()
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                return context.Tests.ToList();
            }
        }

    }
}
