using Microsoft.AspNetCore.Mvc;
using Teste_BackEnd.Facades;
using Teste_BackEnd.Model;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private Facade _facade = new Facade();

        [HttpPost]
        public ActionResult<MessageCollection> Auth()
        {
            return new MessageCollection();
        }
    }
}
