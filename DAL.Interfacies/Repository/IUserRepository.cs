using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRepository : IRepository<DalUser>//Add user repository methods!
    {
        DalUser GetUserByEmail(string email);
        void ChangeProfilePhoto(int id, string photo);
        void ChangeProfileInfo(DalUser user);
    }
}