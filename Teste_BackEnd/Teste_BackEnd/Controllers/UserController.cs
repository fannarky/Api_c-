using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_BackEnd.Model;
using Teste_BackEnd.Facades;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private Facade _facade = new Facade();

        // GET api/values
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
           return this._facade.getUser();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            return this._facade.getUserByPk(id);
        }

        [HttpPost]
        public void Post([FromBody] Usuario user)
        {
            if(user != null)
            {
                this._facade.insertUser(user);
            }
        }

    }
}