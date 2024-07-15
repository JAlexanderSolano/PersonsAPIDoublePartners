using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Login
    {
        public DataTable LoginSesion(string username, string password)
        {
            string Query = String.Format("exec [dbo].[sp_Login] '{0}','{1}'", username, password);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }
    }
}
