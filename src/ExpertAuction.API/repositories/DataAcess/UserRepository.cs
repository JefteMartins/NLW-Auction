using ExpertAuction.API.Contracts;
using ExpertAuction.API.Entities;

namespace ExpertAuction.API.repositories.DataAcess
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpertAuctionDbContext _dbContext;
        public UserRepository(ExpertAuctionDbContext dbContext) => _dbContext = dbContext;

        public bool ExistUserWithEmail(string email)
        {
            return _dbContext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
