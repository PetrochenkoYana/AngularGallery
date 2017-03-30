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
    public class PhotoRepository:IPhotoRepository
    {
        private readonly DbContext context;

        public PhotoRepository(DbContext uow)
        {
            context = uow;
        }

        public void AddToAlbum(int albumId,string path)
        {
            context.Set<Photo>().Add(new Photo()
            {
                AlbumId = albumId,
                LoadDateTime = DateTime.Now,
                Name = $"{albumId}",
                Path = path
            });
        }

        public void Create(DalPhoto photo)
        {
            context.Set<Photo>().Add(photo.ToOrm());
        }

        public void Delete(DalPhoto photo)
        {
            var delPhoto = context.Set<Photo>()
               .Single(a => a.AlbumId == photo.AlbumId);
            context.Set<Photo>().Remove(delPhoto);
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return context.Set<Photo>().AsEnumerable().Select(photo => photo.ToDal());
        }

        public IEnumerable<DalPhoto> GetByAlbumId(int albumId)
        {
            return context.Set<Photo>()
                .Where(photo => photo.AlbumId == albumId)
                .AsEnumerable()
                .Select(photo => photo.ToDal());
        }

        public DalPhoto GetById(int key)
        {
            return context.Set<Photo>().Find(key).ToDal();
        }

        public IQueryable<bool> GetByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}
