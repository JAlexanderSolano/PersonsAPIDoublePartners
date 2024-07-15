using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
    public class Registrarme
    {
        public DataTable Registrar(string names, string lastnames, string identification, string email, string typeid, string username, string password)
        {
            string Query = String.Format("exec [dbo].[sp_UserRegisterAndListUser] 1, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}'", names, lastnames, identification,email, typeid, username, password);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }
    }
}
