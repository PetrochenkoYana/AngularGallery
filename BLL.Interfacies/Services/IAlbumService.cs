using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IAlbumService
    {
        AlbumEntity GetAlbumEntity(int id);
        IEnumerable<AlbumEntity> GetAllAlbumEntities();
        void CreateAlbum(AlbumEntity album);
        void DeleteAlbum(AlbumEntity album);
        IEnumerable<AlbumEntity> GetByUserId(int userId);
        IEnumerable<AlbumEntity> GetByPredicate(Expression<Func<AlbumEntity, bool>> f);

    }
}
