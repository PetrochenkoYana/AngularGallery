using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IPhotoRepository:IRepository<DalPhoto>
    {
        IEnumerable<DalPhoto> GetByAlbumId(int albumId);
        void AddToAlbum(int albumId,string path);
        new IEnumerable<DalPhoto> GetAll();

    }
}
