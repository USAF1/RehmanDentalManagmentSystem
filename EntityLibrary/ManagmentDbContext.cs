using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntityLibrary.UsersManagment;
using EntityLibrary.PatientManagment;
using EntityLibrary.TestManagment;
using EntityLibrary.XRayManagment;

namespace EntityLibrary
{
    public class ManagmentDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Xray> XRays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.; user id=sa; password=Charli1122#; Initial Catalog=RehmanDentalManagment");
        }
    }
}
