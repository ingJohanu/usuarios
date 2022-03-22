using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarios.Models
{
    public class tbl_users
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string identificacion { get; set; }
        public string correo { get; set; }
        public string contacto { get; set; }

    }
}
