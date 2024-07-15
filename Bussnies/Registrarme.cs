using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class Registrarme
    {
        public DataTable Registrar(string names, string lastnames, string identification, string email, string typeid, string username, string password)
        {
            Data.Registrarme registrarme = new Data.Registrarme();
            DataTable tblResult = registrarme.Registrar(names, lastnames, identification, email, typeid, username, password);
            return tblResult;
        }
    }
}
