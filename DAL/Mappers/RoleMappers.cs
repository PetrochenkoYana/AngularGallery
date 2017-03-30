using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class RoleMappers
    {
        public static DalRole ToDal(this Role role)
            {
                return new DalRole()
                {
                    Id = role.RoleId,
                    Name = role.Name,
                    Description = role.Description
                };
            }

            public static Role ToOrm(this DalRole role)
            {
                return new Role()
                {
                    RoleId = role.Id,
                    Name = role.Name,
                    Description = role.Description
                };
            }
        }
}
