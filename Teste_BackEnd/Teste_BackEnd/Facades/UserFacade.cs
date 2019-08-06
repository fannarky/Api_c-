
using System.Collections.Generic;
using Teste_BackEnd.Model;

namespace Teste_BackEnd.Facades
{
    public partial class Facade
    {
        public void insertUser(Usuario user)
        {
            this._userDAL.set(user);
        }

        public List<Usuario> getUser()
        {
           return this._userDAL.get();
        }

        public Usuario getUserByPk(int id)
        {
            return this._userDAL.getByPk(id);
        }

        public void changeUser(Usuario user)
        {
            this._userDAL.change(user);
        }

        public void deleteUser(int id)
        {
            this._userDAL.delete(id);
        }
    }
}
