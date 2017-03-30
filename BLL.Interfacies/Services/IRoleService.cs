using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntity(int id);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
    }
}
