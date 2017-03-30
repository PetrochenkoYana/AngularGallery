using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class LikeService:ILikeService
    {
        private readonly IUnitOfWork uow;
        private readonly ILikeRepository likeRepository;

        public LikeService(IUnitOfWork uow, ILikeRepository repository)
        {
            this.uow = uow;
            likeRepository = repository;
        }
        public LikeEntity GetLikeEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LikeEntity> GetAllLikeEntities()
        {
            return likeRepository.GetAll().Select(l => l.ToBll());
        }

        public void CreateLike(LikeEntity like)
        {
            likeRepository.Create(like.ToDal());
            uow.Commit();
        }

        public void DeleteLike(LikeEntity like)
        {
           likeRepository.Delete(like.ToDal());
            uow.Commit();
        }

        public IEnumerable<LikeEntity> GetByPhotoId(int photoId)
        {
            throw new NotImplementedException();
        }
    }
}
