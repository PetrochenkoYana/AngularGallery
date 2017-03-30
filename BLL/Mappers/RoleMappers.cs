using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
   public static class RoleMappers
    {
        public static DalRole ToDal(this RoleEntity roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        public static RoleEntity ToBll(this DalRole dalrole)
        {
            return new RoleEntity()
            {
                Id = dalrole.Id,
                Name = dalrole.Name,
                Description = dalrole.Description
            };
        }
    }
}
