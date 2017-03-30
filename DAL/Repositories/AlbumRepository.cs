using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DbContext context;

        public AlbumRepository(DbContext uow)
        {
            this.context = uow;
        }
        public void Create(DalAlbum album)
        {
           context.Set<Album>().Add(album.ToOrm());
        }

        public void Delete(DalAlbum album)
        {
            var delAlbum = context.Set<Album>()
                .Single(a=> a.AlbumId == album.Id);
            context.Set<Album>().Remove(delAlbum);
        }

        public IEnumerable<DalAlbum> GetAll()
        {
            return context.Set<Album>().Select(album => album.ToDal());
        }

        public DalAlbum GetById(int key)
        {
            return context.Set<Album>().Find(key).ToDal();
        }

        public IEnumerable<DalAlbum> GetByPredicate(Expression<Func<DalAlbum,bool>> f)
        {
            var ormAlbums=context.Set<Album>()
                .Where(ExpressionTransformer<DalAlbum,Album>.Tranform(f).Compile());
            return ormAlbums.Select(album =>album.ToDal());
        }

        public IEnumerable<DalAlbum> GetByUserId(int userId)
        {
            var ormuser = context.Set<Album>()
                .Where(album => album.UserId == userId).AsEnumerable();
            return ormuser .Select(album =>album.ToDal());
        }
    }
}
