using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IPhotoService
    {
        PhotoEntity GetPhotoEntity(int id);
        void CreatePhoto(PhotoEntity photo);
        void DeletePhoto(PhotoEntity photo);
        IEnumerable<PhotoEntity> GetByAlbumId(int albumId);
        void AddToAlbum(int albumId,string path);
        IEnumerable<PhotoEntity> GetAll();
    }
}
