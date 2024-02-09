using ExpertAuction.API.Communication.Requests;
using ExpertAuction.API.Filters;
using ExpertAuction.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpertAuction.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    //todos os endpoients dessa controller precisam de autenticação
    public class OfferController : ExpertAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer(
            [FromRoute]int itemId,
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase
            )
        {

            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }
    }
}
