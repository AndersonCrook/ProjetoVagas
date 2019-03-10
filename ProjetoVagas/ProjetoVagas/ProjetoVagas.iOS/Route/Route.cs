using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using ProjetoVagas.Data;
using Xamarin.Forms;
using ProjetoVagas.iOS.Route;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(Route))]
namespace ProjetoVagas.iOS.Route
{
    class Route : ISQLite
    {
        public Route()
        {

        }

        public SQLiteConnection GetConnection(string dbName)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, "..", "Library", dbName);
            return new SQLiteConnection(path);

        }
    }
}