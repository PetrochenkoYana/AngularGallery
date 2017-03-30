using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class UserMappers
    {
        public static DalUser ToDal(this User user)
        {
            return new DalUser()
            {
                Id = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                AccountImage = user.AccountImage,
                PersonalInformation = user.PersonalInformation,
                RoleId = user.RoleId
            };
        }

        public static User ToOrm(this DalUser user)
        {
            return new User()
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                AccountImage = user.AccountImage,
                PersonalInformation = user.PersonalInformation,
                RoleId = user.RoleId
            };
        }
    }
}
