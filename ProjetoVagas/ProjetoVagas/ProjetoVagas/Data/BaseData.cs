using System.Collections.Generic;
using ProjetoVagas.Models;
using SQLite;
using Xamarin.Forms;

namespace ProjetoVagas.Data
{
    class BaseData
    {
        protected SQLiteConnection _conexao;
        private string dbName = "AppExemplo.db3";

        public BaseData()
        {
            var dep = DependencyService.Get<ISQLite>();
            string route = dep.GetConection(dbName);

            _conexao = new SQLiteConnection(route);
            _conexao.CreateTable<Vagas>();
        }

        public  void Save(Vagas vaga)
        {
            _conexao.Insert(vaga);
        }

        public Vagas GetById(int id)
        {
            return _conexao.Table<Vagas>().Where(a => a.Id == id).FirstOrDefault();        
        }

        public List<Vagas> GetByJobTitle(string title)
        {
            return _conexao.Table<Vagas>().Where(a => a.JobTitle.Contains(title)).ToList();
        }

        public List<Vagas> GetAll()
        {
            return _conexao.Table<Vagas>().ToList();
        }

        public void Update(Vagas vaga)
        {
            _conexao.Update(vaga);
        }

        public void Delete(Vagas vaga)
        {
            _conexao.Delete(vaga);
        }
        
    }
}