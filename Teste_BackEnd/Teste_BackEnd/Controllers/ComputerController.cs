using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Teste_BackEnd.Model;

namespace Teste_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Computer>> Get()
        {
            return new List<Computer>();
        }

        [HttpGet("{id}")]
        public ActionResult<Computer> GetByPk(int id)
        {
            return new Computer();
        }

        [HttpPost]
        public ActionResult<MessageCollection> Post([FromBody] Computer computer)
        {
            return new MessageCollection();
        }

        [HttpDelete("{id}")]
        public ActionResult<MessageCollection> DeleteByPk(int id)
        {
            return new MessageCollection();
        }

        [HttpPut]
        public ActionResult<MessageCollection> Put([FromBody] Computer computer)
        {
            return new MessageCollection();
        }



    }
}
