using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using ProjetoVagas.Data;
using System.IO;
using ProjetoVagas.Droid.Route;

[assembly:Dependency(typeof(Route))]
namespace ProjetoVagas.Droid.Route
{
    class Route : ISQLite
    {
        public string GetConection(string dbName)
        {
            string FolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string DataPath = Path.Combine(FolderPath, dbName);

            return DataPath;
        }
    }
}