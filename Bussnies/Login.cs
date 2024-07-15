using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class Login
    {
        public DataTable LoginSesion(string username, string password)
        {
            Data.Login login = new Data.Login();
            DataTable TblResult = login.LoginSesion(username, password);
            return TblResult;
        }
    }
}
