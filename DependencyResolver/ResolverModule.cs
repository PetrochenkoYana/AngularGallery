using System.Data.Entity;
using BLL.Interfacies.Services;
using BLL.Services;
using DAL.Interfacies.Repository;
using DAL.Repositories;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAlbumService>().To<AlbumService>();
            kernel.Bind<IAlbumRepository>().To<AlbumRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IPhotoService>().To<PhotoService>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<ILikeService>().To<LikeService>();
            kernel.Bind<ILikeRepository>().To<LikeRepository>();
        }
    }
}