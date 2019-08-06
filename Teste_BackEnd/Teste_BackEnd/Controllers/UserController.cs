
using System.Collections.Generic;
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
            if (id > 0 && string.IsNullOrEmpty(id.ToString()))
            {
                return this._facade.getUserByPk(id);
            }

            return new Usuario();
        }

        [HttpPost]
        public void Post([FromBody] Usuario user)
        {
            if(user != null)
            {
                this._facade.insertUser(user);
            }
        }

        [HttpDelete]
        public void DeleteFromId([FromBody] int id)
        {
            if (id > 0 && string.IsNullOrEmpty(id.ToString()))
            {
                this._facade.deleteUser(id);
            }
        }

        [HttpPut]
        public void Update([FromBody] Usuario user)
        {
            if (user != null)
            {
                this._facade.changeUser(user);
            }
        }

    }
}