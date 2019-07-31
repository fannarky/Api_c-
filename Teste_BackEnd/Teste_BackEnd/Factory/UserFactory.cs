using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_BackEnd.DAL;

namespace Teste_BackEnd.Factory
{
    public static class UserFactory
    {
        public static UserDAL createUser()
        {
            return new UserDAL();
        }
    }
}
