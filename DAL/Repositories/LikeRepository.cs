using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class LikeRepository:ILikeRepository
    {
        private readonly DbContext context;

        public LikeRepository(DbContext uow)
        {
            this.context = uow;
        }
        public DalLike GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(DalLike like)
        {
            context.Set<Like>().Add(like.ToOrm());
        }

        public void Delete(DalLike like)
        {
            var delLike = context.Set<Like>()
               .Single(a => a.LikeId == like.Id);
            context.Set<Like>().Remove(delLike);
        }

        public IEnumerable<DalLike> GetAll()
        {
            return context.Set<Like>().AsEnumerable().Select(l=>l.ToDal());
        }
    }
}
