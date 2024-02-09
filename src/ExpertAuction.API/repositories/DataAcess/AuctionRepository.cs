using ExpertAuction.API.Contracts;
using ExpertAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertAuction.API.repositories.DataAcess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ExpertAuctionDbContext _dbContext;
        public AuctionRepository(ExpertAuctionDbContext dbContext) => _dbContext = dbContext;

        public Auction? GetCurrent()
        {
            var today = new DateTime(2024, 01, 25);
            return _dbContext
                 .Auctions
                 .Include(auction => auction.Items)
                 .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
