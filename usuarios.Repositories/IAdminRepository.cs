using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios.Models;

namespace usuarios.Repositories
{
    public interface IAdminRepository
    {
        tbl_admin ValidateAdmin(string usuario, string contraseña);
    }
}
