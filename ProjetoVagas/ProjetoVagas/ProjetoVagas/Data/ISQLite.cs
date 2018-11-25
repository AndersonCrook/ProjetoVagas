using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoVagas.Data
{
    public interface ISQLite
    {
        string GetConection(string dbName);
    }
}
