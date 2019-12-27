using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uit.hotel.Businesses;
using uit.hotel.PaymentHelper;

namespace uit.hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController() { }

        [HttpPost("momo")]
        public async Task<ActionResult<MomoIPNResponse>> MomoIPN([FromForm] MomoIPNRequest parameter)
        {
            var receipt = await ReceiptBusiness.MomoNotified(parameter);
            return receipt.GetMomoIPNResponse();
        }
    }
}
