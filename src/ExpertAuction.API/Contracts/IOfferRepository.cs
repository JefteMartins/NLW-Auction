using ExpertAuction.API.Entities;

namespace ExpertAuction.API.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
