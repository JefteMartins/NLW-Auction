using ExpertAuction.API.Contracts;
using ExpertAuction.API.Entities;

namespace ExpertAuction.API.repositories.DataAcess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ExpertAuctionDbContext _dbContext;
        public OfferRepository(ExpertAuctionDbContext dbContext) => _dbContext = dbContext;

        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }

    }
}
