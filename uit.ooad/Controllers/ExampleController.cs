using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Realms;
using uit.ooad.Interfaces;
using uit.ooad.Models;

namespace uit.ooad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly Realm Realm;

        public ExampleController(IRealmDatabase realmDatabase)
        {
            Realm = realmDatabase.Database;
        }

        // api/example
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> GetApiExample()
        {
            Realm.Write(() =>
            {
                Realm.Add<Example>(new Example()
                {
                    Key = "key",
                    Value = "value"
                });
            });
            return "Hello World" + Realm.All<Example>().ToString();
        }

        // api/example/{id}
        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<string> GetApiExampleId(int id)
        {
            return "id là: " + id;
        }
    }
}
