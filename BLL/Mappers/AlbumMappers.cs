using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class AlbumMappers
    {
        public static IEnumerable<DalAlbum> ToDal(this IEnumerable<AlbumEntity> albumEntities)
        {
            return ReferenceEquals(albumEntities, null) ? null
                : albumEntities.AsEnumerable().Select(album => album.ToDal());
        }

        public static IEnumerable<AlbumEntity> ToBll(this IEnumerable<DalAlbum> dalAlbums)
        {
            return ReferenceEquals(dalAlbums, null) ? null 
                : dalAlbums.AsEnumerable().Select(album => album.ToBll());
        }
        public static DalAlbum ToDal(this AlbumEntity albumEntity)
        {
            return new DalAlbum()
            {
                Id = albumEntity.Id,
                Name = albumEntity.Name,
                AlbumImage = albumEntity.AlbumImage,
                UserId = albumEntity.UserId
            };
        }

        public static AlbumEntity ToBll(this DalAlbum dalAlbum)
        {
            return new AlbumEntity()
            {
                Id = dalAlbum.Id,
                Name = dalAlbum.Name,
                AlbumImage = dalAlbum.AlbumImage,
                UserId = dalAlbum.UserId
            };
        }
    }
}
