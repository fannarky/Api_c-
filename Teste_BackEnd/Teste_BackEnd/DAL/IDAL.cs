using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_BackEnd.DAL
{
    interface IDAL<T>
    {
        List<T> get();

        void set(T model);

        void change();

        void delete(int id);

        T getByPk(int pk);

    }
}
