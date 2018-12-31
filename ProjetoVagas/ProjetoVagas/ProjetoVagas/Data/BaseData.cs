using System.Collections.Generic;
using ProjetoVagas.Models;
using SQLite;
using Xamarin.Forms;

namespace ProjetoVagas.Data
{
    class BaseData
    {
        protected SQLiteConnection db;
        private string dbName = "AppExemplo.db3";
        public BaseData()
        {
            var dep = DependencyService.Get<ISQLite>();
            string route = dep.GetConection(dbName);
            this.db = new SQLiteConnection(route);
        }

        public  void Save(Vagas vaga)
        {
            db.Insert(vaga);
        }

        public Vagas GetById(int id)
        {
            return db.Table<Vagas>().Where(a => a.Id == id).FirstOrDefault();        
        }

        public List<Vagas> GetByJobTitle(string Title)
        {
            return db.Table<Vagas>().Where(a => a.JobTitle.Contains(Title)).ToList();
        }

        public List<Vagas> GetAll()
        {
            return db.Table<Vagas>().ToList();
        }

        public void Update(Vagas vaga)
        {
            db.Update(vaga);
        }

        public void Delete(Vagas vaga)
        {
            db.Delete(vaga);
        }
        
    }
}