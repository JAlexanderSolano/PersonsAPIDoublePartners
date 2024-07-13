using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class InstanciaConexion
    {
        public void Instancia(string _instancia)
        {
            Data.Conexion.cade = _instancia;
        }
    }
}
