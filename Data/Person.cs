using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Person
    {
        public DataTable ObtenerPersona()
        {
            string Query = String.Format("exec [dbo].[sp_UserRegisterAndListUser] 2");
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }
    }
}
