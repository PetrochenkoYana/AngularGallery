using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public UserEntity GetUserEntity(int id)
        {
            return userRepository.GetById(id).ToBll();
        }
        
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBll());
        }

        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDal());
            uow.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDal());
            uow.Commit();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email).ToBll();
        }

        public void ChangeProfilePhoto(int id,string photo)
        {
            userRepository.ChangeProfilePhoto(id,photo);
            uow.Commit();
        }

        public void ChangeProfileInfo(UserEntity userdata)
        {
            userRepository.ChangeProfileInfo(userdata.ToDal());
            uow.Commit();
        }
    }
}
