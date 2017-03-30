using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class LikeMappers
    {
        public static DalLike ToDal(this Like like)
        {
            return new DalLike()
            {
                Id = like.LikeId,
                UserId = like.UserId,
                PhotoId = like.PhotoId
            };
        }

        public static Like ToOrm(this DalLike like)
        {
            return new Like()
            {
                LikeId = like.Id,
                UserId = like.UserId,
                PhotoId = like.PhotoId
            };
        }
    }
}
