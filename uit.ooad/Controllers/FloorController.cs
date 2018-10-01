using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uit.ooad.Businesses;
using uit.ooad.Models;

namespace uit.ooad.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FloorController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> PostApiFloor([FromBody] Floor floor)
        {
            var savedFloor = await FloorBusiness.Add(floor);
            return Ok(new
            {
                floor = savedFloor
            });
        }
    }
}
