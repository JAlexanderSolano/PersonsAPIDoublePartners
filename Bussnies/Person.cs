using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class Person
    {
        public DataTable ObtenerPersona()
        {
            Data.Person person = new Data.Person();
            DataTable tblResult = person.ObtenerPersona();
            return tblResult;
        }
    }
}
