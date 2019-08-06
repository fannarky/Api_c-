using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste_BackEnd.Database;
using Teste_BackEnd.Factory;
using Teste_BackEnd.Model;

namespace Teste_BackEnd.DAL
{
    public class UserDAL : IDAL<Usuario>
    {

        private DatabaseHelper databaseHelper;

        public UserDAL()
        {
            databaseHelper = DatabaseFactory.GetDatabase();
        }

        public void change(Usuario user)
        {
            var paramts = new SqlParameter[]
            {
                new SqlParameter("@P_ID", user.idFuncionario),
                new SqlParameter("@P_NAME", user.nmFuncionario),
                new SqlParameter("@P_EMAIL", user.nmEmail),
                new SqlParameter("@P_PASSWORD", user.nmSenha),
                new SqlParameter("@P_PHONE", user.nrTelefone),
                new SqlParameter("@P_CONTRACTOR", user.idEmpresa),
                new SqlParameter("@P_IDGESTOR", user.idGestor),
                new SqlParameter("@P_TYPE_FUNC", user.idTipo)
            };

            this.databaseHelper.ExecuteNonQuery("Query a ser executada", paramts);
        }

        public void delete(int id)
        {
            var paramts = new SqlParameter[]
            {
                new SqlParameter("@P_ID", id)
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
                    user.idFuncionario = reader.GetInt32(0);
                    user.nmFuncionario= reader.GetString(1);
                    user.nmEmail = reader.GetString(2);
                    user.nrTelefone = reader.GetString(3);
                    user.nmSenha = reader.GetString(4);
                    user.idEmpresa = reader.GetInt16(5);
                    user.idGestor = reader.GetInt16(6);
                    user.idTipo = reader.GetInt16(7);

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
                    user.idFuncionario = reader.GetInt32(0);
                    user.nmFuncionario= reader.GetString(1);
                    user.nmEmail = reader.GetString(2);
                    user.nrTelefone = reader.GetString(3);
                    user.nmSenha = reader.GetString(4);
                    user.idEmpresa = reader.GetInt16(5);
                    user.idGestor = reader.GetInt16(6);
                    user.idTipo = reader.GetInt16(7);
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
                new SqlParameter("@P_ID", person.idFuncionario),
                new SqlParameter("@P_NAME", person.nmFuncionario),
                new SqlParameter("@P_EMAIL", person.nmEmail),
                new SqlParameter("@P_PASSWORD", person.nmSenha),
                new SqlParameter("@P_PHONE", person.nrTelefone),
                new SqlParameter("@P_CONTRACTOR", person.idEmpresa),
                new SqlParameter("@P_IDGESTOR", person.idGestor),
                new SqlParameter("@P_TYPE_FUNC", person.idTipo)
            };

            this.databaseHelper.ExecuteNonQuery("Query a ser executada", paramts);

        }
    }
}
