using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace uit.ooad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // api/example
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> GetApiExample()
        {
            return "Hello World";
        }

        // api/example/{id}
        [HttpGet("{id:int}")]
        public ActionResult<string> GetApiExampleId(int id)
        {
            return "id là: " + id;
        }
    }
}
