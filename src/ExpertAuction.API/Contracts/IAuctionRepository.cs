using ExpertAuction.API.Entities;

namespace ExpertAuction.API.Contracts
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
