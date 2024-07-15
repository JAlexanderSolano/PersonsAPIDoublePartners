using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class person:Iperson
    {
        public int id { get; set; }
        public string names { get; set; }
        public string lastnames { get; set; }
        public string identification { get; set; }
        public string email { get; set; }
        public string concactnamelastname { get; set; }
        public string concacttypeididentity { get; set; }
        public int status { get; set; }

        public person(int id, string names, string lastnames, string identification, string email, string concactnamelastname, string concacttypeididentity, int status)
        {
            this.id = id;
            this.names = names;
            this.lastnames = lastnames;
            this.identification = identification;
            this.email = email;
            this.concactnamelastname = concactnamelastname;
            this.concacttypeididentity = concacttypeididentity;
            this.status = status;
        }

        public person() { }

        public List<person> RetornarResultado(DataTable tbl)
        {
            List<person> resultados = new List<person>();
            if (tbl.Rows.Count > 0)
            {
                int id = 0;
                string Names = "", LasNames = "", Identification = "", Email = "" , ConcactNameLastName =  "", ConcactTypeIdIdentity = "";

                foreach (DataRow fila in tbl.Rows)
                {
                    id = Convert.ToInt32(fila["id"].ToString());
                    Names = fila["Names"].ToString();
                    LasNames = fila["LasNames"].ToString();
                    Identification = fila["Identification"].ToString();
                    Email = fila["Email"].ToString();
                    ConcactNameLastName = fila["ConcactNameLastName"].ToString();
                    ConcactTypeIdIdentity = fila["ConcactTypeIdIdentity"].ToString();
                    resultados.Add(new person(id, Names, LasNames, Identification, Email, ConcactNameLastName, ConcactTypeIdIdentity, 200) { });
                }
               
            }
            return resultados;
        }
    }
}
