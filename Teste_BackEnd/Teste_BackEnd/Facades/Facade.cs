using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_BackEnd.DAL;
using Teste_BackEnd.Factory;

namespace Teste_BackEnd.Facades
{
    public partial class Facade
    {
        private UserDAL _userDAL;

        public Facade()
        {
            _userDAL = UserFactory.createUser();
        }
    }
}
