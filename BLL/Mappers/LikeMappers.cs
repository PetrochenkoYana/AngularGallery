using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class LikeMappers
    {
        public static DalLike ToDal(this LikeEntity likeEntity)
        {
            return new DalLike()
            {
                Id = likeEntity.Id,
                UserId = likeEntity.UserId,
                PhotoId = likeEntity.PhotoId
            };
        }

        public static LikeEntity ToBll(this DalLike dalLike)
        {
            return new LikeEntity()
            {
                Id = dalLike.Id,
                UserId = dalLike.UserId,
                PhotoId = dalLike.PhotoId
            };
        }
    }
}

