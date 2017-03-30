

using System;
using System.Collections.Generic;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;
using System.Linq;
using System.Linq.Expressions;
using BLL.Mappers;
using DAL.Interfacies.DTO;
using DAL.Repositories;

namespace BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork uow;
        private readonly IAlbumRepository albumRepository;

        public AlbumService(IUnitOfWork uow, IAlbumRepository repository)
        {
            this.uow = uow;
            albumRepository = repository;
        }

        public void CreateAlbum(AlbumEntity album)
        {
            albumRepository.Create(album.ToDal());
            uow.Commit();
        }

        public void DeleteAlbum(AlbumEntity album)
        {
            albumRepository.Delete(album.ToDal());
            uow.Commit();
        }

        public AlbumEntity GetAlbumEntity(int id)
        {
            return albumRepository.GetById(id).ToBll();
        }

        public IEnumerable<AlbumEntity> GetAllAlbumEntities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlbumEntity> GetByUserId(int userId)
        {
            return albumRepository
                .GetByUserId(userId)
                .Select(album => album.ToBll());
        }

        public IEnumerable<AlbumEntity> GetByPredicate(Expression<Func<AlbumEntity, bool>> f)
        {
            var dalAlbums=albumRepository
                .GetByPredicate(ExpressionTransformer<AlbumEntity, DalAlbum>.Tranform(f));
            return dalAlbums.Select(album => album.ToBll());
        }
    }
}
