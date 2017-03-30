using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using Angular.Models;

namespace Angular.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static LikeViewModel ToMvcLike(this LikeEntity likeEntity)
        {
            return new LikeViewModel()
            {
                LikeId = likeEntity.Id,
                PhotoId = likeEntity.PhotoId,
                UserId = likeEntity.UserId

            };

        }
        public static LikeEntity ToBllLike(this LikeViewModel likeViewModel)
        {
            return new LikeEntity()
            {
                Id = likeViewModel.LikeId,
                PhotoId = likeViewModel.PhotoId,
                UserId = likeViewModel.UserId
            };
        }

        public static PhotoViewModel ToMvcPhoto(this PhotoEntity photoEntity)
        {
            return new PhotoViewModel()
            {
                PhotoId = photoEntity.Id,
                AlbumId = photoEntity.AlbumId,
                Name = photoEntity.Name,
                LoadDateTime = photoEntity.LoadDateTime,
                Path = photoEntity.Path,
                LikesAmount = photoEntity.LikesAmount,
            };

        }
        public static PhotoEntity ToBllPhoto(this PhotoViewModel photoAlbum)
        {
            return new PhotoEntity()
            {
                Id = photoAlbum.PhotoId,
                AlbumId = photoAlbum.AlbumId,
                Name = photoAlbum.Name,
                LoadDateTime = photoAlbum.LoadDateTime,
                Path = photoAlbum.Path
                
            };

        }

        public static IEnumerable<PhotoViewModel> ToMvcPhotos(this IEnumerable<PhotoEntity> photoEntities)
        {
            if (ReferenceEquals(photoEntities, null))
                return null;
            List<PhotoViewModel> res = new List<PhotoViewModel>();
            foreach (var photo in photoEntities)
            {
                res.Add(photo.ToMvcPhoto());
            }
            return res.AsEnumerable();
        }

        public static IEnumerable<PhotoEntity> ToBllPhotos(this IEnumerable<PhotoViewModel> photoViewModels)
        {
            if (ReferenceEquals(photoViewModels, null))
                return null;
            List<PhotoEntity> res = new List<PhotoEntity>();
            foreach (var photo in photoViewModels)
            {
                res.Add(photo.ToBllPhoto());
            }
            return res.AsEnumerable();
        }

        public static AlbumViewModel ToMvcAlbum(this AlbumEntity albumEntity)
        {
            return new AlbumViewModel()
            {
                AlbumId = albumEntity.Id,
                Name = albumEntity.Name,
                AlbumImage = albumEntity.AlbumImage,
                UserId = albumEntity.UserId

            };

        }
        public static AlbumEntity ToBllAlbum(this AlbumViewModel dalAlbum)
        {
            return new AlbumEntity()
            {
                Id = dalAlbum.AlbumId,
                Name = dalAlbum.Name,
                AlbumImage = dalAlbum.AlbumImage,
                UserId = dalAlbum.UserId

            };

        }
        public static IEnumerable<AlbumViewModel> ToMvcAlbums(this IEnumerable<AlbumEntity> albumEntities)
        {
            if (ReferenceEquals(albumEntities, null))
                return null;
            List<AlbumViewModel> res = new List<AlbumViewModel>();
            foreach (var album in albumEntities)
            {
                res.Add(album.ToMvcAlbum());
            }
            return res.AsEnumerable();
        }

        public static IEnumerable<AlbumEntity> ToBllAlbums(this IEnumerable<AlbumViewModel> albumViewModels)
        {
            if (ReferenceEquals(albumViewModels, null))
                return null;
            List<AlbumEntity> res = new List<AlbumEntity>();
            foreach (var album in albumViewModels)
            {
                res.Add(album.ToBllAlbum());
            }
            return res.AsEnumerable();
        }
        public static UserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                UserId = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                Password = userEntity.Password,
                ConfirmPassword = userEntity.Password,
                AccountImage = userEntity.AccountImage,
                PersonalInformation = userEntity.PersonalInformation,
                Role = (Role)userEntity.RoleId
            };
        }

        public static UserEntity ToBllUser(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.UserId,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
                Password =userViewModel.Password,
                AccountImage = userViewModel.AccountImage,
                PersonalInformation = userViewModel.PersonalInformation,
                RoleId = (int)userViewModel.Role
            };
        }
    }
}