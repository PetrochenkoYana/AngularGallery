using System;
using System.Collections.Generic;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;
using BLL.Mappers;
using System.Linq;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork uow;
        private readonly IPhotoRepository photoRepository;
        private readonly ILikeRepository likeRepo;

        public PhotoService(IUnitOfWork uow, IPhotoRepository repository, ILikeRepository likeRepo)
        {
            this.uow = uow;
            this.photoRepository = repository;
            this.likeRepo = likeRepo;
        }
        public void CreatePhoto(PhotoEntity photo)
        {
            photoRepository.Create(photo.ToDal());
            uow.Commit();
        }

        public void DeletePhoto(PhotoEntity photo)
        {
            photoRepository.Delete(photo.ToDal());
        }

        public IEnumerable<PhotoEntity> GetByAlbumId(int albumId)
        {
            var album = photoRepository.GetByAlbumId(albumId).ToBll().ToList();
            foreach (var photo in album)
            {
                var likes = likeRepo.GetAll().Count(l => l.PhotoId == photo.Id);
                photo.LikesAmount = likes;
            }

            return album;
        }

        public PhotoEntity GetPhotoEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void AddToAlbum(int albumId,string path)
        {
            photoRepository.AddToAlbum(albumId,path);
            uow.Commit();
        }

        public IEnumerable<PhotoEntity> GetAll()
        {
            return photoRepository.GetAll().ToBll();
        }
    }
}
