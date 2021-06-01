using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.UsersManagment
{
    public class UsersHandler
    {
        public static User GetUser(User user)
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                return (from User in context.Users.Include(u=>u.Role)
                        where(User.UserName == user.UserName && User.Password == user.Password)
                        select User).FirstOrDefault();

            }
        }

        public static List<User> GetUsers()
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                return (context.Users.Include(u=>u.Role).ToList());
            }
        }

        public static List<Role> GetRoles()
        {
            using (ManagmentDbContext context = new ManagmentDbContext())
            {
                return context.Roles.ToList();
            }
        }


    }
}
