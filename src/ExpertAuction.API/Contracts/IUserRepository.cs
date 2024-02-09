using ExpertAuction.API.Entities;

namespace ExpertAuction.API.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
