using System;
using System.Linq;
using System.Web.Security;
using BLL.Interfacies.Services;

namespace Angular.Providers
{
    //провайдер ролей указывает системе на статус пользователя и наделяет 
    //его определенные правами доступа
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {

            var user = UserService.GetAllUserEntities().FirstOrDefault(u => u.Email == email);

            if (user == null) return false;

            var userRole = RoleService.GetRoleEntity(user.RoleId);

            return userRole != null && userRole.Name == roleName;
        }

        public override string[] GetRolesForUser(string email)
        {
            
                var roles = new string[] { };
                var user = UserService.GetUserByEmail(email);

                if (user == null) return roles;

                var userRole = RoleService.GetRoleEntity(user.RoleId);

                if (userRole != null)
                {
                    roles = new [] { userRole.Name };
                }
                return roles;
            
        }

        public override void CreateRole(string roleName)
        {
            RoleService.CreateRole(new BLL.Interfacies.Entities.RoleEntity() { Name = roleName });
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}