using ExpertAuction.API.Contracts;
using ExpertAuction.API.Entities;

namespace ExpertAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;

        public Auction? Execute() => _repository.GetCurrent();
    }
} 
