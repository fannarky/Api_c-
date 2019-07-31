using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teste_BackEnd.Database;
using Teste_BackEnd.Model;

namespace Teste_BackEnd.DAL
{
    public class UserDAL : IDAL<Usuario>
    {

        private DatabaseHelper databaseHelper;

        public UserDAL()
        {
            databaseHelper = DatabaseHelper.Create();
        }

        public void change()
        {
            var paramts = new SqlParameter[]
            {
                new SqlParameter("P_1", "valor do parametro (variavel)")
            };

            this.databaseHelper.ExecuteNonQuery("Query a ser executada", paramts);
        }

        public void delete(int id)
        {
            var paramts = new SqlParameter[]
            {
                new SqlParameter("P_ID", id)
            };

            this.databaseHelper.ExecuteNonQuery("Query a ser executada", paramts);
        }

        public List<Usuario> get()
        {
            List<Usuario> list = new List<Usuario>();
            Usuario user = new Usuario();
            try
            {
                SqlDataReader reader = null;
                databaseHelper.OpenConnection();
                SqlCommand query = new SqlCommand("select * from tb_funcionario", databaseHelper.connection);
                reader = databaseHelper.ExecuteDataReader(query);
                while (reader.Read())
                {
                    user.id = reader.GetInt32(0);
                    user.name = reader.GetString(1);
                    user.email = reader.GetString(2);
                    user.phone = reader.GetString(3);
                    list.Add(user);
                }
                reader.Close();
                this.databaseHelper.CloseConnection();
            }
            catch(Exception ex){
                throw ex;
            }
            return list;
            
        }

        public Usuario getByPk(int id)
        {
            Usuario user = new Usuario();
            SqlDataReader reader = null;
            try
            {
                //string query = "SELECT * FROM Pessoa WHERE id = @id";
                SqlCommand query = new SqlCommand("select * from tb_funcionario where idFuncionario = @id", databaseHelper.connection);
                databaseHelper.OpenConnection();
                reader = databaseHelper.ExecuteDataReader(query,
                    new SqlParameter("@id", id));
                if (reader.Read())
                {
                    user.id = reader.GetInt32(0);
                    user.name = reader.GetString(1);
                    user.email = reader.GetString(2);
                    user.phone = reader.GetString(3);
                }
                reader.Close();
                this.databaseHelper.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.databaseHelper.CloseConnection();
            }
            return user;

        }

        public void set(Usuario person)
        {
            //Lista de parametros
            var paramts = new SqlParameter[]
            {
                new SqlParameter("@P_ID", person.id),
                new SqlParameter("@P_NAME", person.name),
                new SqlParameter("@P_EMAIL", person.email),
                new SqlParameter("@P_PHONE", person.phone)
            };

            this.databaseHelper.ExecuteNonQuery("Query a ser executada", paramts);

            throw new NotImplementedException();
        }
    }
}
