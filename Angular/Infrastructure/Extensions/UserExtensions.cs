using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Angular.Infrastructure.Extensions
{
    public static class UserExtensions
    {
        public static int GetUserId(this Controller controller)
        {
            var identity = controller.User.Identity;
            var user = Membership.GetUser(identity.Name);
            if (user == null)
            {
                throw new InvalidOperationException("User [" +
                    identity.Name + " ] not found.");
            }

            // Do whatever u want with the unique identifier.
           return  (int) user.ProviderUserKey;
        }
    }
}