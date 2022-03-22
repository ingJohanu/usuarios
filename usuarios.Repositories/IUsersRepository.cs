using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios.Models;

namespace usuarios.Repositories
{
    public interface IUsersRepository:IRepository<tbl_users>
    {
        IEnumerable<tbl_users> UsersPagedList(int page, int rows);
    }
}
