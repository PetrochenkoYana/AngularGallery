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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            var ormUser= context.Set<User>();
            var res = new List<DalUser>();
            foreach (var user in ormUser)
            {
                res.Add(user.ToDal());
            }
            return res;
        }

        public DalUser GetById(int key)
        {
            return context.Set<User>().FirstOrDefault(user => user.UserId == key).ToDal();
        }

        public IQueryable<bool> GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser user)
        {
            context.Set<User>().Add(user.ToOrm());
        }

        public void Delete(DalUser user)
        {
            var delUser = context.Set<User>().Single(u => u.UserId == user.Id);
            context.Set<User>().Remove(delUser);
        }
        
        public DalUser GetUserByEmail(string email)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Email == email);
            return ReferenceEquals(ormUser, null) ? null : ormUser.ToDal();
        }

        public void ChangeProfilePhoto(int id, string photo)
        {
            var ormUser = context.Set<User>().Single(user => user.UserId == id);
            ormUser.AccountImage = photo;
        }

        public void ChangeProfileInfo(DalUser userdata)
        {
            var ormuser = context.Set<User>().Single(user => user.UserId == userdata.Id);
            ormuser.FirstName = userdata.FirstName;
            ormuser.LastName = userdata.LastName;
            ormuser.UserName = userdata.UserName;
            ormuser.PersonalInformation = userdata.PersonalInformation;
        }
    }
}