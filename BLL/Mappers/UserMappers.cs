using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
   public static class UserMappers
    {
        public static DalUser ToDal(this UserEntity userEntity)
        {
            if (ReferenceEquals(userEntity, null))
                return null;
            return new DalUser()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                Password = userEntity.Password,
                AccountImage = userEntity.AccountImage,
                PersonalInformation = userEntity.PersonalInformation,
                RoleId = userEntity.RoleId
            };
        }

        public static UserEntity ToBll(this DalUser dalUser)
        {
            if (ReferenceEquals(dalUser, null))
                return null;
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.UserName,
                FirstName = dalUser.FirstName,
                LastName = dalUser.LastName,
                Email = dalUser.Email,
                Password = dalUser.Password,
                AccountImage = dalUser.AccountImage,
                PersonalInformation = dalUser.PersonalInformation,
                RoleId = dalUser.RoleId
            };
        }
    }
}
