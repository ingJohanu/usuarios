using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios.Models;

namespace usuarios.Repositories
{
    public interface IPublicacionRepository:IRepository<tbl_publicacion>
    {
        IEnumerable<tbl_publicacion> PublicacionPagedList(int page, int rows);
    }
}
