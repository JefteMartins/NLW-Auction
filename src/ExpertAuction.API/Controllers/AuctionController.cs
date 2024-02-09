using ExpertAuction.API.Entities;
using ExpertAuction.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace ExpertAuction.API.Controllers
{
    public class AuctionController : ExpertAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
        {

            var result = useCase.Execute();

            if (result is null)
                return NoContent();

            return Ok(result);
        }
    }
}
