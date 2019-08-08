using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste_BackEnd.Facades;
using Teste_BackEnd.Model;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private Facade _facade = new Facade();

        [HttpGet]
        public ActionResult<MessageCollection<List<Api>>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public 
    }
}
