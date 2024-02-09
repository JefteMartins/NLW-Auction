using Bogus;
using ExpertAuction.API.Contracts;
using ExpertAuction.API.Entities;
using ExpertAuction.API.Enums;
using ExpertAuction.API.UseCases.Auctions.GetCurrent;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCase.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success() {

            var testAuction = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1,50))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                     new Item
                     {
                         Id = f.Random.Number(1,50),
                         Name = f.Commerce.ProductName(),
                         Brand = f.Commerce.ProductAdjective(),
                         BasePrice = f.Random.Number(50,1000),
                         Condition = f.PickRandom<Condition>(),
                         AuctionId = auction.Id
                     }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(testAuction);
            //ARRANGE
            var useCase = new GetCurrentAuctionUseCase(mock.Object);
            //ACT  
            var auction = useCase.Execute();
            //ASSERT
            auction.Should().NotBeNull();
            auction.Id.Should().Be(testAuction.Id);
            auction.Name.Should().Be(testAuction.Name);
        }
    }
}
