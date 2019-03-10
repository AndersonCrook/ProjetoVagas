
using SQLite;

namespace ProjetoVagas.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(string dbName);
    }
}
