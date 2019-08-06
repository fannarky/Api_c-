
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
