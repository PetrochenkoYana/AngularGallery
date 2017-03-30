using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public RoleEntity GetRoleEntity(int id)
        {
            return roleRepository.GetById(id).ToBll();
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBll());
        }

        public void CreateRole(RoleEntity role)
        {
            roleRepository.Create(role.ToDal());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            throw new NotImplementedException();
        }
    }
}
