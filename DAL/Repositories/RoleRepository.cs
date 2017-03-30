using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }
        public void Create(DalRole role)
        {
            context.Set<Role>().Add(role.ToOrm());
        }

        public void Delete(DalRole role)
        {
            var delRole = context.Set<Role>()
                .Single(a => a.RoleId == role.Id);
            context.Set<Role>().Remove(delRole);
        }
    
        public IEnumerable<DalRole> GetAll()
        {
           var otmRole= context.Set<Role>();
            var res=new List<DalRole>();
            foreach (var role in otmRole)
            {
                res.Add(role.ToDal());
            }
            return res;
        }

        public DalRole GetById(int key)
        {
            return context.Set<Role>().Find(key).ToDal();
        }

        public IQueryable<bool> GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}
