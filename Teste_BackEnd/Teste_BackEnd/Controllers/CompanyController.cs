using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_BackEnd.Facades;
using Teste_BackEnd.Model;


namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public Facade _facade = new Facade();

        [HttpGet("{idgestor}")]
        public ActionResult<MessageCollection<List<Api>>> GetAllByIdGest(int idgestor)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{idapi}")]
        public ActionResult<MessageCollection<Api>> GetById()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<MessageCollection<Api>> Post()
        {
            throw new NotImplementedException();
        }

    }
}
