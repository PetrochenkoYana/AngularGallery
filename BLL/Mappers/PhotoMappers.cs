using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class PhotoMappers
    {
        public static IEnumerable<DalPhoto> ToDal(this IEnumerable<PhotoEntity> photoEntities)
        {
            return ReferenceEquals(photoEntities, null) ? null 
                : photoEntities.AsEnumerable().Select(photo => photo.ToDal());
        }

        public static IEnumerable<PhotoEntity> ToBll(this IEnumerable<DalPhoto> dalPhotos)
        {
            return ReferenceEquals(dalPhotos, null) ? null : 
                dalPhotos.AsEnumerable().Select(photo => photo.ToBll());
        }

        public static DalPhoto ToDal(this PhotoEntity photoEntity)
        {
            return new DalPhoto()
            {
                Id = photoEntity.Id,
                AlbumId = photoEntity.AlbumId,
                LoadDateTime = photoEntity.LoadDateTime,
                Name = photoEntity.Name,
                Path = photoEntity.Path
            };
        }

        public static PhotoEntity ToBll(this DalPhoto dalphoto)
        {
            return new PhotoEntity()
            {
                Id = dalphoto.Id,
                AlbumId = dalphoto.AlbumId,
                Name = dalphoto.Name,
                LoadDateTime = dalphoto.LoadDateTime,
                Path = dalphoto.Path
            };
        }
    }
}
