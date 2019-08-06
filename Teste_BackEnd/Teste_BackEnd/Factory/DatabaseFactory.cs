using Teste_BackEnd.Database;

namespace Teste_BackEnd.Factory
{
    public static class DatabaseFactory
    {
        public static DatabaseHelper GetDatabase()
        {
            return new DatabaseHelper();
        }

        public static DatabaseHelper GetDatabase(string connectionString)
        {
            return new DatabaseHelper(connectionString);
        }
    }
}
