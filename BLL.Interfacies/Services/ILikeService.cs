using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{

    public interface ILikeService
    {
        LikeEntity GetLikeEntity(int id);
        IEnumerable<LikeEntity> GetAllLikeEntities();
        void CreateLike(LikeEntity like);
        void DeleteLike(LikeEntity like);
        IEnumerable<LikeEntity> GetByPhotoId(int photoId);
    }
}
