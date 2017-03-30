using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class AlbumMappers
    {
        public static DalAlbum ToDal(this Album album)
        {
            return new DalAlbum()
            {
                Id = album.AlbumId,
                Name = album.Name,
                AlbumImage = album.AlbumImage,
                UserId = album.UserId
            };
        }

        public static Album ToOrm(this DalAlbum album)
        {
            return new Album()
            {
                AlbumId = album.Id,
                Name = album.Name,
                AlbumImage = album.AlbumImage,
                UserId = album.UserId
            };
        }
    }
}
