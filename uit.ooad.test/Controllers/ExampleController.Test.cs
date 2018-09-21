using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Controllers;
using uit.ooad.Services;

namespace uit.ooad.test.Controllers
{
    [TestClass]
    public class ExampleControllerTest
    {
        [TestMethod]
        public void GetApiExample()
        {
            var controller = new ExampleController(new RealmDatabase());
            var result = controller.GetApiExample();

            Assert.IsTrue(result.Value.Contains("Hello World"));
        }
    }
}
