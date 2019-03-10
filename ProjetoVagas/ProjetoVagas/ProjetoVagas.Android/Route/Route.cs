using System;
using ProjetoVagas.Data;
using ProjetoVagas.Droid.Route;
using Xamarin.Forms;
using SQLite;
using System.IO;

[assembly:Dependency(typeof(Route))]
namespace ProjetoVagas.Droid.Route
{
    class Route : ISQLite
    {

        public SQLiteConnection GetConnection(string dbName)
        {
            var documents = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, dbName);
            return new SQLiteConnection(path);
        }
    }
}