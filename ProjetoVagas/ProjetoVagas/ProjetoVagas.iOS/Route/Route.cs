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

[assembly: Dependency(typeof(Route))]
namespace ProjetoVagas.iOS.Route
{
    class Route : ISQLite
    {
        public string GetConection(string dbName)
        {
            string FolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string LibraryPath = Path.Combine(FolderPath, "..", "Library");
            string DataPath = Path.Combine(LibraryPath, dbName);

            return LibraryPath;
        }
    }
}