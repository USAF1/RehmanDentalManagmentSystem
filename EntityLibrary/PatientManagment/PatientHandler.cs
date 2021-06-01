﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.PatientManagment
{
    public class PatientHandler
    {
        public static void AddPatient(Patient entity)
        {

            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public static Patient GetPatient(int id)
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                return (from Patient in context.Patients.Include(t => t.Tests) where Patient.Id == id select Patient).FirstOrDefault();
            }
        }


        public static Patient GetRecentPatient()
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                return context.Patients.FromSqlRaw("select * from Patients where Id = (select MAX(Id) from Patients)").FirstOrDefault();
            }
        }

        public static void UpdatePatient(Patient pt)
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                if (pt.Tests !=null)
                {
                    foreach (var Test in pt.Tests)
                    {
                        context.Entry(Test).State = EntityState.Unchanged;
                    }
                }

                if (pt.XRays != null)
                {
                    foreach (var xray in pt.XRays)
                    {
                        context.Entry(xray).State = EntityState.Unchanged;
                    }
                }
                context.Update(pt);
                context.SaveChanges();
            }
        }

        public static void UpdatePatientTest(Patient pt)
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                if (pt.Tests != null)
                {
                    foreach (var Test in pt.Tests)
                    {
                        context.Entry(Test).State = EntityState.Unchanged;
                    }
                }
                pt.XRays.Clear();
                context.Update(pt);
                context.SaveChanges();
            }
        }

        public static void UpdatePatientXRay(Patient pt)
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {


                if (pt.XRays != null)
                {
                    foreach (var xray in pt.XRays)
                    {
                        context.Entry(xray).State = EntityState.Unchanged;
                        
                    }
                }
                pt.Tests.Clear();
                context.Update(pt);
                context.SaveChanges();
            }
        }
    }
}
