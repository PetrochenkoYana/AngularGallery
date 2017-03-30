using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class PhotoMappers
    {
        public static DalPhoto ToDal(this Photo photo)
        {
            return new DalPhoto()
            {
                Id = photo.PhotoId,
                AlbumId = photo.AlbumId,
                Name = photo.Name,
                LoadDateTime = photo.LoadDateTime,
                Path = photo.Path
            };
        }

        public static Photo ToOrm(this DalPhoto photo)
        {
            return new Photo()
            {
                PhotoId = photo.Id,
                AlbumId = photo.AlbumId,
                Name = photo.Name,
                LoadDateTime = photo.LoadDateTime,
                Path = photo.Path
            };
        }
    }
}
