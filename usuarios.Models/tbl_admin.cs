using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarios.Models
{
    public class tbl_admin
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }
    }
}
