using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarios.Models
{
    public class tbl_publicacion
    {
        public int id { get; set; }
        public int idusers { get; set; }
        public string publicacion { get; set; }
        public string comentarios { get; set; }
    }
}
