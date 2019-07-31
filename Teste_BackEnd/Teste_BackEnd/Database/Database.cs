using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_BackEnd.Database
{
    public class DatabaseHelper//<T> where T: new()
    {
        #region atributes
        public SqlConnection connection { get; set; }

        public string stringConnection { get; set; }
        #endregion

        #region constructors
        public DatabaseHelper()
        {
            this.stringConnection = "Server=tcp:jscanserver.database.windows.net,1433;Initial Catalog=jscandb;Persist Security Info=False;User ID=adm_jscan;Password=Y33bkxs9@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            this.connection = new SqlConnection(stringConnection);
        }

        public DatabaseHelper(string connection)
        {
            this.stringConnection = connection;
            this.connection = new SqlConnection(stringConnection);
        }
        #endregion

        #region private methods

        private string GetCorrectParameterName(string parameterName)
        {
            if (parameterName[0] != '@')
            {
                parameterName = "@" + parameterName;
            }
            return parameterName;
        }

        #endregion

        #region public methods

        public static DatabaseHelper Create()
        {
            return new DatabaseHelper();
        }

        public static DatabaseHelper Create(string connection)
        {
            return new DatabaseHelper(connection);
        }

        public void OpenConnection()
        {
            if(this.connection.State == ConnectionState.Closed)
            {
                this.connection.Open();
            }
        }

        public void CloseConnection()
        {
            this.connection.Close();
        }

        public SqlParameter BuildParameter(string nome, object valor,
         DbType tipo, int size)
        {
            SqlParameter parametro = new SqlParameter(this.GetCorrectParameterName(nome), valor);
            parametro.DbType = tipo;
            parametro.Size = size;
            return parametro;
        }

        public void BuildParameter(string nome, object valor, DbType tipo, int size, List<SqlParameter> listParametros)
        {
            SqlParameter parametro = this.BuildParameter(nome, valor, tipo, size);
            listParametros.Add(parametro);
        }

        public SqlParameter BuildOutPutParameter(string nome, DbType tipo, int size)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = this.GetCorrectParameterName(nome);
            parametro.DbType = tipo;
            parametro.Size = size;
            parametro.Direction = ParameterDirection.Output;
            return parametro;
        }

        public void BuildOutPutParameter(string name, DbType type, int size, List<SqlParameter> listParametros)
        {
            SqlParameter parameter = this.BuildOutPutParameter(name, type, size);
            listParametros.Add(parameter);
        }

        public void ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public SqlDataReader ExecuteDataReader(SqlCommand command, SqlParameter parameter)
        {
            try
            {
                SqlDataReader reader = null;
                command.Parameters.Add(parameter);
                reader = command.ExecuteReader();
                return reader;

            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public SqlDataReader ExecuteDataReader(SqlCommand command)
        {
            try
            {
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                return reader;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void ExecuteNonQuery(SqlCommand command, bool openConnection)
        {
            if (openConnection)
            {
                this.OpenConnection();
            }

            this.ExecuteNonQuery(command);

            if (openConnection)
            {
                this.CloseConnection();
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            Exception erro = null;
            try
            {
                this.OpenConnection();
                SqlCommand command = this.connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                this.ExecuteNonQuery(command);
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                erro = ex;
            }
            finally
            {
                this.CloseConnection();
            }

            if (erro != null)
            {
                throw erro;
            }
        }
        
        public void ExecuteCommands(params SqlCommand[] commands)
        {
            Exception erro = null;
            SqlTransaction trans = null;
            try
            {
                this.connection.Open();
                trans = this.connection.BeginTransaction();
                for (int i = 0; i < commands.Length; i++)
                {
                    commands[i].Transaction = trans;
                    this.ExecuteNonQuery(commands[i]);
                }
                trans.Commit();
                this.connection.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                erro = ex;
            }
            finally
            {
                this.connection.Close();
            }

            if (erro != null)
            {
                throw erro;
            }
        }

        #endregion

    }
}
