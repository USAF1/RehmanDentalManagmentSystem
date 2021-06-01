using System;
using System.Collections.Generic;
using System.Text;
using EntityLibrary.UsersManagment;
using AppUI.Models;

namespace AppUI.Helpers
{
    public static class UserHelper
    {
        public static UserModel ToModel(this User entity)
        {
            UserModel user = new UserModel();
            user.Id = entity.Id;
            user.UserName = entity.UserName;
            user.Password = entity.Password;
            user.Role = new RoleModel() { Id = entity.Role.Id, Name = entity.Role.Name };
            return user;
        }

        public static User ToEntity(this UserModel model)
        {
            User entity = new User();
            entity.Id = model.Id;
            entity.UserName = model.UserName;
            entity.Password = model.Password;

            return entity;

        }
    }
}
